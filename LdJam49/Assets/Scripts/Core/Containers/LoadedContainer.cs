using UnityEngine;

public class LoadedContainer
{
    [SerializeField]
    private BasicContainer container;
    public BasicContainer Container
    {
        get
        {
            return this.container;
        }
        set
        {
            if (this.container != value)
            {
                this.container = value;
            }
        }
    }

    [SerializeField]
    private Vector2 offset;
    public Vector2 Offset
    {
        get
        {
            return this.offset;
        }
        set
        {
            if (this.offset != value)
            {
                this.offset = value;
            }
        }
    }
}
