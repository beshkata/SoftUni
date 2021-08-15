using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int DefaultDrivingExperience = 30;
        private const string DefaultRacingBehavior = "strict";

        public ProfessionalRacer(string username, ICar car)
            : base(username, DefaultRacingBehavior, DefaultDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            DrivingExperience += 10;
        }
    }
}
