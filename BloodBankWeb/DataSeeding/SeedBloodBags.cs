public static class SeedBloodBags
{
    public static async Task SeedAsync(ApplicationDbContext db)
    {
        if (await db.BloodBags.AnyAsync()) return;

        var bloodBankIds = await db.BloodBanks
            .AsNoTracking()
            .Select(bank => bank.Id)
            .ToListAsync();

        var bloodTypeIds = await db.BloodTypes
            .AsNoTracking()
            .Select(type => type.Id)
            .ToListAsync();

        if (bloodBankIds.Count == 0 || bloodTypeIds.Count == 0)
            return;

        int donorCounter = 1;
        DateTime now = new DateTime(2025, 6, 30);

        var random = new Random();
        var donors = new List<Donor>();
        var bloodBags = new List<BloodBag>();

        foreach (var bankId in bloodBankIds)
        {
            foreach (var bloodTypeId in bloodTypeIds)
            {
                DateTime donationDate = now.AddDays(-90 - random.Next(5, 15));
                DateTime expirationDate = now.AddDays(random.Next(1, 60));

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

                donor.DonorBanks.Add(new DonorBank
                {
                    Donor = donor,
                    BloodBankId = bankId
                });

                bloodBags.Add(new BloodBag
                {
                    BloodBankId = bankId,
                    BloodTypeId = bloodTypeId,
                    Donor = donor,
                    Quantity = 1,
                    CreationDate = donationDate,
                    ExpirationDate = expirationDate,
                    IsDeleted = false
                });

                donors.Add(donor);
                donorCounter++;
            }
        }

        await db.Donors.AddRangeAsync(donors);
        await db.BloodBags.AddRangeAsync(bloodBags);
        await db.SaveChangesAsync();
    }
}
