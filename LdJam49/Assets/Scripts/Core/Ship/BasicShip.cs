using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShip { 

    public float StabilityConstant1 { get; set; }
    public float StabilityConstant2 { get; set; }
    public float TiltingAngle { get; set; }
    public float Mass { get; set; }
    public float Damping { get; set; }


    public ShipLoad ShipLoad { get; set; }


    public void SetDefaultValues()
    {
        StabilityConstant1 = 1.2f;
        StabilityConstant2 = -10f;
        TiltingAngle = 20f;

        Mass = 1f;
        Damping = 2f;

        ShipLoad = new ShipLoad();

        ShipLoad.Offset = 20f;
        ShipLoad.Weight = 300f;
    }
}
