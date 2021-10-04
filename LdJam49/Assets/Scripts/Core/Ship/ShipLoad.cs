using System.Collections.Generic;
using Assets.Scripts;
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

    public void AddContainer(LoadedContainer container)
    {
        Weight += container.Container.Weight;

        this.Containers.Add(container);

        float offSum = 0;
        foreach (var cont in this.Containers)
        {
            offSum += cont.Container.Weight * (cont.Offset.x - (Core.GameState.Ship.ContainerCapacity - 1f) / 2f);
        }

        CenterOfMass = new Vector2(offSum / Weight, CenterOfMass.y);
    }
}
