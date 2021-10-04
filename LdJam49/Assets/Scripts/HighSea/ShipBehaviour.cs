using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public RectTransform ShipTransform;
    public RectTransform MassMiddle;
    public BasicShip Ship;
    private Vector3 RotationAxis;
    private Vector2 Offset;
    private Vector2 MassMiddleVector;
    private Vector2 StartVector;



    public float ShipAngle { get; private set; }
    private float Acceleration = 0f;
    private float Velocity = 0f;
    //Draft Calculation States
    private float Draft = 0f;
    private float DraftVelocity = 0f;
    private float DraftAcceleration = 0f;

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


        StartShip(Core.GameState?.Ship, 0);

    }

    void StartShip(BasicShip newShip, float startAngle)
    {
        Ship = newShip;
        if (Ship == null)
        {
            Ship = ShipManager.GetDefaultShip();
        }

        ShipAngle = startAngle;

        Offset = new Vector2(0, (Ship.Height / 2 - Ship.Draft) / Ship.Height * ShipTransform.rect.height);
        //Offset = ScaleByLocal(PositionOffset);

        MassMiddleVector = new Vector2(Ship.RelativeCenterOfMass.x + ShipTransform.position.x, Ship.RelativeCenterOfMass.y);
        //MassMiddleVector = new Vector2(Ship.EffectiveMassPoint.x * ShipTransform.rect.width - ShipTransform.rect.width / 2, Ship.EffectiveMassPoint.y * ShipTransform.rect.height - ShipTransform.rect.height / 2);
        //MassMiddleVector = ScaleByLocal(MassMiddleVector);

        Draft = 0;
//        TranslateByDraftDelta(-Draft);
//        Debug.Log("Set Draft = " + Draft);


        //ShipTransform.parent.transform.position = Offset;
        if (this.MassMiddle != default)
            this.MassMiddle.transform.position = MassMiddleVector + Offset;

    }

    void Update()
    {

        if (Sinking)
        {
            if (SinkingTimer > 0)
            {
                ShipTransform.parent.transform.position -= new Vector3(0f, 3f * Time.deltaTime, 0);
                SinkingTimer = SinkingTimer - Time.deltaTime;
            }
            else
            {
                Core.ChangeScene(SceneNames.GameOver);
            }
        }

        //ShipTransform.parent.transform.position = Offset;
        if (this.MassMiddle != default)
        {
            this.MassMiddle.transform.position = MassMiddleVector;
        }
        ShipTransform.RotateAround(MassMiddleVector, RotationAxis, Velocity * Time.deltaTime);

        //ShipTransform.Rotate(RotationAxis, Velocity * Time.deltaTime);
        UpdateDraftValue();

        ShipAngle += Velocity * Time.deltaTime;
        Velocity += Acceleration * Time.deltaTime;

        float RotationAcceleration = CalculateRotationAcceleration();
        Acceleration = RotationAcceleration;

    }



    private float CalculateRotationAcceleration()
    {
        return (-Ship.Damping * Velocity - CalculateShipReaction() * ShipAngle + CalculateLoadForce()) / Ship.Mass;
    }

    private float CalculateLoadForce()
    {

        // float radians = (Mathf.PI / 180) * (ShipAngle + Ship.ShipLoad.Offset);
        float radians = (Mathf.PI / 180) * (ShipAngle - Ship.Offset);
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

    private void UpdateDraftValue()
    {
        DraftVelocity += Time.deltaTime * DraftAcceleration;
        float lastDraft = Draft;
        Draft += Time.deltaTime * DraftVelocity;
        TranslateByDraftDelta(Draft - lastDraft);

        //Calculation like a Spring-Damper-System

        var delta = Ship.Draft - Draft;
        var totalShipMass = (Ship.Mass + Ship.ShipLoad.Weight);
        var dampingFactor = 1f * totalShipMass; //Experimental

        float draftForce = Ship.Buoyancy * delta - 1.5f * totalShipMass * DraftVelocity;
        DraftAcceleration = draftForce / totalShipMass;

//        Debug.Log("Ship Draft:  Draft = " + Draft + " Delta = " + delta + " mass = " + totalShipMass + " buoyancy = "+Ship.Buoyancy + " Force = " + draftForce + " Acceleration = " + DraftAcceleration);

    }

    private void TranslateByDraftDelta(float delta)
    {
        ShipTransform.Translate(new Vector3(0, -(delta) / Ship.DraftDrawingFactor, 0)); // Division by Twenty is just a try
    }
}
