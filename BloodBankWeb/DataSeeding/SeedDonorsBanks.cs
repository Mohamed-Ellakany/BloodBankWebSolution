namespace BloodBankWeb.DataSeeding
{
    public static class SeedDonorsBanks
    {
        public static async Task SeedingDonorsBanks(IApplicationDbContext context)
        {
            if (!context.DonorBanks.Any())
            {
                var donorBanks = new List<DonorBank>
                    {
                      new DonorBank { DonorId = 18, BloodBankId = 13 },
                      new DonorBank { DonorId = 18, BloodBankId = 16 },
                      new DonorBank { DonorId = 19, BloodBankId = 16 },
                      new DonorBank { DonorId = 20, BloodBankId = 14 },
                      new DonorBank { DonorId = 20, BloodBankId = 13 },
                      new DonorBank { DonorId = 21, BloodBankId = 18 },
                      new DonorBank { DonorId = 22, BloodBankId = 21 },
                      new DonorBank { DonorId = 23, BloodBankId = 18 },
                      new DonorBank { DonorId = 24, BloodBankId = 19 },
                      new DonorBank { DonorId = 24, BloodBankId = 21 },
                      new DonorBank { DonorId = 25, BloodBankId = 20 },
                      new DonorBank { DonorId = 26, BloodBankId = 17 },
                      new DonorBank { DonorId = 27, BloodBankId = 22 },
                      new DonorBank { DonorId = 28, BloodBankId = 15 },
                      new DonorBank { DonorId = 29, BloodBankId = 22 },
                      new DonorBank { DonorId = 29, BloodBankId = 18 },
                      new DonorBank { DonorId = 30, BloodBankId = 15 },
                      new DonorBank { DonorId = 31, BloodBankId = 17 },
                      new DonorBank { DonorId = 32, BloodBankId = 21 },
                      new DonorBank { DonorId = 32, BloodBankId = 13 },
                      new DonorBank { DonorId = 33, BloodBankId = 15 },
                      new DonorBank { DonorId = 34, BloodBankId = 13 },
                      new DonorBank { DonorId = 35, BloodBankId = 17 },
                      new DonorBank { DonorId = 36, BloodBankId = 18 },
                      new DonorBank { DonorId = 37, BloodBankId = 22 },
                      new DonorBank { DonorId = 20, BloodBankId = 50 },
                      new DonorBank { DonorId = 25, BloodBankId = 75 },
                      new DonorBank { DonorId = 30, BloodBankId = 100},
                      new DonorBank { DonorId = 35, BloodBankId = 150},
                      new DonorBank { DonorId = 37, BloodBankId = 200}
                    };

                context.DonorBanks.AddRange(donorBanks);
                context.SaveChanges();
            }

        }

    }
}
