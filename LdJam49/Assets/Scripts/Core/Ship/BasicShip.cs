
using System;

using Newtonsoft.Json;

using UnityEngine;

public class BasicShip
{

    public BasicShip()
    {
    }

    [SerializeField]
    private float width;
    public float Width
    {
        get
        {
            return this.width;
        }
        set
        {
            if (this.width != value)
            {
                this.width = value;
            }
        }
    }

    [SerializeField]
    private float height;
    public float Height
    {
        get
        {
            return this.height;
        }
        set
        {
            if (this.height != value)
            {
                this.height = value;
            }
        }
    }

    [SerializeField]
    private float maxDraft;
    /// <summary>
    /// how deep the ship can go into the water
    /// </summary>
    public float MaxDraft
    {
        get
        {
            return this.maxDraft;
        }
        set
        {
            if (this.maxDraft != value)
            {
                this.maxDraft = value;
            }
        }
    }

    [SerializeField]
    private float buoyancy;
    /// <summary>
    /// how deep the ship can go into the water
    /// </summary>
    public float Buoyancy
    {
        get
        {
            return this.buoyancy;
        }
        set
        {
            if (this.buoyancy != value)
            {
                this.buoyancy = value;
            }
        }
    }

    [JsonIgnore]
    private float draft;
    [JsonIgnore]
    public float Draft
    {
        get
        {
            //            if (draft == default)
            //            {
            draft = (Mass + ShipLoad.Weight) / Buoyancy;
            //            }

            return draft;
        }
    }
        
    [JsonIgnore]
    private Vector2 effectuveMassPoint;
    [JsonIgnore]
    public Vector2 EffectiveMassPoint
    {
        get
        {
            if (effectuveMassPoint == default)
            {
                float massTotal = Mass + ShipLoad.Weight;
                effectuveMassPoint = (Mass * RelativeCenterOfMass + ShipLoad.Weight * ShipLoad.CenterOfMass) / massTotal;

            }
            return effectuveMassPoint;
        }
    }

    [SerializeField]
    private float stabilityConstant1;
    /// <summary>
    /// how deep the ship can go into the water
    /// </summary>
    public float StabilityConstant1
    {
        get
        {
            return this.stabilityConstant1;
        }
        set
        {
            if (this.stabilityConstant1 != value)
            {
                this.stabilityConstant1 = value;
            }
        }
    }

    [SerializeField]
    private float stabilityConstant2;
    public float StabilityConstant2
    {
        get
        {
            return this.stabilityConstant2;
        }
        set
        {
            if (this.stabilityConstant2 != value)
            {
                this.stabilityConstant2 = value;
            }
        }
    }

    [SerializeField]
    private float tiltingAngle;
    public float TiltingAngle
    {
        get
        {
            return this.tiltingAngle;
        }
        set
        {
            if (this.tiltingAngle != value)
            {
                this.tiltingAngle = value;
            }
        }
    }

    [SerializeField]
    private float mass;
    public float Mass
    {
        get
        {
            return this.mass;
        }
        set
        {
            if (this.mass != value)
            {
                this.mass = value;
            }
        }
    }

    [JsonProperty]
    private float relativeCenterOfMassX;
    [JsonProperty]
    private float relativeCenterOfMassY;

    [JsonIgnore]
    private Vector2 relativeCenterOfMass;
    [JsonIgnore]
    public Vector2 RelativeCenterOfMass
    {
        get
        {
            if (relativeCenterOfMass == default)
            {
                relativeCenterOfMass = new Vector2(relativeCenterOfMassX, relativeCenterOfMassY);
            }
            return this.relativeCenterOfMass;
        }
        set
        {
            if (this.relativeCenterOfMass != value)
            {
                relativeCenterOfMassX = value.x;
                relativeCenterOfMassY = value.y;
            }
        }
    }

    [SerializeField]
    private float damping;
    public float Damping
    {
        get
        {
            return this.damping;
        }
        set
        {
            if (this.damping != value)
            {
                this.damping = value;
            }
        }
    }

    [SerializeField]
    private Int32 containerCapacity = 6;
    public Int32 ContainerCapacity
    {
        get
        {
            return this.containerCapacity;
        }
        set
        {
            if (this.containerCapacity != value)
            {
                this.containerCapacity = value;
            }
        }
    }

    [JsonIgnore]
    private float stabilityOffset;
    [JsonIgnore]
    public float StabilityOffset
    {
        get
        {
            if (stabilityOffset == default)
            {
                stabilityOffset = (StabilityConstant1 - StabilityConstant2) * TiltingAngle;
            }

            return stabilityOffset;
        }
    }

    [SerializeField]
    private ShipLoad shipLoad;
    public ShipLoad ShipLoad
    {
        get
        {
            return this.shipLoad;
        }
        set
        {
            if (this.shipLoad != value)
            {
                this.shipLoad = value;
            }
        }
    }

    [JsonIgnore]
    private float offset;
    [JsonIgnore]
    public float Offset
    {
        get
        {
            float offsetX = (shipLoad.CenterOfMass.x - relativeCenterOfMass.x) / 0.5f;
            offset = 20 * offsetX; //TODO: Define Max Offset
                                   //          offset = shipLoad.Weight * (shipLoad.CenterOfMass.x - relativeCenterOfMass.x) * Width / 200;
            return this.offset;
        }

    }

    [JsonIgnore]
    public float MaxAngle { get; private set; }
    [JsonIgnore]
    public float MinAngle { get; private set; }

    [SerializeField]
    private float draftDrawingFactor;
    public float DraftDrawingFactor
    {
        get
        {
            return this.draftDrawingFactor;
        }
        set
        {
            if (this.draftDrawingFactor != value)
            {
                this.draftDrawingFactor = value;
            }
        }
    }

    public void Unload()
    {
        this.ShipLoad = new ShipLoad();

        CalculateBoundingAngles();
    }

    public void AddContainer(LoadedContainer container)
    {
        this.ShipLoad.Weight += container.Container.Weight;

        this.ShipLoad.Containers.Add(container);

        float offSumX = 0;
        float offSumY = 0;
        foreach (var cont in this.ShipLoad.Containers)
        {
            offSumX += cont.Container.Weight * (cont.Offset.x / (this.ContainerCapacity - 1f));
            offSumY += cont.Container.Weight * (cont.Offset.y * 0.2f); //TODO: Define Container Height?
        }

        this.ShipLoad.CenterOfMass = new Vector2(offSumX / this.ShipLoad.Weight, offSumY / this.ShipLoad.Weight);
        //        Debug.Log("ShipLoad: x= " + (offSumX / Weight) + " y = " + (offSumY / Weight) + " CenterOfMass = " + CenterOfMass.x);

        CalculateBoundingAngles();
    }

    public void CalculateBoundingAngles()
    {
        //float hm = Ship.Height * 0.5f;
        //float hm = Ship.Height * Ship.EffectiveMassPoint.y;
        float hm = Height * RelativeCenterOfMass.y;
        float mdhdsq = Mathf.Pow(MaxDraft - hm, 2);
        float dhm = Draft - hm;

        //float wm = Ship.Width * Ship.EffectiveMassPoint.x;
        float wm = Width * RelativeCenterOfMass.x;
        //float wm = Ship.Width * 0.5f;
        MaxAngle = CalculateAngle(mdhdsq, dhm, wm);
        MinAngle = -CalculateAngle(mdhdsq, dhm, Width - wm);
//        Debug.Log("Draft: " + Draft + ", Limit Angles: " + MinAngle + " " + MaxAngle);
    }

    private static float CalculateAngle(float mdhdsq, float dhm, float wm)
    {
        float r = Mathf.Sqrt(Mathf.Pow(wm, 2) + mdhdsq);
        float angle = Mathf.Acos(wm / r) - Mathf.Asin(dhm / r);
        return (180 / Mathf.PI) * angle;
    }
}
