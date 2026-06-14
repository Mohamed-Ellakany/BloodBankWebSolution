using BloodBank.Application.Common.ModelContracts.AI;
using BloodBank.Application.Services.AI;
using BloodBank.Application.Services.Blood;
using BloodBank.Application.Services.BloodBanks;
using BloodBank.Application.Services.BloodTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.AiServices
{
    public class AiServices(IHttpClientFactory httpClientFactory , IBloodSevrice bloodSevrice , IBloodBankServices bloodBankServices , IBloodTypesServices bloodTypesServices) : IAiServices
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;
        private readonly IBloodSevrice _bloodSevrice = bloodSevrice;
        private readonly IBloodBankServices _bloodBankServices = bloodBankServices;
        private readonly IBloodTypesServices _bloodTypeServices = bloodTypesServices;

        private static readonly HashSet<string> Disease = new HashSet<string>
        {
            "Hepatitis B",
            "Thalassemia",
            "Celiac Disease",
            "Rheumatoid Arthritis",
            "Type 1 Diabetes",
            "Multiple Sclerosis",
            "HIV",
            "Cancer",
            "Sickle Cell Disease",
            "Hemochromatosis",
            "Hepatitis C",
            "Lupus"
        };

        private static readonly HashSet<string> Cites = new HashSet<string>
        {
            "Cairo",
            "Giza",
            "Alexandria",
            "Dakahlia",
            "Red Sea",
            "Beheira",
            "Fayoum",
            "Gharbia",
            "Ismailia",
            "Monufia",
            "Minya",
            "Qalyubia",
            "New Valley",
            "Suez",
            "Aswan",
            "Assiut",
            "Beni Suef",
            "Port Said",
            "Damietta",
            "Sharqia",
            "South Sinai",
            "Kafr El Sheikh",
            "Matrouh",
            "Luxor",
            "Qena",
            "North Sinai",
            "Sohag"
        };
        
        private static readonly HashSet<string> BloodTypes = new HashSet<string>
        {
            "O+",
            "O-",
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-"
        };




        public async Task<Result<Recommended>> GetRecommended(RecommendedRequest request)
        {
            if (request == null)
            {
                return Result.Failure<Recommended>(UserErrors.RequiredData);
            }

            if (!Cites.Contains(request.Governorate))
            {
                return Result.Failure<Recommended>(UserErrors.InvalidGovernorate);
            }

            if (!BloodTypes.Contains(request.blood_type))
            {
                return Result.Failure<Recommended>(UserErrors.InvalidBloodType);
            }


            var sendedRequest = new
            {
                governorate = request.Governorate,
                blood_type = request.blood_type,
            };

            var client = _httpClientFactory.CreateClient("RecommendedApi");
            client.Timeout = TimeSpan.FromSeconds(15); 
            try
            {
                var response = await client.PostAsJsonAsync("recommend", sendedRequest);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadFromJsonAsync<List<RecommendedResponse>>() ?? [];

                    var allBanks = _bloodBankServices.GetAll();
                    var allBloodTypes = _bloodTypeServices.GetAll();

                    responseContent = responseContent.Where(item =>
                    {
                        var bank = allBanks.FirstOrDefault(x => x.Name.Equals(item.BloodBankName, StringComparison.OrdinalIgnoreCase));
                        if (bank == null) return false;

                        var bloodType = allBloodTypes.FirstOrDefault(x =>
                            x.Name.Equals(item.BloodType, StringComparison.OrdinalIgnoreCase));
                        if (bloodType == null) return false;

                        var availableBags = _bloodSevrice.GetAllInTypeInBank(bloodType.Id, bank.Id) ?? [];
                        var sum = availableBags.Sum(b => b.Quantity);

                        return sum >= request.Quantity;

                    }).ToList();
                                      

                    if (responseContent.Count == 0)
                    {
                        return Result.Failure<Recommended>(UserErrors.NoData);

                    }
                    return Result.Success((new Recommended
                    {
                        Message = "Request successful",
                        Response = responseContent,
                        Governorate = request.Governorate,
                        BloodType = request.blood_type
                    }));
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();

                    return Result.Failure<Recommended>(new("Ai.ApiCall", "Api Call Failed", (int)response.StatusCode));

                }
            }
            catch (HttpRequestException ex)
            {
                return Result.Failure<Recommended>(new("Ai.Networkerror", ex.Message, 500));

            }
        }





        public async Task<Result<PredictResponse>> GetPredict( DiseaseRequest request)
        {
            if (request?.Diseases == null || !request.Diseases.Any())
            {
                return Result.Failure<PredictResponse>(UserErrors.RequiredData);
            }

            var client = _httpClientFactory.CreateClient("predictApi");
            var tasks = new List<Task<object>>();

            foreach (var disease in request.Diseases)
            {
                tasks.Add(ProcessDiseaseAsync(client, disease, Disease));
            }

            var results = await Task.WhenAll(tasks);

            return Result.Success(new PredictResponse
            {
                TotalItems = request.Diseases.Count,
                Results = results.Select(r => new ResultDto
                {
                    Disease = r.GetType().GetProperty("Disease")?.GetValue(r)?.ToString() ?? "Unknown",
                    Prevalence = (double?)r.GetType().GetProperty("Prevalence")?.GetValue(r),
                    donationStatus = r.GetType().GetProperty("DonationStatus")?.GetValue(r)?.ToString() ?? string.Empty
                }).ToList()
            });

          
        }

        private async Task<object> ProcessDiseaseAsync(HttpClient client, PredictDto disease, HashSet<string> supportedDiseases)
        {
            try
            {
                if (!supportedDiseases.Contains(disease.Disease))
                {
                    return new
                    {
                        Disease = $"Disease {disease.Disease} is not supported",
                        Prevalence = disease.Prevalence,
                    };
                }

                var response = await client.PostAsJsonAsync("predict", disease);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonSerializer.Deserialize<Dictionary<string, string>>(responseContent.Trim());

                return new
                {
                    Disease = disease.Disease,
                    Prevalence = disease.Prevalence,
                    DonationStatus = disease.Prevalence is not null ? jsonResponse?.GetValueOrDefault("donation_status") : null,
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Disease = disease.Disease,
                    Error = ex.Message,
                };
            }
        }


    }
}
