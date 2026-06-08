namespace BloodBank.Domain.Consts
{
    public class Regex
    {
        public const string NationalIdRegex = "^(2|3)\\d{13}$";
        public const string UserNameRegex = "^[a-zA-Z0-9@&]+$";
        public const string PhoneNumberRegex = "^01[0-2,5]{1}\\d{8}$";
        public const string OnlyCharsAndSpaces = "^[A-Za-z\\s]+$";
        public const string Emails = "^\\w+([\\.-]?\\w+)*@\\w+([\\.-]?\\w+)*(\\.\\w{2,3})+$";
        public const string Passwords = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$";


    }
}
