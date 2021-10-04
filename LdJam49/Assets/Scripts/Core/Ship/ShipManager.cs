﻿using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts
{
    public static class ShipManager
    {
        const String shipDefinition = @"{
  ""$type"": ""System.Collections.Generic.List`1[[BasicShip, Assembly-CSharp]], mscorlib"",
  ""$values"": [
    {
      ""$type"": ""BasicShip, Assembly-CSharp"",
      ""relativeCenterOfMassX"": 0.0,
      ""relativeCenterOfMassY"": 0.0,
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
        ""$type"": ""ShipLoad, Assembly-CSharp""
      }
    }
  ]
}";

        public static BasicShip GetDefaultShip()
        {
            List<BasicShip> ships;

            if (Core.IsFileAccessPossible)
            {
                var filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "Data", "Ships.json");

                ships = JasonHandler.DeserializeObjectFromFile<List<BasicShip>>(filePath);
            }
            else
            {
                ships = JasonHandler.DeserializeObject<List<BasicShip>>(shipDefinition);
            }

            return ships[0];
        }
    }
}
