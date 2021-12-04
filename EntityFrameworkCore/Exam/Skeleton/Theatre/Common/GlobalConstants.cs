using System;

namespace Theatre.Common
{
    public static class GlobalConstants
    {
        //Theatre
        public const int TheatreNameMaxLength = 30;
        public const int TheatreNameMinLength = 4;

        public const int TheatreNumberOfHallsMinValue = 1;
        public const int TheatreNumberOfHallsMaxValue = 10;

        public const int TheatreDirectorMaxLength = 30;
        public const int TheatreDirectorMinLength = 4;

        //Play
        public const int PlayTitleMaxLength = 50;
        public const int PlayTitleMinLength = 4;

        public const float PlayRaitingMaxValue = 10.0f;
        public const float PlayRaitingMinValue = 0.0f;

        public const int PlayDurationMinValue = 1;

        public const int PlayDescriptionMaxLength = 700;

        public const int PlayScreenwriterMaxLength = 30;
        public const int PlayScreenwriterMinLength = 4;

        //Cast
        public const int CastFullNameMaxLength = 30;
        public const int CastFullNameMinLength = 4;

        public const int CastPhoneNumberMaxLength = 15;
        public const string CastPhoneNumberRegex = @"^\+44-\d{2}-\d{3}-\d{4}$";

        //Ticket
        public const double TicketPriceMinValue = 1.00;
        public const double TicketPriceMaxValue = 100.00;

        public const int TicketRowNumberMaxValue = 10;
        public const int TicketRowNumberMinValue = 1;


    }
}
