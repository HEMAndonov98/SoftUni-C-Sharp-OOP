namespace CarRacing.Models.Maps
{
    using System;
    using RacingBehaviourMultipliers;
    using Contracts;
    using Racers.Contracts;
    using Utilities.Messages;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Linq;

    public class Map : IMap
    {
        public Map()
        {
        }

        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {

            bool racerOneAvailable = racerOne.IsAvailable();
            bool racerTwoAvailable = racerTwo.IsAvailable();

            if (racerOneAvailable == false)
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);

            if (racerTwoAvailable == false)
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);

            if (racerOneAvailable == false && racerTwoAvailable == false)
                return String.Format(OutputMessages.RaceCannotBeCompleted);

            racerOne.Race();
            racerTwo.Race();

            var racerOneChanceOfWinning = this.CalculateWinningChance(racerOne);
            var racerTwoChanceOfWinning = this.CalculateWinningChance(racerTwo);

            if (racerOneChanceOfWinning > racerTwoChanceOfWinning)
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            else
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
        }

        private double CalculateWinningChance(IRacer racer)
        {
            var type = typeof(BehaviourMultipliers);

            var behaviour = type.GetFields(BindingFlags.Static | BindingFlags.Public)
                .First(b => b.Name.ToLower() == racer.RacingBehavior.ToLower());

            var behaviourMultiplier = (double)behaviour.GetValue(null);

            return racer.Car.HorsePower * racer.DrivingExperience * behaviourMultiplier;
        }
    }
}

