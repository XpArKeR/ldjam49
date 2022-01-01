using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextResizer : MonoBehaviour
{
    public Text text;
    private static int fontSize;

    void Start()
    {
        text.fontSize = GetFontSize();
    }

    public static int GetFontSize()
    {
        if (fontSize == default)
        {
            fontSize = Screen.height / 20;
        }
        return fontSize;
    }
}
