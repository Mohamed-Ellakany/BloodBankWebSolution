namespace BloodBank.Domain.Entities
{
    public class Reservation
    {
        public int Id { get; set; }

        public bool IsDonate { get; set; }

        public DateOnly DateOnly { get; set; }

        public TimeOnly TimeOnly { get; set; }

        public int BloodBankId { get; set; }

        public BloodBank BloodBank { get; set; }

        public ApplicationUser ApplicationUser { get; set; } = default!;

        public string ApplicationUserId { get; set; }


    }
}
