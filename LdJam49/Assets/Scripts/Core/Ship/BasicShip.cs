
using Newtonsoft.Json;
using UnityEngine;

public class BasicShip
{

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
            if (draft == default)
            {
                draft = (Mass + ShipLoad.Weight) / Buoyancy;
            }

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
            if (offset == default)
            {
                offset = shipLoad.Weight * (shipLoad.CenterOfMass.x - relativeCenterOfMass.x) * Width / 200;
            }
            return this.offset;
        }

    }

    public void SetDefaultValues()
    {
        Width = 195;
        Height = 170;
        MaxDraft = 118;
        Buoyancy = 40;
        RelativeCenterOfMass = new Vector2(0.5f, 0.5f);

        StabilityConstant1 = 1.2f;
        StabilityConstant2 = -10f;
        TiltingAngle = 20f;

        Mass = 4f;
        Damping = 3f;

        ShipLoad = new ShipLoad()
        {
            CenterOfMass = new Vector2(.5f, 0.4f),
            Weight = 300f
        };
    }
}
