using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public RectTransform ShipTransform;
    public BasicShip Ship;
    private Vector3 RotationAxis;



    float ShipAngle;
    private float PreviousRotationAcceleration = 0f;

    void Start()
    {
        RotationAxis = new Vector3(0, 0, 1);
        if (Ship == null)
        {
            Ship = new BasicShip();
            Ship.SetDefaultValues();
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShipAngle = Mathf.Abs(ShipTransform.rotation.eulerAngles.z);
        RotationAxis = new Vector3(0, CalculateShipRotation(), 0);
        ShipTransform.Rotate(RotationAxis, 5);
    }

    private float CalculateShipRotation()
    {
        float rotation = PreviousRotationAcceleration;
        PreviousRotationAcceleration = CalculateRotationAcceleration() * Time.deltaTime;
        return rotation;
    }

    private float CalculateRotationAcceleration()
    {
        return (-Ship.Damping * CalculateShipRotation() - CalculateShipReaction() * ShipAngle + CalculateLoadForce()) / Ship.Mass;
    }

    private float CalculateLoadForce()
    {
        return Ship.ShipLoad.Weight * Mathf.Sin(ShipAngle + Ship.ShipLoad.Offset);
    }

    private float CalculateShipReaction()
    {
        float reaction;
        if (ShipAngle < Ship.TiltingAngle)
        {
            reaction = Ship.StabilityConstant1 * ShipAngle;
        } else
        {
            reaction = 224f + Ship.StabilityConstant2 * ShipAngle;
        }

        return reaction;
    }
}
