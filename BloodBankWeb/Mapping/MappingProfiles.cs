
using BloodBank.Application.Common.ModelContracts.City;

namespace BloodBankWeb.Mapping
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {

            //blood bags
            CreateMap<BloodFormViewModel, BloodBag>()
                .ReverseMap();

            CreateMap<BloodBag, BloodViewModel>()
                .ForMember(dest => dest.BloodBank, opt => opt.MapFrom(b => b.BloodBank.Name))
                .ForMember(dest => dest.Donor, opt => opt.MapFrom(b => b.Donor.Name))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(b => b.BloodType.Name));

            //Plasma 
            CreateMap<PlasmaFormViewModel, Plasma>()
                .ReverseMap();

            CreateMap<Plasma, PlasmaViewModel>()
                .ForMember(dest => dest.BloodBank, opt => opt.MapFrom(b => b.BloodBank.Name))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(b => b.BloodType.Name));

            //platelets
            CreateMap<PlateletsFormViewModel, Platelets>()
               .ReverseMap();

            CreateMap<Platelets, PlateletsViewModel>()
                .ForMember(dest => dest.BloodBank, opt => opt.MapFrom(b => b.BloodBank.Name))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(b => b.BloodType.Name));



            //Donors 
            CreateMap<Donor, SelectListItem>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(D => D.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(D => D.Name));

            CreateMap<Donor, DonorViewModel>()
                   .ForMember(dest => dest.BloodType, opt => opt.MapFrom(b => b.BloodType.Name))
                   .ForMember(dest => dest.City, opt => opt.MapFrom(b => b.City.Name))
                   .ForMember(dest => dest.Banks, opt => opt.MapFrom(src => string.Join(", ", src.DonorBanks.Select(b => b.BloodBank!.Name))));



            CreateMap<DonorFormViewModel, Donor>()
              .ReverseMap()
              .ForMember(dest =>dest.BloodBanks , opt =>opt.Ignore());

          
            //Blood Types
            CreateMap<BloodType, SelectListItem>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(D => D.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(D => D.Name));
             
            //Blood Bank
            CreateMap<BloodBank.Domain.Entities.BloodBank, SelectListItem>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(D => D.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(D => D.Name));
              
            //City
            CreateMap<City, SelectListItem>()
             .ForMember(dest => dest.Value, opt => opt.MapFrom(D => D.Id))
             .ForMember(dest => dest.Text, opt => opt.MapFrom(D => D.Name));

            CreateMap<City, CityResponse>();
            CreateMap<CityResponse, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));

            //Users 
            CreateMap<ApplicationUser, UserViewModel>()
               .ForMember(dest => dest.BloodType, opt => opt.MapFrom(b => b.BloodType.Name));

            CreateMap<ApplicationUser,UserFormViewModel>()
                 .ForMember(dest => dest.SelectedBloodType, opt => opt.MapFrom(  b => b.BloodType.Id))
                 .ReverseMap() ;


            //Reservation 
            CreateMap<Reservation, ReservationViewModel>()
               .ForMember(dest => dest.ApplicationUser, opt => opt.MapFrom(b=>b.ApplicationUser.FullName))
               .ForMember(dest => dest.BloodBankName, opt => opt.MapFrom(b=>b.BloodBank.Name));


           
        }

    }
}
