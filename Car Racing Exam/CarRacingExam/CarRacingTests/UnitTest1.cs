using System.Reflection;
using CarRacing.Models.Maps.RacingBehaviourMultipliers;

namespace CarRacingTests;

public class Tests
{

    [Test]
    public void Test1()
    {
        var type = typeof(BehaviourMultipliers);

        var multipliers = type.GetFields(BindingFlags.Static | BindingFlags.Public);

        string name = multipliers[0].Name.ToLower();
    }
}
