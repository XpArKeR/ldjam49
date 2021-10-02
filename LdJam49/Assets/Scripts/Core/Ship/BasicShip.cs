using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShip
{   
    private float StabilityConstant1;
    private float StabilityConstant2;
    private float TiltingAngle;
    private float Mass;
    private float Damping;

    public float MyProperty { get; set; }

    private ShipLoad ShipLoad;


    public void SetDefaultValues()
    {
        StabilityConstant1 = 1.2f;
        StabilityConstant2 = -10f;
        TiltingAngle = 20f;

        Mass = 1f;
        Damping = 2f;

    }
}
