using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEvent : SeaEvent
{
    public float Strength { get; set; }
    public float Direction { get; set; }

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
