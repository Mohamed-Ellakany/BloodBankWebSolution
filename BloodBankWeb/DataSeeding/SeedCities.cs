namespace BloodBankWeb.DataSeeding
{
    public static class SeedCities
    {
        public static async Task SeedingCities(IApplicationDbContext context)
        {
            if (!context.Cities.Any())
            {
                var cities = new List<City>
                {
                    new City { Name = "Cairo", Latitude = 30.0444, Longitude = 31.2333 },
                    new City { Name = "Giza", Latitude = 29.9870, Longitude = 31.2088 },
                    new City { Name = "Alexandria", Latitude = 31.2058, Longitude = 29.9245 },
                    new City { Name = "Dakahlia", Latitude = 31.0379, Longitude = 31.3815 },
                    new City { Name = "Red Sea", Latitude = 27.4628, Longitude = 33.4333 },
                    new City { Name = "Beheira", Latitude = 30.7931, Longitude = 30.6135 },
                    new City { Name = "Fayoum", Latitude = 29.1000, Longitude = 30.6833 },
                    new City { Name = "Gharbia", Latitude = 30.8833, Longitude = 30.7500 },
                    new City { Name = "Ismailia", Latitude = 30.9167, Longitude = 32.2500 },
                    new City { Name = "Monufia", Latitude = 30.6833, Longitude = 30.5500 },
                    new City { Name = "Minya", Latitude = 27.4000, Longitude = 30.5333 },
                    new City { Name = "Qalyubia", Latitude = 30.1333, Longitude = 31.3667 },
                    new City { Name = "New Valley", Latitude = 27.0478, Longitude = 29.6056 },
                    new City { Name = "Suez", Latitude = 30.2000, Longitude = 32.5333 },
                    new City { Name = "Aswan", Latitude = 24.0889, Longitude = 32.8998 },
                    new City { Name = "Assiut", Latitude = 27.1801, Longitude = 31.1893 },
                    new City { Name = "Beni Suef", Latitude = 29.0884, Longitude = 31.1191 },
                    new City { Name = "Port Said", Latitude = 31.2608, Longitude = 32.3218 },
                    new City { Name = "Damietta", Latitude = 31.3167, Longitude = 31.7833 },
                    new City { Name = "Sharqia", Latitude = 30.8050, Longitude = 31.8274 },
                    new City { Name = "South Sinai", Latitude = 27.9000, Longitude = 34.0000 },
                    new City { Name = "Kafr El Sheikh", Latitude = 31.1000, Longitude = 30.7167 },
                    new City { Name = "Matrouh", Latitude = 30.6186, Longitude = 27.3935 },
                    new City { Name = "Luxor", Latitude = 25.6872, Longitude = 32.6396 },
                    new City { Name = "Qena", Latitude = 26.1101, Longitude = 31.7756 },
                    new City { Name = "North Sinai", Latitude = 30.8109, Longitude = 33.0000 },
                    new City { Name = "Sohag", Latitude = 26.4972, Longitude = 31.7295 }
                };


                await context.Cities.AddRangeAsync(cities);
                context.SaveChanges();

            }
        }
    }
}
