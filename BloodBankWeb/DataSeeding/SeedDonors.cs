//namespace BloodBankWeb.DataSeeding
//{
//    public static class SeedDonors
//    {
//        public static async Task SeedingDonors(IApplicationDbContext context)
//        {
//            if (!context.Donors.Any())
//            {
//                var donors = new List<Donor>
//    {
//        new Donor {
//            Name = "Ahmed Mahmoud",
//            Age = 28,
//            PhoneNum = "01001234567",
//            NationalId = "2990101010101",
//            DonationDate = new DateTime(2023, 1, 15),
//            CityId = 1,
//            BloodTypeId = 8
//        },
//        new Donor {
           
//            Name = "Mohamed Ali",
//            Age = 35,
//            PhoneNum = "01012345678",
//            NationalId = "2880202020202",
//            DonationDate = new DateTime(2023, 2, 20),
//            CityId = 2,
//            BloodTypeId = 9
//        },
//        new Donor {
         
//            Name = "Youssef Ibrahim",
//            Age = 42,
//            PhoneNum = "01023456789",
//            NationalId = "2770303030303",
//            DonationDate = new DateTime(2023, 3, 10),
//            CityId = 3,
//            BloodTypeId = 10
//        },
//        new Donor {
         
//            Name = "Fatima Hassan",
//            Age = 31,
//            PhoneNum = "01034567890",
//            NationalId = "2990404040404",
//            DonationDate = new DateTime(2023, 1, 25),
//            CityId = 4,
//            BloodTypeId = 11
//        },
//        new Donor {
        
//            Name = "Mariam Abdelrahman",
//            Age = 29,
//            PhoneNum = "01045678901",
//            NationalId = "2880505050505",
//            DonationDate = new DateTime(2023, 4, 5),
//            CityId = 5,
//            BloodTypeId = 12
//        },
//        new Donor {
            
//            Name = "Aya Mohamed",
//            Age = 45,
//            PhoneNum = "01056789012",
//            NationalId = "2770606060606",
//            DonationDate = new DateTime(2023, 2, 15),
//            CityId = 6,
//            BloodTypeId = 13
//        },
//        new Donor {
          
//            Name = "Omar Salah",
//            Age = 38,
//            PhoneNum = "01067890123",
//            NationalId = "2990707070707",
//            DonationDate = new DateTime(2023, 5, 20),
//            CityId = 7,
//            BloodTypeId = 14
//        },
//        new Donor {
            
//            Name = "Lina Kamal",
//            Age = 27,
//            PhoneNum = "01078901234",
//            NationalId = "2880808080808",
//            DonationDate = new DateTime(2023, 3, 30),
//            CityId = 8,
//            BloodTypeId = 15
//        },
//        new Donor {
           
//            Name = "Khaled Mostafa",
//            Age = 33,
//            PhoneNum = "01089012345",
//            NationalId = "2770909090909",
//            DonationDate = new DateTime(2023, 4, 10),
//            CityId = 9,
//            BloodTypeId = 8
//        },
//        new Donor {
      
//            Name = "Nour ElDin",
//            Age = 40,
//            PhoneNum = "01090123456",
//            NationalId = "2991010101010",
//            DonationDate = new DateTime(2023, 1, 10),
//            CityId = 10,
//            BloodTypeId = 9
//        },
//        new Donor {
         
//            Name = "Rania Adel",
//            Age = 25,
//            PhoneNum = "01111223344",
//            NationalId = "2881111111111",
//            DonationDate = new DateTime(2023, 5, 15),
//            CityId = 11,
//            BloodTypeId = 10
//        },
//        new Donor {
//            Name = "Hassan Shaker",
//            Age = 36,
//            PhoneNum = "01122334455",
//            NationalId = "2771212121212",
//            DonationDate = new DateTime(2023, 2, 28),
//            CityId = 12,
//            BloodTypeId = 11
//        },
//        new Donor {
//            Name = "Dalia Wael",
//            Age = 44,
//            PhoneNum = "01133445566",
//            NationalId = "2991313131313",
//            DonationDate = new DateTime(2023, 3, 15),
//            CityId = 13,
//            BloodTypeId = 12
//        },
//        new Donor {
//            Name = "Amr Essam",
//            Age = 30,
//            PhoneNum = "01144556677",
//            NationalId = "2881414141414",
//            DonationDate = new DateTime(2023, 4, 20),
//            CityId = 14,
//            BloodTypeId = 13
//        },
//        new Donor {
//            Name = "Samira Nasr",
//            Age = 39,
//            PhoneNum = "01155667788",
//            NationalId = "2771515151515",
//            DonationDate = new DateTime(2023, 5, 5),
//            CityId = 15,
//            BloodTypeId = 14
//        },
//        new Donor {
//            Name = "Tarek Hisham",
//            Age = 26,
//            PhoneNum = "01166778899",
//            NationalId = "2991616161616",
//            DonationDate = new DateTime(2023, 1, 30),
//            CityId = 16,
//            BloodTypeId = 15
//        },
//        new Donor {
//            Name = "Heba Ashraf",
//            Age = 32,
//            PhoneNum = "01177889900",
//            NationalId = "2881717171717",
//            DonationDate = new DateTime(2023, 2, 10),
//            CityId = 17,
//            BloodTypeId = 8
//        },
//        new Donor {
//            Name = "Karim Badr",
//            Age = 41,
//            PhoneNum = "01188990011",
//            NationalId = "2771818181818",
//            DonationDate = new DateTime(2023, 3, 25),
//            CityId = 18,
//            BloodTypeId = 9
//        },
//        new Donor {
//            Name = "Nada Farouk",
//            Age = 37,
//            PhoneNum = "01199001122",
//            NationalId = "2991919191919",
//            DonationDate = new DateTime(2023, 4, 15),
//            CityId = 19,
//            BloodTypeId = 10
//        },
//        new Donor {
//            Name = "Ziad Hamdy",
//            Age = 28,
//            PhoneNum = "01200112233",
//            NationalId = "2882020202020",
//            DonationDate = new DateTime(2023, 5, 30),
//            CityId = 20,
//            BloodTypeId = 11
//        }
//    };
//                context.Donors.AddRange(donors);
//                context.SaveChanges();
//            }

//        }

//    }
//}
