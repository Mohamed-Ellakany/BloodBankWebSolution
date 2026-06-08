
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Domain.Common
{
    public class BaseEntity
    {
        public DateTime ExpirationDate { get; set; } = DateTime.Now.AddDays(60);

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Range(1,2)]
        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }


    }
}
