namespace BloodBankWeb.Core.ViewModels
{
    public class ResetPasswordFormViewModel
    {
        public string Id { get; set; } = null!;


        [RegularExpression(Regex.Passwords, ErrorMessage = Errors.weakPassword)
           , DataType(DataType.Password)
           , StringLength(100, ErrorMessage = Errors.MinMaxLength, MinimumLength = 6)]
        public string Password { get; set; } = null!;



        [RegularExpression(Regex.Passwords, ErrorMessage = Errors.weakPassword)
            , DataType(DataType.Password),
            Display(Name = "Confirm password"),
            Compare("Password", ErrorMessage = Errors.ConfirmationPassword)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
