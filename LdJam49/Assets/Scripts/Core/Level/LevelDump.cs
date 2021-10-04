using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDump
{
    public static string GetLevelsString()
    {
        return @"{
  ""$type"": ""System.Collections.Generic.List`1[[Level, Assembly-CSharp]], mscorlib"",
  ""$values"": [
    {
      ""$type"": ""Level, Assembly-CSharp"",
      ""Name"": ""Dodo"",
      ""WaterDepth"": 2000.0,
      ""Length"": 30,
      ""Events"": {
        ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 10.0,
            ""Direction"": -1.0,
			""Frequency"": 0.8,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 30.0,
            ""StartingTime"": 0.0,
          },
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 10.0,
			""Frequency"": 1,
            ""Direction"": 1.0,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 4.0,
            ""StartingTime"": 3.0,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 250.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 4.5,
            ""StartingTime"": 3.0,
			""Sound"": ""Audio/Effects/Wind/Wind2""
          },
          {
            ""$type"": ""DepthEvent, Assembly-CSharp"",
            ""DepthZero"": 300.0,
            ""GradientUp"": 60.0,
            ""GradientDown"": 60.0,
            ""MinWaterDepth"": 150.0,
            ""MinDepthDuration"": 3.0,
            ""EventName"": ""Not Enough Depth"",
            ""Duration"": 10,
            ""StartingTime"": 10.0
          },
          {
            ""$type"": ""ThunderStormEvent, Assembly-CSharp"",
            ""EventName"": ""Thanderman"",
            ""Duration"": 20.0,
            ""StartingTime"": 5.0
          }
        ]
      }
    },
    {
      ""$type"": ""Level, Assembly-CSharp"",
      ""Name"": ""Pogo"",
      ""WaterDepth"": 100.0,
      ""Length"": 30.0,
      ""Events"": {
        ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 100.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 2.0,
            ""StartingTime"": 3.0,
	    ""Sound"": ""Audio/Effects/Wind/Wind2""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 200.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 2.0,
            ""StartingTime"": 7.0,
	    ""Sound"": ""Audio/Effects/Wind/Wind2""
          },
          {
            ""$type"": ""ThunderStormEvent, Assembly-CSharp"",
            ""EventName"": ""Thanderman"",
            ""EventType"": ""Thunderstorm"",
            ""Duration"": 20.0,
            ""StartingTime"": 9.0
          }
        ]
      }
    }
  ]
}";
    }
}
