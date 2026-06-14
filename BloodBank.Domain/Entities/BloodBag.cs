
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank.Domain.Entities
{
    public class BloodBag : BaseEntity, IBloodInventoryItem
    {
        public int Id { get; set; }
         

        [ForeignKey("BloodBank")]
        public int BloodBankId { get; set; }

        public BloodBank BloodBank { get; set; } = null!;


        [ForeignKey("BloodType")]
        public int BloodTypeId { get; set; }

        public BloodType BloodType { get; set; } = null!;


        [ForeignKey("Donor")]
        public int DonorId { get; set; }

        public Donor? Donor { get; set; }


    }
}
