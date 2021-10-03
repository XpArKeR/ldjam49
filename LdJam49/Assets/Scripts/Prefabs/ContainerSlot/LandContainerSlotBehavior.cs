
using System;

using UnityEngine;
using UnityEngine.Events;

public class LandContainerSlotBehavior : MonoBehaviour
{
    public UnityEvent<LandContainerSlotBehavior> ContainerClicked;
    public SpriteRenderer SpriteRenderer;

    public BasicContainer Container;
    public Vector2 Offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.Container?.Color != default)
        {
            if (this.SpriteRenderer.color != this.Container.Color)
            {
                this.SpriteRenderer.color = this.Container.Color;
            }
        }
    }

    private void OnMouseDown()
    {
        ContainerClicked?.Invoke(this);
    }
}
