
namespace BloodBank.Domain.Entities
{
    public class DonorBank
    {

        public int DonorId { get; set; }

        public Donor? Donor { get; set; } 

        
        public int BloodBankId { get; set; }

        public BloodBank? BloodBank { get; set; } 

    }
}
