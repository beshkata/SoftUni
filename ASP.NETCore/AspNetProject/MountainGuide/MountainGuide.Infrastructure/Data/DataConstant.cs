namespace MountainGuide.Infrastructure.Data
{
    public class DataConstant
    {
        public class TouristBuilding
        {
            public const int NameMaxLength = 100;
            public const int NameMinLength = 2;
            public const double AltitudeMaxLength = 8848.0;
            public const double AltitudeMinLength = 0.0;
            public const int PhoneNumberMaxLength = 20;
            public const int PhoneNumberMinLength = 5;
            public const int ManagerIdMaxLength = 450;
        }

        public class TouristBuildingType
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

        }

        public class Mountain
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;

        }
        public class Peak
        {
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
            public const double AltitudeMaxLength = 8848.0;
            public const double AltitudeMinLength = 0.0;

        }

        public class Coordinate
        {
            public const int LatitudeTypeLength = 5;
            public const int LongitudeTypeLength = 4;
            public const int ValueMaxLength = 11;
        }

        public class TouristAssociation
        {
            public const int ManagerIdMaxLength = 450;
            public const int NameMaxLength = 200;
            public const int NameMinLength = 2;
            public const int PhoneNumberMaxLength = 20;
            public const int PhoneNumberMinLength = 5;
            public const int LogoUrlMaxLength = 300;
            public const int WebSiteUrlMaxLength = 300;
        }

        public class Image
        {
            public const int DescriptionMaxLength = 1000;
            public const int ImageUrlMaxLength = 300;
        }

        public class AssociationManager
        {
            public const int IdMaxLength = 450;
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
            public const int PhoneNumberMaxLength = 20;
            public const int PhoneNumberMinLength = 5;
        }

        public class BuildingManager
        {
            public const int IdMaxLength = 450;
            public const int NameMaxLength = 50;
            public const int NameMinLength = 2;
            public const int PhoneNumberMaxLength = 20;
            public const int PhoneNumberMinLength = 5;
        }

        public class Announcement
        {
            public const int ContentMaxLength = 2000;
            public const int UserIdMaxLength = 450;
        }
    }
}
