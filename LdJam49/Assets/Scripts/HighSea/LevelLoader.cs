using UnityEngine;

public class LevelLoader
{
    public static Level GetDefaultLevel()
    {
        return DeserializeLevel(GetRawDefaultLevel());
    }

    public static string SerializeLevel(Level level)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(level, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple
        });

        return json;
    }


    private static Level DeserializeLevel(string RawLevel)
    {
        //return Newtonsoft.Json.JsonConvert.DeserializeObject<Level>(RawLevel);

        return Newtonsoft.Json.JsonConvert.DeserializeObject<Level>((RawLevel), new Newtonsoft.Json.JsonSerializerSettings()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
        });
    }


    private static string GetRawDefaultLevel()
    {
        return @"{
                ""$type"": ""Level, Assembly - CSharp"",
                ""name"": ""Default"",
                ""events"": {""$type"": ""System.Collections.Generic.List`1[[SeaEvent, Assembly - CSharp]], mscorlib"",
                             ""$values"":
                             [
                                {
                                ""$type"": ""WindEvent, Assembly - CSharp"",
                                ""eventName"" : ""Blast"",
                                ""strength"" : 2000,
                                ""direction"" : -1,
                                ""startingTime"" : 2,
                                ""duration"" : 20
                                }
                             ]},
                ""waterDepth"": 100,
                ""length"": 30
                }";

    }
}
