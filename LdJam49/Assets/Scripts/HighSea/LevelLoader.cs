using UnityEngine;

public class LevelLoader
{
    public static Level GetDefaultLevel()
    {
        return DeserializeLevel(GetRawDefaultLevel());
    }

    private static Level DeserializeLevel(string RawLevel)
    {
        return JsonUtility.FromJson<Level>(RawLevel);
    }


    private static string GetRawDefaultLevel()
    {
        return @"{
                ""Name"": ""Default"",
                ""Events"": 
                [
                    {""EventName"" : ""Blast"",
                    ""Strength"" : 2000,
                    ""Direction"" : -1,
                    ""StartingTime"" : 2,
                    ""Duration"" : 20}
                ],
                ""WaterDepth"": 100,
                ""Length"": 30
                }";

    }
}
