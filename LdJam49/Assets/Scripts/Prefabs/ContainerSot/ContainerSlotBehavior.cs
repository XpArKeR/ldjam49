
using UnityEngine;

public class ContainerSlotBehavior : MonoBehaviour
{
    public Port Port;
    public BasicContainer Container;
    public SpriteRenderer SpriteRenderer;

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
        this.Port.SelectContainer(this);
    }
}
