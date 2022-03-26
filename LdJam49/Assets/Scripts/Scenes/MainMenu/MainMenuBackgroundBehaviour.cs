using System;
using System.Collections.Generic;

using GameFrame.Core.Extensions;

using UnityEngine;

public class MainMenuBackgroundBehaviour : MonoBehaviour
{
    public List<GameObject> LightningObjects;
    public GameObject DarkLayer;

    private System.Boolean isFlashing;
    private GameObject currentLightning;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LightningObjects.Count; i++)
        {
            LightningObjects[i].SetActive(false);
        }

        DarkLayer.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlashing)
        {
            if (shouldToggle(0.9f))
            {
                isFlashing = false;
                DarkLayer.SetActive(true);
                this.currentLightning.SetActive(false);
            }
        }
        else
        {
            if (shouldToggle(0.01f))
            {
                isFlashing = true;
                this.currentLightning = this.LightningObjects.GetRandomEntry();
                this.currentLightning.SetActive(true);
                this.DarkLayer.SetActive(false);
            }
        }
    }

    private Boolean shouldToggle(Single chance)
    {
        var value = UnityEngine.Random.Range(0f, 1f);

        return value < chance;
    }
}
