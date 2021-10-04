
using System;

using UnityEngine;
using UnityEngine.Events;

public class LandContainerSlotBehaviour : MonoBehaviour
{
    public UnityEvent<LandContainerSlotBehaviour> ContainerClicked;
    public SpriteRenderer ContainerSpriteRenderer;
    public SpriteRenderer ArrowSpriteRenderer;
    public GameObject ArrowSprite;

    public BasicContainer Container;
    public Vector2 Offset;

    public Boolean IsSelected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.IsSelected)
        {
            this.ArrowSprite.SetActive(true);
        }
        else if (this.ArrowSprite.activeSelf)
        {
            this.ArrowSprite.SetActive(false);
        }

        if (this.Container?.Color != default)
        {
            if (this.ContainerSpriteRenderer.color != this.Container.Color)
            {
                this.ContainerSpriteRenderer.color = this.Container.Color;
                this.ArrowSpriteRenderer.color = this.Container.Color;
            }
        }
    }

    private void OnMouseDown()
    {
        ContainerClicked?.Invoke(this);
    }
}
