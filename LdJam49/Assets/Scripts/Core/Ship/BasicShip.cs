using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShip {

    public float Width { get; set; }
    public float Height { get; set; }
    public float MaxDraft { get; set; } //how deep the ship can go into the water
    public float Buoyancy { get; set; }

    private float _Draft;
    public float Draft
    {
        get
        {
            if (_Draft == default)
            {
                _Draft = (Mass + ShipLoad.Weight) / Buoyancy;
            }
            return _Draft;
        }
    }


    private Vector2 _EffectiveMassPoint;
    public Vector2 EffectiveMassPoint
    {
        get
        {
            if (_EffectiveMassPoint == default)
            {
                float massTotal = Mass + ShipLoad.Weight;
                _EffectiveMassPoint = (Mass * RelativeCenterOfMass + ShipLoad.Weight * ShipLoad.CenterOfMass) / massTotal;

            }
            return _EffectiveMassPoint;
        }
    }


    public float StabilityConstant1 { get; set; }
    public float StabilityConstant2 { get; set; }
    public float TiltingAngle { get; set; }
    public float Mass { get; set; }
    public Vector2 RelativeCenterOfMass { get; set; }
    public float Damping { get; set; }

    private float _StabilityOffset;
    public float StabilityOffset { 
        get
        { 
            if (_StabilityOffset == default)
            {
                _StabilityOffset = (StabilityConstant1 - StabilityConstant2) * TiltingAngle;
            }
            return _StabilityOffset;
        }
    }


    public ShipLoad ShipLoad { get; set; }


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
            Offset = 0f,
            CenterOfMass = new Vector2(.5f, 0.4f),
            Weight = 300f
        };
    }
}
