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
      ""Name"": ""Rotterdam-Hamburg"",
	  ""Start"": ""Rotterdam"",
	  ""Destination"": ""Hamburg"",
      ""WaterDepth"": 200.0,
      ""Length"": 30,
      ""Events"": {
        ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 5.0,
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
            ""Duration"": 10.0,
            ""StartingTime"": 4.0,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 120.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 10,
            ""StartingTime"": 6.0,
			""Sound"": ""Wind1""
          },
          {
            ""$type"": ""DepthEvent, Assembly-CSharp"",
            ""DepthZero"": 200.0,
            ""GradientUp"": 50.0,
            ""GradientDown"": 50.0,
            ""MinWaterDepth"": 100.0,
            ""MinDepthDuration"": 3.0,
            ""EventName"": ""Not Enough Depth"",
            ""Duration"": 15,
            ""StartingTime"": 2.0
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 150.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 4.5,
            ""StartingTime"": 17.0,
			""Sound"": ""Wind2""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 180.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 4.5,
            ""StartingTime"": 23.0,
			""Sound"": ""Wind3""
          },
        ]
      }
    },
    {
      ""$type"": ""Level, Assembly-CSharp"",
      ""Name"": ""Hamburg-Felixstowe"",
	  ""Start"": ""Hamburg"",
	  ""Destination"": ""Felixstowe"",
      ""WaterDepth"": 200.0,
      ""Length"": 30,
      ""Events"": {
        ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 7.0,
            ""Direction"": -1.0,
			""Frequency"": 0.8,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 30.0,
            ""StartingTime"": 0.0,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 140.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 10,
            ""StartingTime"": 4.5,
			""Sound"": ""Wind1""
          },
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 15.0,
			""Frequency"": 2,
            ""Direction"": 1.0,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 10.0,
            ""StartingTime"": 5.0,
          },
          {
            ""$type"": ""DepthEvent, Assembly-CSharp"",
            ""DepthZero"": 200.0,
            ""GradientUp"": 50.0,
            ""GradientDown"": 50.0,
            ""MinWaterDepth"": 90.0,
            ""MinDepthDuration"": 7.0,
            ""EventName"": ""Not Enough Depth"",
            ""Duration"": 15,
            ""StartingTime"": 8.0
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 180.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 6.0,
            ""StartingTime"": 17.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 185.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 4.5,
            ""StartingTime"": 23.0,
			""Sound"": ""Wind2""
          },
        ]
      }
    },
    {
      ""$type"": ""Level, Assembly-CSharp"",
      ""Name"": ""Felixstowe-New York"",
	  ""Start"": ""Felixstowe"",
	  ""Destination"": ""New York"",
      ""WaterDepth"": 200.0,
      ""Length"": 30,
      ""Events"": {
        ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 30.0,
            ""Direction"": -1.0,
			""Frequency"": 0.6,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 30.0,
            ""StartingTime"": 0.0,
          },
          {
            ""$type"": ""ThunderStormEvent, Assembly-CSharp"",
            ""EventName"": ""Thanderman"",
            ""Duration"": 10.0,
            ""StartingTime"": 5.0
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 140.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 10,
            ""StartingTime"": 5.1,
			""Sound"": ""Wind2""
          },
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 20.0,
			""Frequency"": 1,
            ""Direction"": 1.0,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 10.0,
            ""StartingTime"": 5.2,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 150.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 6.0,
            ""StartingTime"": 7.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 200.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 5.0,
            ""StartingTime"": 12.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""ThunderStormEvent, Assembly-CSharp"",
            ""EventName"": ""Thanderman"",
            ""Duration"": 6.0,
            ""StartingTime"": 21.0
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 185.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 4.5,
            ""StartingTime"": 23.0,
			""Sound"": ""Wind2""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 80.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 5.0,
            ""StartingTime"": 24.0,
			""Sound"": ""Wind3""
          },
        ]
      }
    },
    {
      ""$type"": ""Level, Assembly-CSharp"",
      ""Name"": ""New York-Los Angeles"",
	  ""Start"": ""New York"",
	  ""Destination"": ""Los Angeles"",
      ""WaterDepth"": 200.0,
      ""Length"": 30,
      ""Events"": {
        ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 40.0,
            ""Direction"": -1.0,
			""Frequency"": 0.8,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 30.0,
            ""StartingTime"": 0.0,
          },
          {
            ""$type"": ""ThunderStormEvent, Assembly-CSharp"",
            ""EventName"": ""Thanderman"",
            ""Duration"": 10.0,
            ""StartingTime"": 5.0
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 140.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 10,
            ""StartingTime"": 5.1,
			""Sound"": ""Wind2""
          },
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 20.0,
			""Frequency"": 1,
            ""Direction"": 1.0,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 10.0,
            ""StartingTime"": 5.2,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 150.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 6.0,
            ""StartingTime"": 7.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 200.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 5.0,
            ""StartingTime"": 12.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""DepthEvent, Assembly-CSharp"",
            ""DepthZero"": 200.0,
            ""GradientUp"": 50.0,
            ""GradientDown"": 50.0,
            ""MinWaterDepth"": 80,
            ""MinDepthDuration"": 3.0,
            ""EventName"": ""Not Enough Depth"",
            ""Duration"": 15,
            ""StartingTime"": 18.0
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 80.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 5.0,
            ""StartingTime"": 22.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 185.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 4.5,
            ""StartingTime"": 25.0,
			""Sound"": ""Wind2""
          },
        ]
      }
    },
    {
      ""$type"": ""Level, Assembly-CSharp"",
      ""Name"": ""Los Angeles-Balboa"",
	  ""Start"": ""Los Angeles"",
	  ""Destination"": ""Balboa"",
      ""WaterDepth"": 200.0,
      ""Length"": 30,
      ""Events"": {
        ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 50.0,
            ""Direction"": -1.0,
			""Frequency"": 0.8,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 30.0,
            ""StartingTime"": 0.0,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 160.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 10,
            ""StartingTime"": 4.1,
			""Sound"": ""Wind2""
          },
          {
            ""$type"": ""ThunderStormEvent, Assembly-CSharp"",
            ""EventName"": ""Thanderman"",
            ""Duration"": 10.0,
            ""StartingTime"": 8.0
          },
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 20.0,
			""Frequency"": 1,
            ""Direction"": 1.0,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 10.0,
            ""StartingTime"": 8.2,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 200.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 5.0,
            ""StartingTime"": 12.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""DepthEvent, Assembly-CSharp"",
            ""DepthZero"": 200.0,
            ""GradientUp"": 50.0,
            ""GradientDown"": 50.0,
            ""MinWaterDepth"": 60,
            ""MinDepthDuration"": 3.0,
            ""EventName"": ""Not Enough Depth"",
            ""Duration"": 15,
            ""StartingTime"": 18.0
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 150.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 6.0,
            ""StartingTime"": 18.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 80.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 5.0,
            ""StartingTime"": 25.0,
			""Sound"": ""Wind3""
          }
        ]
      }
    },
    {
      ""$type"": ""Level, Assembly-CSharp"",
      ""Name"": ""Balboa-Shanghai"",
	  ""Start"": ""Balboa"",
	  ""Destination"": ""Shanghai"",
      ""WaterDepth"": 200.0,
      ""Length"": 30,
      ""Events"": {
        ""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly-CSharp]], mscorlib"",
        ""$values"": [
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 40.0,
            ""Direction"": -1.0,
			""Frequency"": 1.5,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 30.0,
            ""StartingTime"": 0.0,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 160.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 10,
            ""StartingTime"": 4.1,
			""Sound"": ""Wind2""
          },
          {
            ""$type"": ""ThunderStormEvent, Assembly-CSharp"",
            ""EventName"": ""Thanderman"",
            ""Duration"": 10.0,
            ""StartingTime"": 4.2
          },
          {
            ""$type"": ""WaveEvent, Assembly-CSharp"",
            ""Strength"": 30.0,
			""Frequency"": 1,
            ""Direction"": 1.0,
            ""EventName"": ""Continous Waves"",
            ""Duration"": 10.0,
            ""StartingTime"": 4.3,
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 150.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 5.0,
            ""StartingTime"": 6.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""DepthEvent, Assembly-CSharp"",
            ""DepthZero"": 200.0,
            ""GradientUp"": 50.0,
            ""GradientDown"": 50.0,
            ""MinWaterDepth"": 80,
            ""MinDepthDuration"": 3.0,
            ""EventName"": ""Not Enough Depth"",
            ""Duration"": 15,
            ""StartingTime"": 10.0
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 170.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 10,
            ""StartingTime"": 12.0,
			""Sound"": ""Wind2""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 150.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 6.0,
            ""StartingTime"": 18.0,
			""Sound"": ""Wind3""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 80.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 5.0,
            ""StartingTime"": 25.0,
			""Sound"": ""Wind3""
          }
        ]
      }
    },
    {
      ""$type"": ""Level, Assembly-CSharp"",
      ""Name"": ""Dodo"",
	  ""Start"": ""Hier"",
	  ""Destination"": ""Da"",
      ""WaterDepth"": 200.0,
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
            ""Strength"": 220.0,
            ""Direction"": 1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 4.5,
            ""StartingTime"": 3.0,
			""Sound"": ""Wind2""
          },
          {
            ""$type"": ""DepthEvent, Assembly-CSharp"",
            ""DepthZero"": 200.0,
            ""GradientUp"": 50.0,
            ""GradientDown"": 50.0,
            ""MinWaterDepth"": 0.7,
            ""MinDepthDuration"": 3.0,
            ""EventName"": ""Not Enough Depth"",
            ""Duration"": 15,
            ""StartingTime"": 3.0
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
	  ""Start"": ""Dort"",
	  ""Destination"": ""Dr?ben"",
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
	    ""Sound"": ""Wind2""
          },
          {
            ""$type"": ""WindEvent, Assembly-CSharp"",
            ""Strength"": 200.0,
            ""Direction"": -1.0,
            ""EventName"": ""Blast"",
            ""Duration"": 2.0,
            ""StartingTime"": 7.0,
	    ""Sound"": ""Wind2""
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
