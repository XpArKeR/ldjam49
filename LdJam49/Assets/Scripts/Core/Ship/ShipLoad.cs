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

    [SerializeField]
    private Vector2 centerOfMass;
    public Vector2 CenterOfMass
    {
        get
        {
            return this.centerOfMass;
        }
        set
        {
            if (this.centerOfMass != value)
            {
                this.centerOfMass = value;
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
