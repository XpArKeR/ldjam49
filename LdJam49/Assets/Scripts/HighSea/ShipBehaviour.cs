using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public RectTransform ShipTransform;
    public BasicShip Ship;
    private Vector3 RotationAxis;



    float ShipAngle;
    private float Acceleration = 0f;
    private float Velocity = 0f;



    void Start()
    {
        RotationAxis = new Vector3(0, 0, 1);
        if (Ship == null)
        {
            Ship = new BasicShip();
            Ship.SetDefaultValues();
        }

        ShipAngle = ShipTransform.rotation.eulerAngles.z;
        if (ShipAngle > 180)
        {
            ShipAngle -= 360;
        }


    }

    // Update is called once per frame
    void Update()
    {

        ShipTransform.Rotate(RotationAxis, Velocity * Time.deltaTime);


        ShipAngle += Velocity * Time.deltaTime;
        Velocity += Acceleration * Time.deltaTime;

        float RotationAcceleration = CalculateRotationAcceleration();
        //Debug.Log(Time.deltaTime + " " + ShipAngle + "  " + Velocity + " " + RotationAcceleration + " " + CalculateShipReaction() + " " + CalculateLoadForce());
        Acceleration = RotationAcceleration;
    }



    private float CalculateRotationAcceleration()
    {
        return (-Ship.Damping * Velocity - CalculateShipReaction() * ShipAngle + CalculateLoadForce()) / Ship.Mass;
    }

    private float CalculateLoadForce()
    {

        float radians = (Mathf.PI / 180) * (ShipAngle + Ship.ShipLoad.Offset);
        return Ship.ShipLoad.Weight * Mathf.Sin(radians);
    }

    private float CalculateShipReaction()
    {
        float reaction;
        float absAngle = Mathf.Abs(ShipAngle);
        if (absAngle < Ship.TiltingAngle)
        {
            reaction = Ship.StabilityConstant1 * absAngle;
        } else
        {
            reaction = Ship.StabilityOffset + Ship.StabilityConstant2 * absAngle;
        }

        
        return Mathf.Max(reaction, 0);
    }
}
