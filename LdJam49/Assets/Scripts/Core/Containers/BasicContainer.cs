using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicContainer 
{
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
}
