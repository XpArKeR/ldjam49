using System;

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
    private Decimal value;
    public Decimal Value
    {
        get
        {
            return this.value;
        }
        set
        {
            if (this.value != value)
            {
                this.value = value;
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
