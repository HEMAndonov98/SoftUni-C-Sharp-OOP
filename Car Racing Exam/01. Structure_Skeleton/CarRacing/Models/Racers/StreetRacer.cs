using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const string initRacingBehaviour = "aggressive";
        private const int initDrivingExperience = 10;
        private const int racerExerienceIncrease = 5;

        public StreetRacer(string username, ICar car)
             : base(username, initRacingBehaviour, initDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += racerExerienceIncrease;
        }
    }
}

