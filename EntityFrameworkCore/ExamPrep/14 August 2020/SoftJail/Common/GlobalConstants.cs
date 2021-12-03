namespace SoftJail.Common
{
    public static class GlobalConstants
    {
        //Prisoner
        public const int PrisonerFullNameMaxLength = 20;
        public const int PrisonerFullNameMinLength = 3;

        public const int PrisonerAgeMinValue = 18;
        public const int PrisonerAgeMaxValue = 65;

        public const string PrisonerNicknameRegex = @"^The [A-Z][a-z]+$";


        //Officer
        public const int OfficerFullNameMaxLength = 30;
        public const int OfficerFullNameMinLength = 3;

        public const double OfficerSalaryMinValue = 0.0;

        public const int OfficerPositionMinValue = 0;
        public const int OfficerPositionMaxValue = 3;

        public const int OfficerWeaponMinValue = 0;
        public const int OfficerWeaponMaxValue = 4;


        //Cell
        public const int CellNumberMinValue = 1;
        public const int CellNumberMaxValue = 1000;

        //Department
        public const int DepartmentNameMaxLength = 25;
        public const int DepartmentNameMinLength = 3;

        //Mail
        public const string MailAddressRegex = @"^[\w\s\d]+ str\.$";
    }
}
