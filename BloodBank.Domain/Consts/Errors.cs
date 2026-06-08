namespace BloodBank.Domain.Consts
{
    public class Errors
    {

        public const string MaxLength = "Length cannot be more than {1} characters";
        public const string MinMaxLength = "The {0} must be at least {2} and at max {1} characters long.";
        public const string MinMaxRange = "The {0} must be between {1} : {2}.";
        public const string ConfirmationPassword = "The password and confirmation password do not match.";
        public const string UserNameRegexError = "it's not accepted , accept only Chars and numbers and @ &";
        public const string NationalIdRegexError = "it's not correct National Id ";
        public const string OnlyCharsAndSpaces = "it's not accepted , accept only Chars and Spaces";
        public const string Dublicated = "this {0} is already exist";
        public const string EmailsRegexError = "this is not email";
        public const string weakPassword = "it's weak Password";
        public const string RequiredField = "it's Required Field";
        public const string PhoneNumberError = "it's not correct Phone Number";
        public const string DateValidation = "not allowed Future date";



    }
}
