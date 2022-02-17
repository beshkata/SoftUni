namespace SMS.Common
{
    public static class GlobalConstants
    {
        public const int GuidMaxLength = 36;

        public const int UserUsernameMaxLength = 20;
        public const int UserUsernameMinLength = 5;
        public const int UserEmailMaxLength = 100;
        public const int UserPasswordHashlMaxLength = 64;

        public const int ProductNameMaxLength = 20;
        public const int ProductNameMinLength = 4;
        public const decimal ProductPriceMaxValue = 1000m;
        public const decimal ProductPriceMinValue = 0.05m;
    }
}
