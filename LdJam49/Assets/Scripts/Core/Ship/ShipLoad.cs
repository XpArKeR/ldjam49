using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLoad 
{
    public float Weight { get; set; }

    public Vector2 CenterOfMass { get; set; }

    public float Offset { get; set; }

    public List<LoadedContainer> Containers { get; set; }


}
