using Newtonsoft.Json;

using UnityEngine;

public class DepthEvent : SeaEvent
{
    [JsonIgnore]
    private GameObject Ground;


    private float Depth;
    private float LastDepth;
    private float TimeMinDepth = 0;

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

        if (TimeMinDepth == default && Depth >= MinWaterDepth)
        {
            Depth = depthZero - relativeEventTime * GradientUp;
            if (Depth <= MinWaterDepth)
            {
                Depth = MinWaterDepth;
                TimeMinDepth = relativeEventTime;
            }
        }
        else if (relativeEventTime < TimeMinDepth + MinDepthDuration)
        {
            Depth = MinWaterDepth;
        }
        else
        {
            Depth = Mathf.Min(MinWaterDepth + (relativeEventTime - (TimeMinDepth + MinDepthDuration)) * GradientDown, depthZero);
        }
        Ground.transform.Translate(new Vector3(0, -(Depth - LastDepth) / 20f, 0));
//        Debug.Log(this.EventName + " Depth: " + Depth + " Delta: " + (Depth - LastDepth));
        ShipBehaviour.WaterDepth = Depth;
        LastDepth = Depth;
        //TODO
        return false;
    }

    public override void init(GameObject ground)
    {
        Ground = ground;

        LastDepth = DepthZero;
        Depth = DepthZero;
    }

}
