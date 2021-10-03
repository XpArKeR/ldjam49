using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLoad 
{
    [SerializeField]
    private float weight;
    public float Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            if (this.weight != value)
            {
                this.weight = value;
            }
        }
    }

    [JsonProperty]
    private float centerOfMassX;
    [JsonProperty]
    private float centerOfMassY;

    [JsonIgnore]
    private Vector2 centerOfMass;
    [JsonIgnore]
    public Vector2 CenterOfMass
    {
        get
        {
            if (centerOfMass == default)
            {
                centerOfMass = new Vector2(centerOfMassX, centerOfMassY);
            }
            return this.centerOfMass;
        }
        set
        {
            if (this.centerOfMass != value)
            {
                centerOfMassX = value.x;
                centerOfMassY = value.y;
            }
        }
    }


    [SerializeField]
    private float offset;
    public float Offset
    {
        get
        {
            return this.offset;
        }
        set
        {
            if (this.offset != value)
            {
                this.offset = value;
            }
        }
    }

    [SerializeField]
    private List<LoadedContainer> containers;
    public List<LoadedContainer> Containers
    {
        get
        {
            return this.containers;
        }
        set
        {
            if (this.containers != value)
            {
                this.containers = value;
            }
        }
    }
}
