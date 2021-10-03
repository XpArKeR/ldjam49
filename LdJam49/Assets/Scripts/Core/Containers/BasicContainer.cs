using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicContainer 
{
    [SerializeField]
    private float weigth;
    public float Weight
    {
        get
        {
            return this.weigth;
        }
        set
        {
            if (this.weigth != value)
            {
                this.weigth = value;
            }
        }
    }

    [SerializeField]
    private Color color;
    public Color Color
    {
        get
        {
            return this.color;
        }
        set
        {
            if (this.color != value)
            {
                this.color = value;
            }
        }
    }
}
