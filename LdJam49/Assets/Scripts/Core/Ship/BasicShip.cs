using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShip { 

    public float StabilityConstant1 { get; set; }
    public float StabilityConstant2 { get; set; }
    public float TiltingAngle { get; set; }
    public float Mass { get; set; }
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
        StabilityConstant1 = 1.2f;
        StabilityConstant2 = -10f;
        TiltingAngle = 20f;

        Mass = 4f;
        Damping = 3f;

        ShipLoad = new ShipLoad()
        {
            Offset = 10f,
            Weight = 300f
        };
    }
}
