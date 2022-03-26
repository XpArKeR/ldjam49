using System;

using GameFrame.Core.Extensions;

using UnityEngine;
using UnityEngine.UI;

public class DescriptionValueBehaviour : MonoBehaviour
{
    private Text ValueText;
    private Text DescriptionText;

    public String Description;
    public String Value;

    // Start is called before the first frame update
    void Start()
    {
        this.DescriptionText = this.transform.FindComponentOfChildByName<Text>("ValueArea/DescriptionText");
        this.ValueText = this.transform.FindComponentOfChildByName<Text>("ValueArea/ValueText");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.DescriptionText != null)
        {
            if (this.Description != this.DescriptionText.text)
            {
                this.DescriptionText.text = this.Description;
            }
        }

        if (this.ValueText != null)
        {
            if (this.Value != this.ValueText.text)
            {
                this.ValueText.text = this.Value;
            }
        }
    }

    public void UpdateDetail(Decimal value, String format = default)
    {
        var updateValue = false;

        if ((Decimal.TryParse(this.Value, out Decimal totalValue)) && (value != totalValue))
        {
            updateValue = true;
        }
        else
        {
            updateValue = true;
        }

        if (updateValue)
        {
            if (String.IsNullOrEmpty(format))
            {
                this.Value = value.ToString();
            }
            else
            {
                this.Value = value.ToString(format);
            }
        }
    }

    public void UpdateDetail(Single value, String format = default)
    {
        var updateValue = false;

        if ((Single.TryParse(this.Value, out Single totalValue)) && (value != totalValue))
        {
            updateValue = true;
        }
        else
        {
            updateValue = true;
        }

        if (updateValue)
        {
            if (String.IsNullOrEmpty(format))
            {
                this.Value = value.ToString();
            }
            else
            {
                this.Value = value.ToString(format);
            }
        }
    }
}
