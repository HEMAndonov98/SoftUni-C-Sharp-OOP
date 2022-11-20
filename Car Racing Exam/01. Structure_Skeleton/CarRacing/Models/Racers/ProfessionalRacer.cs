using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const string initRacingBehaviour = "strict";
        private const int initDrivingExperience = 30;
        private const int racerExerienceIncrease = 10;

        public ProfessionalRacer(string username, ICar car)
            :base(username, initRacingBehaviour, initDrivingExperience, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += racerExerienceIncrease;
        }
    }
}

