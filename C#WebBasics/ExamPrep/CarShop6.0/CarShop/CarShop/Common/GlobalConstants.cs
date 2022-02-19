namespace CarShop.Common
{
    public static class GlobalConstants
    {
        public const int GuidMaxLength = 36;

        public const int UserUsernameMaxLength = 20;
        public const int UserUsernameMinLength = 4;
        public const int UserEmailMaxLength = 100;
        public const int UserPasswordHashMaxLength = 64;
        public const int UserPasswordMaxLength = 20;
        public const int UserPasswordMinLength = 5;

        public const int CarModelMaxLength = 20;
        public const int CarModelMinLength = 5;
        public const int CarPictureUrlMaxLength = 200;
        public const int CarPlateNumberMaxLength = 8;
        public const string PlateNumberRegex = @"^[A-z]{2}\d{4}[A-z]{2}$";

        public const int IssueDescriptionMinLength = 5;
    }
}
