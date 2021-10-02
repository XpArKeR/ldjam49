using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteResize : MonoBehaviour
{
    public RectTransform parent;
    public SpriteRenderer sprite;


    void Start()
    {
        float hightScale = parent.rect.size.y / sprite.sprite.rect.size.y * sprite.sprite.pixelsPerUnit / 2;
        parent.localScale = new Vector2(hightScale, hightScale);
    }

}
