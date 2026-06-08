using BloodBank.Domain.Consts;

namespace BloodBankWeb.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }

        public string NationalId { get; set; }

        public string? BloodType { get; set; }
    }
}
