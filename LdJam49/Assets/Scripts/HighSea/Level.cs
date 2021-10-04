using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using UnityEngine;

[Serializable]
public class Level
{
    [SerializeField]
    private string name;
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (this.name != value)
            {
                this.name = value;
            }
        }
    }

    [SerializeField]
    private string start;
    public string Start
    {
        get
        {
            return this.start;
        }
        set
        {
            if (this.start != value)
            {
                this.start = value;
            }
        }
    }

    [SerializeField]
    private string destination;
    public string Destination
    {
        get
        {
            return this.destination;
        }
        set
        {
            if (this.destination != value)
            {
                this.destination = value;
            }
        }
    }

    [SerializeField]
    private List<SeaEvent> events;
    public List<SeaEvent> Events
    {
        get
        {
            return this.events;
        }
        set
        {
            if (this.events != value)
            {
                this.events = value;
            }
        }
    }

    [SerializeField]
    private float waterDepth;
    public float WaterDepth
    {
        get
        {
            return this.waterDepth;
        }
        set
        {
            if (this.waterDepth != value)
            {
                this.waterDepth = value;
            }
        }
    }

    [SerializeField]
    private float length;
    public float Length
    {
        get
        {
            return this.length;
        }
        set
        {
            if (this.length != value)
            {
                this.length = value;
            }
        }
    }

    [JsonIgnore]
    public Boolean IsLast { get; set; }
}
