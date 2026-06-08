public static class SeedBloodBags
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        if (await db.BloodBags.AnyAsync()) return;

        var bloodBankIds = Enumerable.Range(1, 202).ToList(); // 13 to 214 inclusive
        var bloodTypeIds = Enumerable.Range(1, 8).ToList();     // 8 to 15 inclusive

        int donorCounter = 1;
        DateTime now = new DateTime(2025, 6, 30); // Hardcoded current date

        var random = new Random();

        foreach (var bankId in bloodBankIds)
        {
            foreach (var bloodTypeId in bloodTypeIds)
            {
                // Ensure donor donated at least 90 days ago
                DateTime donationDate = now.AddDays(-90 - random.Next(5, 15));

                // Ensure blood bag expires in the future (at least 1 day after now)
                DateTime expirationDate = now.AddDays(random.Next(1, 60)); // 1-60 days in the future

                var donor = new Donor
                {
                    Name = $"Donor {donorCounter}",
                    Age = 30,
                    PhoneNum = $"01000000{donorCounter % 10000:0000}",
                    NationalId = $"2980101{donorCounter:000000}",
                    DonationDate = donationDate,
                    CityId = 1,
                    BloodTypeId = bloodTypeId
                };

                db.Donors.Add(donor);
                await db.SaveChangesAsync();

                var donorBank = new DonorBank
                {
                    DonorId = donor.Id,
                    BloodBankId = bankId
                };
                db.DonorBanks.Add(donorBank);

                var bloodBag = new BloodBag
                {
                    BloodBankId = bankId,
                    BloodTypeId = bloodTypeId,
                    DonorId = donor.Id,
                    Quantity = 1,
                    CreationDate = donationDate,
                    ExpirationDate = expirationDate,
                    IsDeleted = false
                };
                db.BloodBags.Add(bloodBag);

                await db.SaveChangesAsync();
                donorCounter++;
            }
        }
    }
}