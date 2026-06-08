using BloodBank.Domain.Entities;

namespace BloodBankWeb.DataSeeding
{
    public static class SeedData
    {
        public static async Task SeedingData(IApplicationDbContext context)
        {
            if (!context.BloodTypes.Any())
            {
               var bloodTypes = new List<BloodType>
                {
                new BloodType {  Name = "O+" },
                new BloodType {  Name = "O-" },
                new BloodType {  Name = "A+" },
                new BloodType {  Name = "A-" },
                new BloodType {  Name = "B+" },
                new BloodType {  Name = "B-" },
                new BloodType {  Name = "AB+" },
                new BloodType {  Name = "AB-" }
            };

                await context.BloodTypes.AddRangeAsync(bloodTypes);
                context.SaveChanges();

            }
        }
    }
}
