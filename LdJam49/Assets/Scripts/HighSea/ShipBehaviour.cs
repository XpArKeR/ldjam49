using Assets.Scripts;
using Assets.Scripts.Constants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public RectTransform ShipTransform;
    public RectTransform MassMiddle;
    public BasicShip Ship;
    private Vector3 RotationAxis;
    private Vector2 Offset;
    private Vector2 MassMiddleVector;



    public float ShipAngle { get; private set; }
    private float Acceleration = 0f;
    private float Velocity = 0f;


    public float MaxAngle { get; private set; }
    public float MinAngle { get; private set; }

    private float SinkingTimer = -1;
    private bool Sinking = false;

    public void SinkShip()
    {
        if (!Sinking)
        {
            SinkingTimer = 5f;
            Sinking = true;
        }
    }

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
            Ship = JasonHandler.GetDefaultShip();
        }

        ShipAngle = ShipTransform.rotation.eulerAngles.z;
        if (ShipAngle > 180)
        {
            ShipAngle -= 360;
        }


        Vector2 PositionOffset = new Vector2(0, (Ship.Height / 2 - Ship.Draft) / Ship.Height * ShipTransform.rect.height);
        Offset = ScaleByLocal(PositionOffset);

        MassMiddleVector = new Vector2(Ship.EffectiveMassPoint.x * ShipTransform.rect.width - ShipTransform.rect.width / 2, Ship.EffectiveMassPoint.y * ShipTransform.rect.height - ShipTransform.rect.height / 2);
        MassMiddleVector = ScaleByLocal(MassMiddleVector);

        ShipTransform.parent.transform.position = Offset;
        this.MassMiddle.transform.position = MassMiddleVector + Offset;

        Vector2 ScaleByLocal(Vector2 PositionOffset)
        {
            return new Vector2(PositionOffset.x / ShipTransform.localScale.x, PositionOffset.y / ShipTransform.localScale.y);
        }
        CalculateBoundingAngles();
    }

    void CalculateBoundingAngles()
    {
        float hm = Ship.Height * Ship.EffectiveMassPoint.y;
        float mdhdsq = Mathf.Pow(Ship.MaxDraft - hm, 2);
        float dhm = Ship.Draft - hm;

        float wm = Ship.Width * Ship.EffectiveMassPoint.x;
        MaxAngle = CalculateAngle(mdhdsq, dhm, wm);
        MinAngle = -CalculateAngle(mdhdsq, dhm, Ship.Width - wm);
    }

    private static float CalculateAngle(float mdhdsq, float dhm, float wm)
    {
        float r = Mathf.Sqrt(Mathf.Pow(wm, 2) + mdhdsq);
        float angle = Mathf.Acos(wm / r) - Mathf.Asin(dhm / r);
        return (180 / Mathf.PI) * angle;
    }

    void Update()
    {

        ShipTransform.parent.transform.position = Offset;
        this.MassMiddle.transform.position = MassMiddleVector;
        ShipTransform.RotateAround(this.MassMiddle.transform.position, RotationAxis, Velocity * Time.deltaTime);

        if (Sinking)
        {
            if (SinkingTimer > 0)
            {

                ShipTransform.parent.transform.position -= new Vector3(0f, -10f * Time.deltaTime, 0);
                SinkingTimer = SinkingTimer - Time.deltaTime;
            } else
            {
                Core.ChangeScene(SceneNames.GameOver);
            }
        } else
        {
            ShipAngle += Velocity * Time.deltaTime;
            Velocity += Acceleration * Time.deltaTime;

            float RotationAcceleration = CalculateRotationAcceleration();
            Acceleration = RotationAcceleration;
        }




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
