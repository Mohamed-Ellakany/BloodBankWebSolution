using BloodBank.Application.Common.ModelContracts.Auth;
using BloodBank.Application.Common.ModelContracts.BloodBag;
using BloodBank.Application.Common.ModelContracts.BloodBank;
using BloodBank.Application.Common.ModelContracts.City;
using BloodBank.Application.Common.ModelContracts.Community;
using BloodBank.Application.Common.ModelContracts.Donors;
using BloodBank.Application.Common.ModelContracts.Plasma;
using BloodBank.Application.Common.ModelContracts.Plateletses;
using BloodBank.Application.Common.ModelContracts.Users;
using BloodBank.Domain.Entities;
using Mapster;

namespace BloodBank.Api.Mapping
{
    public class MappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

        config.NewConfig<RegisterRequest , ApplicationUser>().Map(dest =>dest.UserName , src=>src.Email).Map(dest=>dest.BloodTypeId ,src=>src.BloodTypeId);

        config.NewConfig<ApplicationUser , UserProfileResponse>().Map(dest => dest.BloodType , src=>src.BloodType.Name);

        config.NewConfig<Donor , DonorResponse>().Map(dest => dest.BloodType , src=>src.BloodType.Name);

        config.NewConfig<BloodBag , BloodBagResponse>()
                .Map(dest => dest.BloodTypeName , src=>src.BloodType.Name) 
                .Map(dest=>dest.BloodBankName ,src=>src.BloodBank.Name)
                .Map(dest =>dest.DonorName , src=>src.Donor.Name);


            config.NewConfig<Plasma, PlasmaResponse>()
                .Map(dest => dest.BloodTypeName, src => src.BloodType.Name)
                .Map(dest => dest.BloodBankName, src => src.BloodBank.Name);

            config.NewConfig<Platelets, PlateletsesResponse>()
                .Map(dest => dest.BloodTypeName, src => src.BloodType.Name)
                .Map(dest => dest.BloodBankName, src => src.BloodBank.Name);


            config.NewConfig<Post, PostResponse>().Map(dest => dest.BloodTypeName, src => src.BloodType.Name);

            config.NewConfig<Post, PostDetailsResponse>().Map(dest => dest.BloodTypeName, src => src.BloodType.Name);

            
        }
    }
}
