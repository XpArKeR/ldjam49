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

        float offSumX = 0;
        float offSumY = 0;
        foreach (var cont in this.Containers)
        {
            offSumX += cont.Container.Weight * (cont.Offset.x / (Core.GameState.Ship.ContainerCapacity - 1f));
            offSumY += cont.Container.Weight * (cont.Offset.y * 0.2f); //TODO: Define Container Height?
        }

        CenterOfMass = new Vector2(offSumX / Weight, offSumY / Weight);
    }
}
