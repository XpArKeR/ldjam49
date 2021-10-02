using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUpdater : MonoBehaviour
{
    public Text timeDisplay;

    void Start()
    {
        timeDisplay.text = Time.time.ToString("0:##0.00");
    }

    void Update()
    {
        timeDisplay.text = Time.time.ToString("0:##0.00");
    }
}
