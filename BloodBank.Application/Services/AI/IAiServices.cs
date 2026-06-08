using BloodBank.Application.Common.ModelContracts.AI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Services.AI
{
    public interface IAiServices
    {
        Task<Result<Recommended>> GetRecommended(RecommendedRequest request);

        Task<Result<PredictResponse>> GetPredict([FromBody] DiseaseRequest request);
    }
}
