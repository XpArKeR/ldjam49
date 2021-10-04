
using UnityEngine;
using UnityEngine.Events;

public class ShipContainerSlotBehaviour : MonoBehaviour
{
    public UnityEvent<ShipContainerSlotBehaviour> ContainerClicked;
    public SpriteRenderer SpriteRenderer;

    public LoadedContainer LoadedContainer;
    public Vector2 Offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.LoadedContainer?.Container?.Color != default)
        {
            if (this.SpriteRenderer.color != this.LoadedContainer.Container.Color)
            {
                this.SpriteRenderer.color = this.LoadedContainer.Container.Color;
            }
        }
    }

    private void OnMouseDown()
    {
        ContainerClicked?.Invoke(this);
    }
}
