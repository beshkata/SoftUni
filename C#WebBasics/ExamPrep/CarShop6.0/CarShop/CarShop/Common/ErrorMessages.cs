namespace CarShop.Common
{
    public static class ErrorMessages
    {
        //Common errors
        public const string UnexpectedErrorErrorMessage = "Unexpected error!";

        //Register User
        public const string UsernameErrorMessage = "{0} must be between {2} and {1} characters!";
        public const string EmailErrorMessage = "Email must be valid email!";
        public const string PasswordErrorMessage = "{0} must be between {2} and {1} characters!";
        public const string PasswordConfirmPassrordErrorMessage = "Password and ConfirmPassword must be equal!";
        public const string UsernameExistErrorMessage = "Registration failed!";

        //Login errors
        public const string LoginErrorMessage = "Incorect Login";

        //Add car errors
        public const string ModelErrorMessage = "{0} must be between {2} and {1} characters!";
        public const string PictureUrlErrorMessage = "{0} must be less than {1} characters!";
        public const string PlateNumberErrorMessage = "{0} must be in format 'LL2222LL'";



    }
}
