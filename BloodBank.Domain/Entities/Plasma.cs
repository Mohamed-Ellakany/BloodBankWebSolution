using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank.Domain.Entities
{
    public class Plasma : BaseEntity, IBloodInventoryItem
    {
        public int Id { get; set; }

        [ForeignKey("BloodBank")]
        public int BloodBankId { get; set; }

        public BloodBank BloodBank { get; set; } = null!;

        [ForeignKey("BloodType")]
        public int BloodTypeId { get; set; }

        public BloodType BloodType { get; set; } = null!;

        
    }
}
