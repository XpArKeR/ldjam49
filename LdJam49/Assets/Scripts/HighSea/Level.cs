using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level 
{
    public string Name { get;  set; }

    public List<SeaEvent> Events { get; set; }

    public float WaterDepth { get; set; }

    public float Length { get; set; }
}
