using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WindEvent : SeaEvent
{

    [SerializeField]
    private float strength;
    public float Strength
    {
        get
        {
            return this.strength;
        }
        set
        {
            if (this.strength != value)
            {
                this.strength = value;
            }
        }
    }

    [SerializeField]
    private float direction;
    public float Direction
    {
        get
        {
            return this.direction;
        }
        set
        {
            if (this.direction != value)
            {
                this.direction = value;
            }
        }
    }

    private float DurationPI;

    private float GetDurationPI()
    {
        if (DurationPI == default)
        {
            DurationPI = Duration / Mathf.PI;
        }
        return DurationPI;
    }

    public override bool ExecuteEvent(ShipBehaviour ShipBehaviour, float time)
    {
        float relativeEventTime = time - StartingTime;
        if (relativeEventTime > Duration)
        {
            return true;
        }

        float strength = Strength * Mathf.Sin(relativeEventTime / GetDurationPI());
        ShipBehaviour.PushSide(Direction, strength);
        return false;
    }
}
