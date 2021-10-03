using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerSlotBehavior : MonoBehaviour
{
    public Port Port;
    public BasicContainer Container;
    public Color ImageOverlayColor;
    public SpriteRenderer SpriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (this.SpriteRenderer.color != this.ImageOverlayColor)
        //{
        //    this.SpriteRenderer.color = this.ImageOverlayColor;
        //}
    }

    private void OnMouseDown()
    {
        this.Port.SelectContainer(this);   
    }
}
