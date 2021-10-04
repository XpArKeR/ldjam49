using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthEvent : SeaEvent
{
    [SerializeField]
    private float depthZero;
    public float DepthZero
    {
        get
        {
            return this.depthZero;
        }
        set
        {
            if (this.depthZero != value)
            {
                this.depthZero = value;
            }
        }
    }

    [SerializeField]
    private float gradientUp;
    public float GradientUp
    {
        get
        {
            return this.gradientUp;
        }
        set
        {
            if (this.gradientUp != value)
            {
                this.gradientUp = value;
            }
        }
    }

    [SerializeField]
    private float gradientDown;
    public float GradientDown
    {
        get
        {
            return this.gradientDown;
        }
        set
        {
            if (this.gradientDown != value)
            {
                this.gradientDown = value;
            }
        }
    }

    [SerializeField]
    private float minWaterDepth;
    public float MinWaterDepth
    {
        get
        {
            return this.minWaterDepth;
        }
        set
        {
            if (this.minWaterDepth != value)
            {
                this.minWaterDepth = value;
            }
        }
    }

    [SerializeField]
    private float minDepthDuration;
    public float MinDepthDuration
    {
        get
        {
            return this.minDepthDuration;
        }
        set
        {
            if (this.minDepthDuration != value)
            {
                this.minDepthDuration = value;
            }
        }
    }


    public override bool ExecuteEvent(ShipBehaviour ShipBehaviour, float time)
    {
        float relativeEventTime = time - StartingTime;
        if (relativeEventTime > Duration)
        {
            return true;
        }

        
        //TODO
        return false;
    }

    public override void init(GameObject parent)
    {
        Debug.Log("Implement init for wind");
    }

}
