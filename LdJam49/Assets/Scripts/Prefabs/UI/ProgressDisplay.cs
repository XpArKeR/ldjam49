using Assets.Scripts.Base;

using UnityEngine;
using UnityEngine.UI;

public class ProgressDisplay : MonoBehaviour
{

    public RectTransform displayImage;
    private RectTransform parent;
    private float percentMoved;
    private bool isMoving = false;
    private float offset;
    private float halfOffset;
    private float oneMinusOffset;
    private float movmentSpeed;


    void Start()
    {

        parent = displayImage.parent.GetComponent<RectTransform>();

        Image image = displayImage.GetComponent<Image>();


        float heightScale = image.sprite.rect.height / parent.rect.height;
        float widthScale = image.sprite.rect.width / parent.rect.width;

        if (heightScale > 1)
        {
            offset = widthScale / heightScale;
        }
        else
        {
            offset = heightScale / widthScale;
        }

        halfOffset = offset / 2;

        oneMinusOffset = 1 - offset;

        displayImage.anchorMin = new Vector2(halfOffset, 0f);
        displayImage.anchorMax = new Vector2(halfOffset + offset, 1f);
        StartMoving();
    }

    void Update()
    {
        if (isMoving)
        {
            if (percentMoved > oneMinusOffset)
            {
                StopMoving();
                return;
            }
            float deltaMove = movmentSpeed * Time.deltaTime;
            percentMoved += deltaMove;

            displayImage.anchorMin = new Vector2(percentMoved, 0f);
            displayImage.anchorMax = new Vector2(percentMoved + offset, 1f);

        }
    }

    private void StopMoving()
    {
        isMoving = false;
    }

    public void StartMoving()
    {
        float finishTime;
        try
        {
            finishTime = LevelManager.GetLevel(Core.Game.State.CurrentLevel).Length;
        }
        catch
        {
            finishTime = 30;
            Debug.Log("Could not load level for progress display");
        }

        isMoving = true;
        movmentSpeed = (1 - offset) / finishTime;
        percentMoved = 0;
    }

}
