namespace VaporStore.Common
{
    public static class GlobalConstants
    {
        //User
        public const int UserUsernameMaxLength = 20;
        public const int UserUsernameMinLength = 3;
        public const string UserFullNameRegex = @"^[A-Z][a-z]+ [A-Z][a-z]+$";

        public const int UserAgeMinValue = 3;
        public const int UserAgeMaxValue = 103;

        //Card
        public const int CardNumberMaxLength = 19;
        public const int CardCvcMaxLength = 3;

        public const string CardNumberRegex = @"^\d{4} \d{4} \d{4} \d{4}$";
        public const string CardCvcRegex = @"^\d{3}$";

        //Purchase
        public const int PurchaseProductKeyMaxLength = 14;
        public const string PurchaseProductKeyRegex = @"^(\d|[A-Z]){4}-(\d|[A-Z]){4}-(\d|[A-Z]){4}$";

        //Game
        public const double GamePriceMinValue = 0;

    }
}
