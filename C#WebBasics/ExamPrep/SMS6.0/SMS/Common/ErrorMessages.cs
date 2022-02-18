namespace SMS.Common
{
    public static class ErrorMessages
    {
        //Register User
        public const string UsernameErrorMessage = "{0} must be between {2} and {1} characters";
        public const string EmailErrorMessage = "Email must be valid email";
        public const string PasswordErrorMessage = "{0} must be between {2} and {1} characters";
        public const string PasswordConfirmPassrordErrorMessage = "Password and ConfirmPassword must be equal";

        //Create new product
        public const string CreateProductErrorMessage = "{0} must be between {2} and {1} characters";
        public const string CreateProductPriceErrorMessage = "Price must be between 0.05 and 1000";
        public const string SaveProductErrorMessage = "Could not save product";
    }
}
