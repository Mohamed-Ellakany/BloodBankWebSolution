namespace BloodBank.Application.Common.Abstractions;

    public static class UserErrors
    {
        public static readonly Error InvalidCredentials = new("User.InvalidCredentials", "Invalid Email/Passowrd", StatusCodes.Status400BadRequest);

        public static readonly Error DuplicatedEmail = new("User.Duplicated Email", "Another user with the same email is already exists", StatusCodes.Status409Conflict);


        public static readonly Error NotAllowedBloodType = new("User.Not Allowed Blood Type", "Not Allowed Blood Type ", StatusCodes.Status400BadRequest);

        public static readonly Error EmailNotConfirmed = new("User.EmailNotConfirmed", "Email is Not Confirmed", StatusCodes.Status401Unauthorized);
        public static readonly Error InvalidCode = new("User.InvalidCode", "Code is Invalid", StatusCodes.Status401Unauthorized);
        public static readonly Error DuplicatedConfirmation  = new("User.DuplicatedConfirmation", "Email already confirmed", StatusCodes.Status400BadRequest);
        public static readonly Error NationalIdIsExists  = new("User.NationalIdIsExists", "National Id Is Exists", StatusCodes.Status400BadRequest);


        public static readonly Error NoBloodBagWithTpyeInBank  = new("BloodBags.NoBloodBag", "this Bank don't have any Blood Bag in this type", StatusCodes.Status404NotFound);

        public static readonly Error NoBloodBagWithTpye  = new("BloodBags.NoBloodBag", "we ara don't have any blood bag from this type", StatusCodes.Status404NotFound);
    
        public static readonly Error NoPlasmaWithTypeInBank  = new("Plasmas.NoPlasma", "this Bank don't have any Plasma in this type", StatusCodes.Status404NotFound);

        public static readonly Error NoPlasmaWithType  = new("Plasmas.NoPlasma", "we ara don't have any Plasma from this type", StatusCodes.Status404NotFound);

        public static readonly Error NoPlateletsesWithTypeInBank = new("Plateletses.NoPlateletses", "this Bank don't have any Plateletses in this type", StatusCodes.Status404NotFound);

        public static readonly Error NoPlateletsesWithType = new("Plateletses.NoPlateletses", "we ara don't have any Plateletses from this type", StatusCodes.Status404NotFound);


        public static readonly Error NoPosts  = new("Posts.NoPosts", " don't have any Posts ", StatusCodes.Status404NotFound);

        public static readonly Error FailedOperation  = new("Posts.FailedOperation", " it's Failed Operation Try Again ", StatusCodes.Status400BadRequest);

        public static readonly Error LastDonationTime  = new("Donation.FailedOperation", " 90 days must pass since the last donation date.", StatusCodes.Status400BadRequest);

        public static readonly Error DonationDateNotValid  = new("Donation.FailedOperation", "this Donation Date is not Valid", StatusCodes.Status400BadRequest);
       
        public static readonly Error NoCityWithThisId  = new("City.NoCityWithThisId", "No City With This Id", StatusCodes.Status400BadRequest);

        public static readonly Error RequiredData  = new("AI.RequiredData", "Request data is required", StatusCodes.Status400BadRequest);

        public static readonly Error InvalidGovernorate  = new ("AI.RequiredData", "Invalid governorate", StatusCodes.Status400BadRequest);

        public static readonly Error InvalidBloodType  = new ("AI.RequiredData", "Invalid Blood Type", StatusCodes.Status400BadRequest);

        public static readonly Error NoData  = new ("AI.NoData", "No Data", StatusCodes.Status404NotFound);

        public static readonly Error ApiCallFailed = new("Ai.ApiCall",  "Api Call Failed" ,StatusCodes.Status400BadRequest) ;



    }

