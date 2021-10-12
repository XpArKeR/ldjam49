using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using UnityEngine;

public class ShipLoad
{
    public ShipLoad()
    {
        this.Containers = new List<LoadedContainer>();
    }

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

    [SerializeField]
    private Decimal totalValue;
    public Decimal Value
    {
        get
        {
            return this.totalValue;
        }
        set
        {
            if (this.totalValue != value)
            {
                this.totalValue = value;
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
                centerOfMass = value;
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
