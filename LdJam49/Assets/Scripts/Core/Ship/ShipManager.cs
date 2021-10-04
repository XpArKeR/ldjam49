using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class ShipManager
    {
        private static List<BasicShip> ships;

        const String shipDefinition = @"{
  ""$type"": ""System.Collections.Generic.List`1[[BasicShip, Assembly-CSharp]], mscorlib"",
  ""$values"": [
    {
      ""$type"": ""BasicShip, Assembly-CSharp"",
      ""relativeCenterOfMassX"": 0.5,
      ""relativeCenterOfMassY"": 0.2,
      ""Width"": 195.0,
      ""Height"": 170.0,
      ""MaxDraft"": 118.0,
      ""Buoyancy"": 40.0,
      ""StabilityConstant1"": 1.2,
      ""StabilityConstant2"": -10.0,
      ""TiltingAngle"": 20.0,
      ""Mass"": 4.0,
      ""Damping"": 3.0,
      ""ShipLoad"": {
        ""$type"": ""ShipLoad, Assembly-CSharp"",
        ""Weight"": 300.0,
        ""centerOfMassX"": 0.6,
        ""centerOfMassY"": 0.4
      }
    }
  ]
}";

        public static BasicShip GetDefaultShip()
        {
            if (ships == null || ships.Count < 1)
            {
                if (Core.IsFileAccessPossible)
                {
                    var filePath = System.IO.Path.Combine("Resources", "Data", "Ships.json");

                    ships = JasonHandler.DeserializeObjectFromFile<List<BasicShip>>(filePath);
                }
                else
                {
                    ships = JasonHandler.DeserializeObject<List<BasicShip>>(shipDefinition);
                }
            }

            if (ships == null || ships.Count < 1)
            {
                throw new InvalidOperationException("No ships could be loaded!");
            }

            return ships[0];
        }
    }
}
