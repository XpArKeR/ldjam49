using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteResize : MonoBehaviour
{
    public RectTransform parent;
    public SpriteRenderer sprite;


    void Start()
    {
        //parent.localScale = parent.rect.size / sprite.size * sprite.sprite.pixelsPerUnit;
    }

}
