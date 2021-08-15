using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (racerOne.IsAvailable() && racerTwo.IsAvailable() == false)
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else if (racerOne.IsAvailable() == false && racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }

            racerOne.Race();
            racerTwo.Race();

            double racerOneChanceOfWinning = CalcChanceOfWinning(racerOne);
            double racerTwoChanceOfWinning = CalcChanceOfWinning(racerTwo);

            string winnerUsername = string.Empty;

            if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
            {
                winnerUsername = racerOne.Username;
            }
            else
            {
                winnerUsername = racerTwo.Username;
            }

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winnerUsername);
        }

        private double RacingBehaviorMultiplier(IRacer racer)
        {
            if (racer.RacingBehavior == "strict")
            {
                return 1.2;
            }
            else
            {
                return 1.1;
            }
        }

        private double CalcChanceOfWinning(IRacer racer)
        {
            return racer.Car.HorsePower * racer.DrivingExperience * RacingBehaviorMultiplier(racer);
        }
    }
}
