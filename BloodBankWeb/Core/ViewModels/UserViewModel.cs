using BloodBank.Domain.Consts;

namespace BloodBankWeb.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        
        public string PhoneNumber { get; set; } = string.Empty;

        public string NationalId { get; set; } = string.Empty;

        public string? BloodType { get; set; }
    }
}
