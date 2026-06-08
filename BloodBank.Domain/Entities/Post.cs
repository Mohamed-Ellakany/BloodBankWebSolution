using BloodBank.Domain.Consts;

namespace BloodBank.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage =Errors.RequiredField) , RegularExpression(Regex.OnlyCharsAndSpaces,ErrorMessage = Errors.OnlyCharsAndSpaces)]
        public string ContactPerson { get; set; }

        [MaxLength(100 ,ErrorMessage =Errors.MaxLength)]
        [Required(ErrorMessage = Errors.RequiredField)]
        public string Title {  get; set; }



        [MaxLength(100, ErrorMessage = Errors.MaxLength)]
        [Required(ErrorMessage = Errors.RequiredField)]
        public string HospitalName { get; set; }


        [Required(ErrorMessage =Errors.RequiredField),RegularExpression(Regex.PhoneNumberRegex ,ErrorMessage = Errors.PhoneNumberError)]
        public string MobileNumber { get; set; }

        public int BagsNeeded { get; set; }

        [Required(ErrorMessage = Errors.RequiredField) , MaxLength(30 ,ErrorMessage = Errors.MaxLength)]
        public string CityName { get; set; }


        [Required(ErrorMessage = Errors.RequiredField) , MaxLength(200)]
        public string Description { get; set; }


        public DateTime DateOfPublish { get; set; } = DateTime.UtcNow;


        public int BloodTypeId { get; set; }

       public BloodType BloodType { get; set; }

    }
}
