using UnityEngine;

public class JasonHandler
{
    public static Level GetDefaultLevel()
    {
        return DeserializeObject<Level>(GetRawDefaultLevel());
    }

    public static BasicShip GetDefaultShip()
    {
        return DeserializeObject<BasicShip>(GetRawDefaultShip());
    }

    public static string SerializeObject(System.Object objectToSerialize)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(objectToSerialize, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple
        });

        return json;
    }


    private static T DeserializeObject<T>(string rawLevel)
    {
        //return Newtonsoft.Json.JsonConvert.DeserializeObject<Level>(RawLevel);

        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>((rawLevel), new Newtonsoft.Json.JsonSerializerSettings()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
        });
    }


    private static string GetRawDefaultLevel()
    {

        return @"{        
              ""$type"": ""Level, Assembly-CSharp"",
              ""Name"": ""Dodo"",
              ""Events"": {
                            ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
                ""$values"": [
                  {
                    ""$type"": ""WindEvent, Assembly-CSharp"",
                    ""Strength"": 2000.0,
                    ""Direction"": 1.0,
                    ""EventName"": ""Blast"",
                    ""Duration"": 2.0,
                    ""StartingTime"": 10.0
                  }
                ]
              },
              ""WaterDepth"": 100.0,
              ""Length"": 30.0
        }";
    }


    private static string GetRawDefaultShip()
    {
        return @"{
                      ""$type"": ""BasicShip, Assembly-CSharp"",
                      ""relativeCenterOfMassX"": 0.5,
                      ""relativeCenterOfMassY"": 0.5,
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
                        ""Offset"": 0.0,
                        ""centerOfMassX"": 0.5,
                        ""centerOfMassY"": 0.4,
                        ""Containers"": null
                      }
                }";
    }

}

//Width = 195;
//   Height = 170;
//   MaxDraft = 118;
//   Buoyancy = 40;
//   RelativeCenterOfMass = new Vector2(0.5f, 0.5f);

//   StabilityConstant1 = 1.2f;
//   StabilityConstant2 = -10f;
//   TiltingAngle = 20f;

//   Mass = 4f;
//   Damping = 3f;

//   ShipLoad = new ShipLoad()
//   {
//       Offset = 0f,
//       CenterOfMass = new Vector2(.5f, 0.4f),
//       Weight = 300f
//   };
//}


