using UnityEngine;

public class SpriteResizeFull : MonoBehaviour
{
    public RectTransform parent;
    public SpriteRenderer sprite;

    void Start()
    {
        parent.localScale = parent.rect.size / sprite.sprite.rect.size * sprite.sprite.pixelsPerUnit;
    }
}
