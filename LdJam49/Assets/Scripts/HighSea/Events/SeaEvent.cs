using System;

using UnityEngine;

[Serializable]
public abstract class SeaEvent
{
    [SerializeField]
    private string eventName;
    public string EventName
    {
        get
        {
            return this.eventName;
        }
        set
        {
            if (this.eventName != value)
            {
                this.eventName = value;
            }
        }
    }

    [SerializeField]
    private float duration;
    public float Duration
    {
        get
        {
            return this.duration;
        }
        set
        {
            if (this.duration != value)
            {
                this.duration = value;
            }
        }
    }

    [SerializeField]
    private float startingTime;
    public float StartingTime
    {
        get
        {
            return this.startingTime;
        }
        set
        {
            if (this.startingTime != value)
            {
                this.startingTime = value;
            }
        }
    }


    public abstract bool ExecuteEvent(ShipBehaviour ShipBehaviour, float time);

    public abstract void init(GameObject parent);

}
