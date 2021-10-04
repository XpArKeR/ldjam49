using System;
using System.Collections.Generic;
using System.IO;

using Assets.Scripts;

using UnityEngine;

public class JasonHandler
{
    public static string SerializeObject(System.Object objectToSerialize)
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(objectToSerialize, Newtonsoft.Json.Formatting.Indented, new Newtonsoft.Json.JsonSerializerSettings()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All,
            TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple
        });

        return json;
    }


    public static T DeserializeObject<T>(string rawJson)
    {
        //return Newtonsoft.Json.JsonConvert.DeserializeObject<Level>(RawLevel);

        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>((rawJson), new Newtonsoft.Json.JsonSerializerSettings()
        {
            TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
        });
    }


    public static T DeserializeObjectFromFile<T>(string filePath)
    {
        //StreamReader reader = new StreamReader(Application.persistentDataPath + filePath);
        string json = File.ReadAllText(System.IO.Path.Combine(Application.dataPath, filePath));
        return DeserializeObject<T>(json);
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


