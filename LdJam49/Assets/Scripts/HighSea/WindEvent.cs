using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEvent : SeaEvent
{
    public float Strength { get; set; }
    public float Direction { get; set; }

    public override bool ExecuteEvent(ShipBehaviour ShipBehaviour, float time)
    {
        float relativeEventTime = time - StartingTime;
        if (relativeEventTime > Duration)
        {
            return true;
        }

        float strength = Strength * Mathf.Sin(relativeEventTime / Duration * Mathf.PI);
        Debug.Log(strength);
        ShipBehaviour.PushSide(Direction, strength);
        return false;
    }
}
