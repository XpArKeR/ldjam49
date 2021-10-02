using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public RectTransform ShipTransform;
    public BasicShip Ship;
    private Vector3 RotationAxis;
    private Vector2 Offset;



    public float ShipAngle { get; private set; }
    private float Acceleration = 0f;
    private float Velocity = 0f;


    public void PushSide(float Direction, float Strength)
    {
        float pushAcceleration = Direction * Strength / Ship.Mass;
        Acceleration += pushAcceleration;
    }

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


        Vector2 PositionOffset = new Vector2(0, -Ship.Draft / Ship.Height * ShipTransform.rect.height);

        Offset = new Vector2(PositionOffset.x / ShipTransform.localScale.x, PositionOffset.y / ShipTransform.localScale.y);

        //Vector3 PositionOffset = new Vector3(0, -Ship.Draft / Ship.Height, 0);
        //Debug.Log("Offset: " + PositionOffset);

        Vector2 target = (Vector2)ShipTransform.position + Offset;

        ShipTransform.position = Vector2.MoveTowards(ShipTransform.position, target, 50000);

        Debug.Log(ShipTransform.rect.y);
    }

    // Update is called once per frame
    void Update()
    {
        ShipTransform.RotateAround(Ship.EffectiveMassPoint + Offset, RotationAxis, Velocity * Time.deltaTime);


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
        }
        else
        {
            reaction = Ship.StabilityOffset + Ship.StabilityConstant2 * absAngle;
        }


        return Mathf.Max(reaction, 0);
    }
}
