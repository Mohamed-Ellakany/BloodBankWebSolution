namespace BloodBankWeb.DataSeeding;

using BloodBank = BloodBank.Domain.Entities.BloodBank;

public class SeedBloodBanks
{
    public static async Task SeedingBloodBanks(IApplicationDbContext context)
    {
        if (!context.BloodBanks.Any())
        {
            var bloodBanks = new List<BloodBank>
            {
             

            new BloodBank
            {
                Name = "Shubra General Hospital Blood Bank",
                Address = "76 Hospital Street - Shubra (Inside Shubra General Hospital - Kitchener)",
                PhoneNum = "022352325",
                Email = "shubra.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Al-Munira General Hospital Blood Bank",
                Address = "2 Nubar Al-Sayeda Street (Inside Al-Munira General Hospital)",
                PhoneNum = "023910230",
                Email = "munira.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Manshiet El-Bakri General Hospital Blood Bank",
                Address = "Suez Bridge Street (Inside Manshiet El-Bakri General Hospital)",
                PhoneNum = "022580946",
                Email = "bakri.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Dar Al-Salam Central Hospital Blood Bank",
                Address = "987 Nile Corniche Street - King Al-Saleh (Inside Dar Al-Salam General Hospital - Harmal)",
                PhoneNum = "022367769",
                Email = "darsalam.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Al-Khazindara General Hospital Blood Bank",
                Address = "3 Shaiban Street - Shubra (Inside Al-Khazindara General Hospital)",
                PhoneNum = "022057593",
                Email = "khazindara.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Bulaq General Hospital Blood Bank",
                Address = "National Press Street - Al-Sabta (Inside Bulaq Al-Dakrour General Hospital)",
                PhoneNum = "025755211",
                Email = "bulaq.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Chest Hospital Al-Abbasiya Blood Bank",
                Address = "White Railway Street - Al-Abbasiya (Inside Chest Hospital Al-Abbasiya)",
                PhoneNum = "023425248",
                Email = "chest.abbasiya@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Al-Zawiya Al-Hamra General Hospital Blood Bank",
                Address = "Hospital Street next to Al-Zawiya Youth Center (Inside Al-Zawiya General Hospital)",
                PhoneNum = "024248004",
                Email = "zawiya.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Helwan General Hospital Blood Bank",
                Address = "Fayd Street behind Japanese Garden (Inside Helwan General Hospital)",
                PhoneNum = "025564492",
                Email = "helwan.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Fever Hospital Al-Abbasiya Blood Bank",
                Address = "Ramses Extension Street - Al-Abbasiya (Inside Fever Hospital Al-Abbasiya)",
                PhoneNum = "023425126",
                Email = "fever.abbasiya@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Sheikh Zayed Manshiet Nasser Hospital Blood Bank",
                Address = "Manshiet Nasser - Highway Road (Inside Sheikh Zayed Al Nahyan General Hospital)",
                PhoneNum = "038502523",
                Email = "zayed.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "New Cairo Blood Bank",
                Address = "New Cairo",
                PhoneNum = "027594306",
                Email = "newcairo.bloodbank@hospital.gov.eg",
                CityId = 1 // Cairo
            },
            new BloodBank
            {
                Name = "Um Al-Masryeen Blood Bank",
                Address = "Rabee Al-Gizawi Street, Um Al-Masryeen Square",
                PhoneNum = "035733898",
                Email = "ummasryeen.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Imbaba General Hospital Blood Bank",
                Address = "Mahmoud Rahmi Street (formerly Al-Thabet) next to Heart Institute",
                PhoneNum = "033040116",
                Email = "imbaba.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Bulaq Al-Dakrour General Hospital Blood Bank",
                Address = "Terat Al-Zamar Street next to Bulaq Al-Dakrour Police Station",
                PhoneNum = "037345455",
                Email = "bulaqdakrour.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Al-Hawamdiya General Hospital Blood Bank",
                Address = "Cairo-Assiut Road, Al-Hawamdiya City - Giza",
                PhoneNum = "038114164",
                Email = "hawamdiya.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Chest Hospital Giza Blood Bank",
                Address = "Terat Al-Zamar Street, Western Urban",
                PhoneNum = "035610380",
                Email = "chest.giza@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Al-Tahrir General Hospital Imbaba Blood Bank",
                Address = "Nasouh Pasha Street next to Amiriya Printing House, Imbaba",
                PhoneNum = "037110046",
                Email = "tahrir.imbaba@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Al-Badrashein Central Hospital Blood Bank",
                Address = "Al-Badrashein - Cairo-Assiut Express Street",
                PhoneNum = "038020526",
                Email = "badrashein.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Al-Ayat Central Hospital Blood Bank",
                Address = "Al-Ayat Army Street, Cairo-Assiut Agricultural Road - Giza",
                PhoneNum = "038606443",
                Email = "ayat.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Ausim Central Hospital Blood Bank",
                Address = "Caliph Al-Mamoun Street - Ausim - Giza",
                PhoneNum = "038709724",
                Email = "ausim.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Abu Al-Numrus Central Hospital Blood Bank",
                Address = "Abu Al-Numrus City, Giza Governorate",
                PhoneNum = "038091789",
                Email = "abunumrus.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Al-Saff Blood Bank",
                Address = "Al-Saff City, Giza",
                PhoneNum = "038622086",
                Email = "saff.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "6th of October Blood Bank",
                Address = "Vodafone Square, 6th of October City",
                PhoneNum = "038322180",
                Email = "october.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Atfih Blood Bank",
                Address = "Atfih Center, Giza",
                PhoneNum = "038412301",
                Email = "atfih.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Bahariya Oasis Blood Bank",
                Address = "Al-Bawiti, Bahariya Oasis",
                PhoneNum = "038470122",
                Email = "bahariya.bloodbank@hospital.gov.eg",
                CityId = 2 // Giza
            },
            new BloodBank
            {
                Name = "Shubra Al-Kheima General Hospital Blood Bank",
                Address = "Nasser General Hospital Street behind Crystal Asfour, Shubra Al-Kheima",
                PhoneNum = "042201743",
                Email = "shubralkheima.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Toukh Central Hospital Blood Bank",
                Address = "Next to Toukh, Cairo-Alexandria Agricultural Road",
                PhoneNum = "0132460131",
                Email = "toukh.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Kafr Shukr Central Hospital Blood Bank",
                Address = "Qalyubia-Mansoura Agricultural Road",
                PhoneNum = "0132520057",
                Email = "kafrshukr.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {

                Name = "Qalyub Central Hospital Blood Bank",
                Address = "10th of Ramadan Street next to Qalyub Station",
                PhoneNum = "0132520057",
                Email = "qalyub.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Al-Qanater Al-Khayriya Central Hospital Blood Bank",
                Address = "Tourist Division at Al-Qanater next to City Council",
                PhoneNum = "042188750",
                Email = "qanater.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Shibin Al-Qanater Central Hospital Blood Bank",
                Address = "Ezbet Al-Wukala",
                PhoneNum = "0132720011",
                Email = "shibinqanater.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Al-Khanka Central Hospital Blood Bank",
                Address = "Station Street, Al-Khanka",
                PhoneNum = "044698987",
                Email = "khanka.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Qaha Central Hospital Blood Bank",
                Address = "Qaha City next to Qaha City Council, City Council Street",
                PhoneNum = "0132601049",
                Email = "qaha.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Bahtim Central Hospital Blood Bank",
                Address = "135 Bahtim Public Street behind Electricity Station, East Shubra Al-Kheima District",
                PhoneNum = "048241726",
                Email = "bahtim.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Abu Al-Manja Blood Bank",
                Address = "First Al-Qanater Road next to Yassin Factory",
                PhoneNum = "044449335",
                Email = "abumanja.bloodbank@hospital.gov.eg",
                CityId = 12 // Qalyubia
            },
            new BloodBank
            {
                Name = "Abu Qir Blood Bank",
                Address = "Abu Qir Town",
                PhoneNum = "035624444",
                Email = "abuqir.bloodbank@hospital.gov.eg",
                CityId = 3 // Alexandria
            },
            new BloodBank
            {
                Name = "Borg Al-Arab Blood Bank",
                Address = "New Borg Al-Arab opposite Police Station",
                PhoneNum = "034595036",
                Email = "borgarab.bloodbank@hospital.gov.eg",
                CityId = 3 // Alexandria
            },
            new BloodBank
            {
                Name = "Al-Amiriya Central Hospital Blood Bank",
                Address = "Alexandria Al-Amiriya, Al-Hajj Sharqawi Street",
                PhoneNum = "034480013",
                Email = "amiriya.bloodbank@hospital.gov.eg",
                CityId = 3 // Alexandria
            },
            new BloodBank
            {
                Name = "Dar Ismail Blood Bank",
                Address = "Alexandria",
                PhoneNum = "033612806",
                Email = "darismail.bloodbank@hospital.gov.eg",
                CityId = 3 // Alexandria
            },
            new BloodBank
            {
                Name = "Fever Hospital Alexandria Blood Bank",
                Address = "Ambrozo - Al-Hadra",
                PhoneNum = "034290970",
                Email = "fever.alexandria@hospital.gov.eg",
                CityId = 3 // Alexandria
            },
            new BloodBank
            {
                Name = "Ras Al-Tin Blood Bank",
                Address = "Ras Al-Tin Palace Street next to Al-Anfushi Cultural Palace",
                PhoneNum = "034860574",
                Email = "rasaltin.bloodbank@hospital.gov.eg",
                CityId = 3 // Alexandria
            },
            new BloodBank
            {
                Name = "Al-Gomhouriya Blood Bank",
                Address = "Mahmoudiya Canal Street opposite Ragheb Bridge",
                PhoneNum = "033624238",
                Email = "gomhouriya.bloodbank@hospital.gov.eg",
                CityId = 3 // Alexandria
            },
            new BloodBank
            {
                Name = "Al-Manshawi General Hospital Blood Bank",
                Address = "Tanta, Al-Takya Street",
                PhoneNum = "0403313280",
                Email = "manshawi.bloodbank@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Mahalla Al-Kubra General Hospital Blood Bank",
                Address = "Mahalla Al-Kubra, 6th of October Street",
                PhoneNum = "0402223181",
                Email = "mahalla.bloodbank@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Zifta General Hospital Blood Bank",
                Address = "Zifta, Army Street next to Zifta Traffic",
                PhoneNum = "0405703065",
                Email = "zifta.bloodbank@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Samannoud Central Hospital Blood Bank",
                Address = "Samannoud Hospital",
                PhoneNum = "0402971989",
                Email = "samannoud.bloodbank@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Kafr Al-Zayat Blood Bank",
                Address = "Kafr Al-Zayat",
                PhoneNum = "0402534025",
                Email = "kafrzayat.bloodbank@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Al-Santa Central Hospital Blood Bank",
                Address = "Al-Santa",
                PhoneNum = "0405476645",
                Email = "santa.bloodbank@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Qutur Central Hospital Blood Bank",
                Address = "Qutur, Army Street, Tanta-Kafr Al-Sheikh Road (formerly)",
                PhoneNum = "0402766689",
                Email = "qutur.bloodbank@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Basion Central Hospital Blood Bank",
                Address = "Basion, 23rd of July Street near Insurance Administration",
                PhoneNum = "0402732875",
                Email = "basion.bloodbank@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Chest Hospital Mahalla Al-Kubra Blood Bank",
                Address = "Mahalla Al-Kubra, 6th of October Street",
                PhoneNum = "0402420068",
                Email = "chest.mahalla@hospital.gov.eg",
                CityId = 8 // Gharbia
            },
            new BloodBank
            {
                Name = "Belbeis Central Hospital Blood Bank",
                Address = "Belbeis",
                PhoneNum = "0552848304",
                Email = "belbeis.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Faqous Central Hospital Blood Bank",
                Address = "Faqous",
                PhoneNum = "0553972760",
                Email = "faqous.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Abu Hammad Central Hospital Blood Bank",
                Address = "Abu Hammad",
                PhoneNum = "0553417782",
                Email = "abuhammad.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Minya Al-Qamh Blood Bank",
                Address = "Gamal Abdel Nasser Street, Minya Al-Qamh next to Gamal Abdel Nasser Secondary School",
                PhoneNum = "0553668400",
                Email = "minyaqamh.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Abu Kabir Central Hospital Blood Bank",
                Address = "Abu Kabir Center",
                PhoneNum = "0552303745",
                Email = "abukabir.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Mashtool Al-Souq Hospital Blood Bank",
                Address = "Al-Madina Al-Munawara Street next to National Bank of Egypt",
                PhoneNum = "0552573323",
                Email = "mashtool.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Kafr Saqr Central Hospital Blood Bank",
                Address = "Kafr Saqr Center",
                PhoneNum = "0553186088",
                Email = "kafrsaqr.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Deirb Negm Central Hospital Blood Bank",
                Address = "Deirb Negm Center",
                PhoneNum = "0553769623",
                Email = "deirbnegm.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Hehia Central Hospital Blood Bank",
                Address = "Hehia Center",
                PhoneNum = "0552564363",
                Email = "hehia.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Al-Zawamel Central Hospital Blood Bank",
                Address = "Al-Zawamel Center",
                PhoneNum = "0552820113",
                Email = "zawamel.bloodbank@hospital.gov.eg",
                CityId = 20 // Sharqia
            },
            new BloodBank
            {
                Name = "Kafr Al-Dawar Central Hospital Blood Bank",
                Address = "Before the Upper Bridge, Kafr Al-Dawar",
                PhoneNum = "0452212186",
                Email = "kafrdawar.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Itay Al-Baroud Central Hospital Blood Bank",
                Address = "Al-Gomhouriya Street - Itay Al-Baroud",
                PhoneNum = "0453432386",
                Email = "itaybaroud.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Al-Mahmoudiya Central Hospital Blood Bank",
                Address = "Al-Mahmoudiya City",
                PhoneNum = "0452505250",
                Email = "mahmoudiya.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Kom Hamada Central Hospital Blood Bank",
                Address = "Kom Hamada Center - Al-Thawra Street",
                PhoneNum = "0453686673",
                Email = "komhamada.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Rashid Central Hospital Blood Bank",
                Address = "Rashid, Al-Bahr Street",
                PhoneNum = "0452920404",
                Email = "rashid.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Abu Homs General Hospital Blood Bank",
                Address = "Abu Homs - Al-Bahr Street",
                PhoneNum = "0452560130",
                Email = "abuhoms.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Wadi Al-Natrun Central Hospital Blood Bank",
                Address = "Wadi Al-Natrun - Cairo-Alexandria Desert Road - KM 108",
                PhoneNum = "0453551903",
                Email = "wadinatrun.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Al-Delengat Central Hospital Blood Bank",
                Address = "Al-Delengat - Al-Delengat Damanhour Road",
                PhoneNum = "0453606319",
                Email = "delengat.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Abu Al-Matamir Central Hospital Blood Bank",
                Address = "Abu Al-Matamir, Al-Markaz Street",
                PhoneNum = "0452403335",
                Email = "abumatamir.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Badr Al-Tahrir Central Hospital Blood Bank",
                Address = "Badr Center - South Liberation - Beheira",
                PhoneNum = "0453620335",
                Email = "badrtahrir.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Al-Rahmaniya Blood Bank",
                Address = "Al-Rahmaniya, Beheira",
                PhoneNum = "0452850814",
                Email = "rahmaniya.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Shibra Khit Blood Bank",
                Address = "Shibra Khit, Mahmoud Abu Shalou Street",
                PhoneNum = "0453805363",
                Email = "shibrakhit.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Edku Blood Bank",
                Address = "Edku, Al-Sayed Abdel Galil Street",
                PhoneNum = "0452916037",
                Email = "edku.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {
                Name = "Housh Issa Blood Bank",
                Address = "Al-Gomhouriya Street - Housh Issa - Beheira",
                PhoneNum = "0452703927",
                Email = "houshissa.bloodbank@hospital.gov.eg",
                CityId = 6 // Beheira
            },
            new BloodBank
            {

                Name = "Matrouh General Hospital Blood Bank",
                Address = "First Alexandria Street, Matrouh City",
                PhoneNum = "0464939494",
                Email = "matrouh.bloodbank@hospital.gov.eg",
                CityId = 23 // Matrouh
            },
            new BloodBank
            {
                Name = "Ras Al-Hekma Blood Bank",
                Address = "Matrouh-Alexandria Road KM 67",
                PhoneNum = "0464500063",
                Email = "rashekma.bloodbank@hospital.gov.eg",
                CityId = 23 // Matrouh
            },
            new BloodBank
            {
                Name = "Siwa Blood Bank",
                Address = "Next to Olympic Village, Siwa City",
                PhoneNum = "0464600459",
                Email = "siwa.bloodbank@hospital.gov.eg",
                CityId = 23 // Matrouh
            },
            new BloodBank
            {
                Name = "Sidi Barrani Blood Bank",
                Address = "Barrani City",
                PhoneNum = "0464400070",
                Email = "sidibarrani.bloodbank@hospital.gov.eg",
                CityId = 23 // Matrouh
            },
            new BloodBank
            {
                Name = "El Alamein Blood Bank",
                Address = "KM 100 Alexandria-Matrouh Road",
                PhoneNum = "0464100212",
                Email = "alamein.bloodbank@hospital.gov.eg",
                CityId = 23 // Matrouh
            },
            new BloodBank
            {
                Name = "Salloum Blood Bank",
                Address = "Next to Egyptian National Bank, Salloum City",
                PhoneNum = "0464800020",
                Email = "salloum.bloodbank@hospital.gov.eg",
                CityId = 23 // Matrouh
            },
            new BloodBank
            {
                Name = "Hamam Central Blood Bank",
                Address = "First Alexandria Street, Hamam City",
                PhoneNum = "0464750844",
                Email = "hamam.bloodbank@hospital.gov.eg",
                CityId = 23 // Matrouh
            },
            new BloodBank
            {
                Name = "Bella Central Blood Bank",
                Address = "Hospital Street, Next to Agricultural Reform, Intersection of Revolution Street",
                PhoneNum = "0473605661",
                Email = "bella.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {
                Name = "Qellin Central Blood Bank",
                Address = "Qellin Central",
                PhoneNum = "0473400482",
                Email = "qellin.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {

                Name = "Baltim Central Blood Bank",
                Address = "Baltim Central",
                PhoneNum = "0472510860",
                Email = "baltim.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {
                Name = "Desouk Central Blood Bank",
                Address = "Desouk General Hospital",
                PhoneNum = "0472563550",
                Email = "desouk.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {

                Name = "Matobas Central Blood Bank",
                Address = "Matobas Central",
                PhoneNum = "0472710821",
                Email = "matobas.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {

                Name = "Riyadh Central Blood Bank",
                Address = "Riyadh Central",
                PhoneNum = "0473810415",
                Email = "riyadh.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {

                Name = "Sidi Salem Central Blood Bank",
                Address = "Sidi Salem Central",
                PhoneNum = "0472706938",
                Email = "sidisalem.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {

                Name = "Kafr El Sheikh General Blood Bank",
                Address = "Kafr El Sheikh Hospital, Next to Awqaf Buildings",
                PhoneNum = "0473232698",
                Email = "kafrelsheikh.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {

                Name = "Fowa Central Blood Bank",
                Address = "Fowa Central",
                PhoneNum = "0472976777",
                Email = "fowa.bloodbank@hospital.gov.eg",
                CityId = 22 // Kafr El Sheikh
            },
            new BloodBank
            {

                Name = "Damietta Main Blood Bank",
                Address = "Nile Corniche Street, Damietta Specialized Hospital",
                PhoneNum = "0572332096",
                Email = "damietta.main.bloodbank@hospital.gov.eg",
                CityId = 19 // Damietta
            },
            new BloodBank
            {

                Name = "Kafr Saad Blood Bank",
                Address = "Fast Road Mansoura-Damietta, Next to Oil and Soap Factory",
                PhoneNum = "0573602633",
                Email = "kafrsaad.bloodbank@hospital.gov.eg",
                CityId = 19 // Damietta
            },
            new BloodBank
            {
                Name = "Damietta General Blood Bank",
                Address = "Nile Corniche Street, In front of Governorate Building",
                PhoneNum = "0572224340",
                Email = "damietta.general.bloodbank@hospital.gov.eg",
                CityId = 19 // Damietta
            },
            new BloodBank
            {
                Name = "Faraskour Central Blood Bank",
                Address = "Rice Mill Street, Next to Faraskour Police Station",
                PhoneNum = "0573442354",
                Email = "faraskour.bloodbank@hospital.gov.eg",
                CityId = 19 // Damietta
            },
            new BloodBank
            {

                Name = "Zarqa Blood Bank",
                Address = "Revolution Street, Zarqa Hospital",
                PhoneNum = "0573858567",
                Email = "zarqa.bloodbank@hospital.gov.eg",
                CityId = 19 // Damietta
            },
            new BloodBank
            {
                Name = "Dakhla Central Blood Bank",
                Address = "Gamal Abdel Nasser Street, Mut City",
                PhoneNum = "0927821555",
                Email = "dakhla.bloodbank@hospital.gov.eg",
                CityId = 13 // New Valley
            },
            new BloodBank
            {

                Name = "Farafra Blood Bank",
                Address = "Farafra Center and City, Next to Local Unit",
                PhoneNum = "0927510047",
                Email = "farafra.bloodbank@hospital.gov.eg",
                CityId = 13 // New Valley
            },
            new BloodBank
            {

                Name = "Hurghada Blood Bank",
                Address = "Hospital Street, Next to Shadwan Village",
                PhoneNum = "0653546841",
                Email = "hurghada.bloodbank@hospital.gov.eg",
                CityId = 5 // Red Sea
            },
            new BloodBank
            {
                Name = "Ras Ghareb Blood Bank",
                Address = "Ras Ghareb, Next to Central Station",
                PhoneNum = "0653624650",
                Email = "rasghareb.bloodbank@hospital.gov.eg",
                CityId = 5 // Red Sea
            },
            new BloodBank
            {
                Name = "Qusayr Central Blood Bank",
                Address = "Qusayr, Hospital Street",
                PhoneNum = "0653330070",
                Email = "qusayr.bloodbank@hospital.gov.eg",
                CityId = 5 // Red Sea
            },
            new BloodBank
            {

                Name = "Safaga Blood Bank",
                Address = "Safaga, City Council Street",
                PhoneNum = "0653251549",
                Email = "safaga.bloodbank@hospital.gov.eg",
                CityId = 5 // Red Sea
            },
            new BloodBank
            {

                Name = "Arish General Blood Bank",
                Address = "Army Street, In front of Old Electricity Station",
                PhoneNum = "0683352938",
                Email = "arish.bloodbank@hospital.gov.eg",
                CityId = 26 // North Sinai
            },
            new BloodBank
            {

                Name = "Rafah Blood Bank",
                Address = "Safa District, In front of Central Security Sector",
                PhoneNum = "0683500459",
                Email = "rafah.bloodbank@hospital.gov.eg",
                CityId = 26 // North Sinai
            },
            new BloodBank
            {

                Name = "Sheikh Zowayed Blood Bank",
                Address = "Kawthar District, Sheikh Zowayed",
                PhoneNum = "0683500323",
                Email = "sheikhzowayed.bloodbank@hospital.gov.eg",
                CityId = 26 // North Sinai
            },
            new BloodBank
            {

                Name = "Bir Al-Abd Blood Bank",
                Address = "Main Street, Rafah-Qantara Road",
                PhoneNum = "0683540005",
                Email = "birabd.bloodbank@hospital.gov.eg",
                CityId = 26 // North Sinai
            },
            new BloodBank
            {

                Name = "Tor Sinai Blood Bank",
                Address = "Taba Street, Tor Sinai, In front of East Delta Bus Station",
                PhoneNum = "0693770320",
                Email = "torsinai.bloodbank@hospital.gov.eg",
                CityId = 21 // South Sinai
            },
            new BloodBank
            {

                Name = "Nuweiba Blood Bank",
                Address = "Nuweiba City, In front of Nuweiba Youth Center",
                PhoneNum = "0693500302",
                Email = "nuweiba.bloodbank@hospital.gov.eg",
                CityId = 21 // South Sinai
            },
            new BloodBank
            {

                Name = "Dahab Blood Bank",
                Address = "Next to City Council",
                PhoneNum = "0693640208",
                Email = "dahab.bloodbank@hospital.gov.eg",
                CityId = 21 // South Sinai
            },
            new BloodBank
            {

                Name = "Ras Sedr Blood Bank",
                Address = "Chalets Street",
                PhoneNum = "0693400214",
                Email = "rassedr.bloodbank@hospital.gov.eg",
                CityId = 21 // South Sinai
            },
            new BloodBank
            {

                Name = "Port Fouad General Blood Bank",
                Address = "Al-Abour Area, Port Said",
                PhoneNum = "0663400848",
                Email = "portfouad.bloodbank@hospital.gov.eg",
                CityId = 18 // Port Said
            },
            new BloodBank
            {

                Name = "Port Said General Blood Bank",
                Address = "Intersection of Safiya Zaghloul and Martyr Mohsen Al-Sayed",
                PhoneNum = "0663237231",
                Email = "portsaid.general.bloodbank@hospital.gov.eg",
                CityId = 18 // Port Said
            },
            new BloodBank
            {

                Name = "Port Said Main Blood Bank",
                Address = "Safiya Zaghloul Street, Next to Laboratory Complex",
                PhoneNum = "0663221605",
                Email = "portsaid.main.bloodbank@hospital.gov.eg",
                CityId = 18 // Port Said
            },
            new BloodBank
            {

                Name = "Nasr Blood Bank",
                Address = "Intersection of Abdel Hadi Al-Hariri, Nasr Road",
                PhoneNum = "0663230587",
                Email = "nasr.bloodbank@hospital.gov.eg",
                CityId = 18 // Port Said
            },
            new BloodBank
            {
                Name = "Tell Al-Kabir Central Blood Bank",
                Address = "Tell Al-Kabir City, Ahmed Orabi Street",
                PhoneNum = "0643961636",
                Email = "tellkabir.bloodbank@hospital.gov.eg",
                CityId = 9 // Ismailia
            },
            new BloodBank
            {
                Name = "Qantara West Blood Bank",
                Address = "Qantara West City, Next to Water Station",
                PhoneNum = "0643561029",
                Email = "qantarawest.bloodbank@hospital.gov.eg",
                CityId = 9 // Ismailia
            },
            new BloodBank
            {

                Name = "Qassassin Central Blood Bank",
                Address = "Qassassin City, Next to Electricity Station",
                PhoneNum = "0643440021",
                Email = "qassassin.bloodbank@hospital.gov.eg",
                CityId = 9 // Ismailia
            },
            new BloodBank
            {
                Name = "Fayed Central Blood Bank",
                Address = "Fayed City, Next to City Council",
                PhoneNum = "0643661038",
                Email = "fayed.bloodbank@hospital.gov.eg",
                CityId = 9 // Ismailia
            },
            new BloodBank
            {
                Name = "Ismailia General Blood Bank",
                Address = "Seventh Phase, Ring Road",
                PhoneNum = "0643213914",
                Email = "ismailia.bloodbank@hospital.gov.eg",
                CityId = 9 // Ismailia
            },
            new BloodBank
            {
                Name = "Suez General Blood Bank",
                Address = "Salah El Din Street, Suez General Hospital",
                PhoneNum = "0623331190",
                Email = "suez.bloodbank@hospital.gov.eg",
                CityId = 14 // Suez
            },
            new BloodBank
            {
                Name = "Fayoum General Blood Bank",
                Address = "Nabawi Al-Mohandes Al-Masalla Hospital",
                PhoneNum = "0846333122",
                Email = "fayoum.bloodbank@hospital.gov.eg",
                CityId = 7 // Fayoum
            },
            new BloodBank
            {
                Name = "Sennouris Central Blood Bank",
                Address = "Sennouris City",
                PhoneNum = "0846900808",
                Email = "sennouris.bloodbank@hospital.gov.eg",
                CityId = 7 // Fayoum
            },
            new BloodBank
            {
                Name = "Abshway Central Blood Bank",
                Address = "Abshway City",
                PhoneNum = "0846719574",
                Email = "abshway.bloodbank@hospital.gov.eg",
                CityId = 7 // Fayoum
            },
            new BloodBank
            {
                Name = "Tamiya Central Blood Bank",
                Address = "Tamiya City",
                PhoneNum = "0846610715",
                Email = "tamiya.bloodbank@hospital.gov.eg",
                CityId = 7 // Fayoum
            },
            new BloodBank
            {
                Name = "Etsa Central Blood Bank",
                Address = "Etsa City",
                PhoneNum = "0846410612",
                Email = "etsa.bloodbank@hospital.gov.eg",
                CityId = 7 // Fayoum
            },
            new BloodBank
            {
                Name = "Beni Suef General Blood Bank",
                Address = "Beni Suef City, Nile Corniche Street",
                PhoneNum = "0822323243",
                Email = "benisuef.bloodbank@hospital.gov.eg",
                CityId = 17 // Beni Suef
            },
            new BloodBank
            {
                Name = "Fashn Central Blood Bank",
                Address = "Beni Suef, Fashn City, Hospital Street",
                PhoneNum = "0827660548",
                Email = "fashn.bloodbank@hospital.gov.eg",
                CityId = 17 // Beni Suef
            },
            new BloodBank
            {
                Name = "Wasta Central Blood Bank",
                Address = "Beni Suef, Wasta City, Ahmed Orabi Street",
                PhoneNum = "0822517789",
                Email = "wasta.bloodbank@hospital.gov.eg",
                CityId = 17 // Beni Suef
            },
            new BloodBank
            {
                Name = "Nasser Central Blood Bank",
                Address = "Beni Suef, Nasser City, Gamal Abdel Nasser Street, In front of National Bank of Egypt",
                PhoneNum = "0825827950",
                Email = "nasser.bloodbank@hospital.gov.eg",
                CityId = 17 // Beni Suef
            },
            new BloodBank
            {
                Name = "Ihnasya Central Blood Bank",
                Address = "Beni Suef, Ihnasya City, Hospital Street",
                PhoneNum = "0825725888",
                Email = "ihnasya.bloodbank@hospital.gov.eg",
                CityId = 17 // Beni Suef
            },
            new BloodBank
            {
                Name = "Beba Central Blood Bank",
                Address = "Beni Suef, Hospital Street, In front of Religious Institute",
                PhoneNum = "0824400929",
                Email = "beba.bloodbank@hospital.gov.eg",
                CityId = 17 // Beni Suef
            },
            new BloodBank
            {
                Name = "Sumusta Central Blood Bank",
                Address = "Beni Suef, Sumusta, Hospital Street, Next to First Aid Pharmacy",
                PhoneNum = "0827606284",
                Email = "sumusta.bloodbank@hospital.gov.eg",
                CityId = 17 // Beni Suef
            },
            new BloodBank
            {
                Name = "Assiut General Blood Bank",
                Address = "Al-Majzoub Square, Assiut",
                PhoneNum = "0882338210",
                Email = "assiut.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Iman General Blood Bank",
                Address = "Ring Road, Al-Arbaeen, Assiut",
                PhoneNum = "0882332671",
                Email = "iman.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Dairout Central Blood Bank",
                Address = "Port Said Street, Dairout, Assiut",
                PhoneNum = "0884784800",
                Email = "dairout.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Qusiya Central Blood Bank",
                Address = "Hospital Street, Qusiya",
                PhoneNum = "0884751722",
                Email = "qusiya.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Manfalout Central Blood Bank",
                Address = "Gamal Abdel Nasser Street, Assiut",
                PhoneNum = "0884709805",
                Email = "manfalout.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Abu Tig Central Blood Bank",
                Address = "Al-Jalaa Street, Next to Court",
                PhoneNum = "0882480777",
                Email = "abutig.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Sidfa Central Blood Bank",
                Address = "Army Street, Sidfa",
                PhoneNum = "0882670777",
                Email = "sidfa.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Abnoub Central Blood Bank",
                Address = "Port Said Street, Abnoub",
                PhoneNum = "0882507116",
                Email = "abnoub.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Ghanaim Central Blood Bank",
                Address = "Northern Republic Street",
                PhoneNum = "0882650045",
                Email = "ghanaim.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Badari Central Blood Bank",
                Address = "Dawawin Street, Badari",
                PhoneNum = "0882608111",
                Email = "badari.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Sahel Selim Central Blood Bank",
                Address = "23 July Street, Sahel Selim",
                PhoneNum = "0882631888",
                Email = "sahelselim.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Women and Maternity Blood Bank",
                Address = "26 July Street, Assiut",
                PhoneNum = "0882284549",
                Email = "maternity.bloodbank@hospital.gov.eg",
                CityId = 16 // Assiut
            },
            new BloodBank
            {
                Name = "Qena General Blood Bank",
                Address = "Qena, Dendera Bridge Street",
                PhoneNum = "0965332043",
                Email = "qena.bloodbank@hospital.gov.eg",
                CityId = 25 // Qena
            },
            new BloodBank
            {
                Name = "Nag Hammadi Central Blood Bank",
                Address = "Nag Hammadi, End of Tahrir Street",
                PhoneNum = "0966580622",
                Email = "naghammadi.bloodbank@hospital.gov.eg",
                CityId = 25 // Qena
            },
            new BloodBank
            {
                Name = "Abu Tesht Central Blood Bank",
                Address = "Abu Tesht, Port Said Street",
                PhoneNum = "0966710605",
                Email = "abutesht.bloodbank@hospital.gov.eg",
                CityId = 25 // Qena
            },
            new BloodBank
            {
                Name = "Farshout Central Blood Bank",
                Address = "Farshout, Port Said Street",
                PhoneNum = "0966751527",
                Email = "farshout.bloodbank@hospital.gov.eg",
                CityId = 25 // Qena
            },
            new BloodBank
            {
                Name = "Dishna Central Blood Bank",
                Address = "Dishna, Nile Road, Saayda",
                PhoneNum = "0966749594",
                Email = "dishna.bloodbank@hospital.gov.eg",
                CityId = 25 // Qena
            },
            new BloodBank
            {
                Name = "Qus Central Blood Bank",
                Address = "Qus, Sea Street",
                PhoneNum = "0966847568",
                Email = "qus.bloodbank@hospital.gov.eg",
                CityId = 25 // Qena
            },
            new BloodBank
            {
                Name = "Naqada Blood Bank",
                Address = "Naqada, Nile Road, In front of Electricity Network",
                PhoneNum = "0966600066",
                Email = "naqada.bloodbank@hospital.gov.eg",
                CityId = 25 // Qena
            },
            new BloodBank
            {
                Name = "Luxor General Blood Bank",
                Address = "Karnak Temple Street, Next to Trade Square",
                PhoneNum = "0952272809",
                Email = "luxor.bloodbank@hospital.gov.eg",
                CityId = 24 // Luxor
            },
            new BloodBank
            {
                Name = "Esna Central Blood Bank",
                Address = "Ahmed Orabi Street, Next to Electricity Distribution Station",
                PhoneNum = "0952517339",
                Email = "esna.bloodbank@hospital.gov.eg",
                CityId = 24 // Luxor
            },
            new BloodBank
            {
                Name = "Armant Central Blood Bank",
                Address = "Sugar Factory Street, Next to Armant First Aid Station",
                PhoneNum = "0952625648",
                Email = "armant.bloodbank@hospital.gov.eg",
                CityId = 24 // Luxor
            },
            new BloodBank
            {
                Name = "Sohag General Blood Bank",
                Address = "Sohag, Naqrashi Street",
                PhoneNum = "0932339797",
                Email = "sohag.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Girga Central Blood Bank",
                Address = "Hospital Street",
                PhoneNum = "0934676034",
                Email = "girga.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Tama Central Blood Bank",
                Address = "Ahmed Orabi Street",
                PhoneNum = "0932790713",
                Email = "tama.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Maragha Central Blood Bank",
                Address = "Hospital Street",
                PhoneNum = "0932530763",
                Email = "maragha.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Monshaa Central Blood Bank",
                Address = "Abdel Moneim Riad Street",
                PhoneNum = "0932403597",
                Email = "monshaa.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Balina Central Blood Bank",
                Address = "Republic Street",
                PhoneNum = "0934800301",
                Email = "balina.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Saqalta Central Blood Bank",
                Address = "Schools Street",
                PhoneNum = "0932511950",
                Email = "saqalta.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Akhmim Central Blood Bank",
                Address = "Sohag-Akhmim Road",
                PhoneNum = "0932589263",
                Email = "akhmim.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Gehina Central Blood Bank",
                Address = "Martyrs Street",
                PhoneNum = "0934707793",
                Email = "gehina.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Dar El Salam Central Blood Bank",
                Address = "Dar El Salam Center",
                PhoneNum = "0934850333",
                Email = "darelsalam.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Tahta Central Blood Bank",
                Address = "Salah Salem Street",
                PhoneNum = "0934772994",
                Email = "tahta.bloodbank@hospital.gov.eg",
                CityId = 27 // Sohag
            },
            new BloodBank
            {
                Name = "Kom Ombo Central Blood Bank",
                Address = "Seventy Area",
                PhoneNum = "0973510611",
                Email = "komombo.bloodbank@hospital.gov.eg",
                CityId = 15 // Aswan
            },
            new BloodBank
            {
                Name = "Edfu Central Blood Bank",
                Address = "Nile Corniche Street",
                PhoneNum = "0974712121",
                Email = "edfu.bloodbank@hospital.gov.eg",
                CityId = 15 // Aswan
            },
            new BloodBank
            {
                Name = "Mansoura General Blood Bank",
                Address = "Mansoura, Republic Street, Next to Health Institute",
                PhoneNum = "0502249222",
                Email = "mansoura.bloodbank@hospital.gov.eg",
                CityId = 4 // Dakahlia
            },
            new BloodBank
            {
                Name = "Belqas Central Blood Bank",
                Address = "Belqas, Next to Police Station",
                PhoneNum = "0502784321",
                Email = "belqas.bloodbank@hospital.gov.eg",
                CityId = 4 // Dakahlia
            },
            new BloodBank { Name = "Al-Matariya Central Blood Bank", Address = "Al-Matariya - City Council", PhoneNum = "0507750343", Email = "matariya.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Nabroh Central Blood Bank", Address = "Nabroh - Al-Bahr Street", PhoneNum = "0502400301", Email = "nabroh.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Maniat Al-Nasr Central Blood Bank", Address = "Maniat Al-Nasr - Specific Education College Street", PhoneNum = "0507495555", Email = "maniatnasr.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Aga Central Blood Bank", Address = "Aga - Port Said Street", PhoneNum = "0506455311", Email = "aga.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Mit Ghamr Central Blood Bank", Address = "Mit Ghamr - Dakadous Railway Street", PhoneNum = "0506903719", Email = "mitghamr.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Senbellawein Blood Bank", Address = "Senbellawein - Ard Al-Gamal", PhoneNum = "0506690010", Email = "senbellawein.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Dekernes Central Blood Bank", Address = "Dekernes City - City Council Street", PhoneNum = "0507481140", Email = "dekernes.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Al-Manzala Central Blood Bank", Address = "Al-Manzala - Agricultural Road, New Al-Manzala Bridge", PhoneNum = "0507702903", Email = "manzala.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Sherbin Central Blood Bank", Address = "Sherbin - Al-Bahr Street", PhoneNum = "0507925934", Email = "sherbin.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Talkha Central Blood Bank", Address = "Talkha - Al-Bahr Street", PhoneNum = "0502523131", Email = "talkha.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Al-Gamalia Central Blood Bank", Address = "Al-Gamalia - San Al-Hagar Road (Al-Zamalek District)", PhoneNum = "0507731397", Email = "gamalia.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Mit Salsil Blood Bank", Address = "Mit Salsil - Express Road - Next to Ambulance", PhoneNum = "0502714410", Email = "mitsalsil.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Damas Blood Bank", Address = "Damas - Next to Social Solidarity Bank", PhoneNum = "0506880146", Email = "damas.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            new BloodBank { Name = "Mansoura New General Blood Bank", Address = "Mansoura - Behind Sports Stadium", PhoneNum = "0502249222", Email = "mansoura.new.bloodbank@hospital.gov.eg", CityId = 4 }, // Dakahlia

            // Minya Blood Banks
            new BloodBank { Name = "Minya General Blood Bank", Address = "Ibn Al-Khatib Street Next to Young Muslim Association", PhoneNum = "0862324434", Email = "minya.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            new BloodBank { Name = "Maghagha Central Blood Bank", Address = "Al-Madaris Street Next to Mosque", PhoneNum = "0867550045", Email = "maghagha.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            new BloodBank { Name = "Beni Mazar Central Blood Bank", Address = "Al-Ibrahimiya Street Next to City Council", PhoneNum = "0867821935", Email = "benimazar.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            new BloodBank { Name = "Samalut Central Blood Bank", Address = "Port Said Street, First Entrance to Samalut", PhoneNum = "0867713931", Email = "samalut.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            new BloodBank { Name = "Abu Qorqas Blood Bank", Address = "Port Said Street, Abu Qorqas Entrance", PhoneNum = "0862632233", Email = "abuqorqas.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            new BloodBank { Name = "Mallawi Central Blood Bank", Address = "End of 26th July Street Mallawi", PhoneNum = "0862659043", Email = "mallawi.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            new BloodBank { Name = "Al-Adwa Central Blood Bank", Address = "Port Said Street Al-Adwa", PhoneNum = "0867460272", Email = "adwa.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            new BloodBank { Name = "Matai Central Blood Bank", Address = "Al-Ibrahimiya Street Next to City Council", PhoneNum = "0863921120", Email = "matai.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            new BloodBank { Name = "Deir Mawas Central Blood Bank", Address = "26th July Street Next to Health Unit", PhoneNum = "0862010015", Email = "deirmawas.bloodbank@hospital.gov.eg", CityId = 11 }, // Minya

            // Monufia Blood Banks
            new BloodBank { Name = "Menuf General Blood Bank", Address = "Menuf General Hospital", PhoneNum = "0483660323", Email = "menuf.bloodbank@hospital.gov.eg", CityId = 10 }, // Monufia

            new BloodBank { Name = "Berkat Al-Sab Blood Bank", Address = "Berkat Al-Sab First Zefta Road Next to Overpass", PhoneNum = "0482991475", Email = "berkatsab.bloodbank@hospital.gov.eg", CityId = 10 }, // Monufia

            new BloodBank { Name = "Al-Bagour Central Blood Bank", Address = "Al-Bagour - Port Said Street Next to Station", PhoneNum = "0483888163", Email = "bagour.bloodbank@hospital.gov.eg", CityId = 10 }, // Monufia

            new BloodBank { Name = "Sadat Central Blood Bank", Address = "Residential Area Next to Commercial Mall", PhoneNum = "0482600047", Email = "sadat.bloodbank@hospital.gov.eg", CityId = 10 }, // Monufia

            new BloodBank { Name = "Ashmoun General Blood Bank", Address = "Next to Technical School", PhoneNum = "0483445693", Email = "ashmoun.bloodbank@hospital.gov.eg", CityId = 10 }, // Monufia

            new BloodBank { Name = "Al-Shuhada Central Blood Bank", Address = "Next to Station", PhoneNum = "0482754344", Email = "shuhada.bloodbank@hospital.gov.eg", CityId = 10 }, // Monufia

            new BloodBank { Name = "Quesna Central Blood Bank", Address = "Express Road", PhoneNum = "0482579460", Email = "quesna.bloodbank@hospital.gov.eg", CityId = 10 }, // Monufia

            new BloodBank { Name = "Sirs Al-Lyan Central Blood Bank", Address = "Next to UNESCO Authority", PhoneNum = "0483351431", Email = "sirslyan.bloodbank@hospital.gov.eg", CityId = 10 }, // Monufia

            new BloodBank { Name = "Tala Blood Bank", Address = "Tala - Next to City Council", PhoneNum = "0483790281", Email = "tala.bloodbank@hospital.gov.eg", CityId = 10 } // Monufia
            };

            await context.BloodBanks.AddRangeAsync(bloodBanks);
            context.SaveChanges();

        }
    }
}

