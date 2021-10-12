using System;

using Assets.Scripts.Extensions;

using UnityEngine;
using UnityEngine.UI;

public class ShipDetailsBehaviour : MonoBehaviour
{
    public ShipLoad ShipLoad;
    public String Title;

    private Text TitleText;
    private DescriptionValueBehaviour TotalValue;
    private DescriptionValueBehaviour TotalWeight;

    // Start is called before the first frame update
    void Start()
    {
        this.TitleText = this.transform.FindComponentOfChildByName<Text>("TitleText");
        this.TotalValue = this.transform.FindComponentOfChildByName<DescriptionValueBehaviour>("TotalValueTextEdit");
        this.TotalWeight = this.transform.FindComponentOfChildByName<DescriptionValueBehaviour>("TotalWeightTextEdit");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.ShipLoad != default)
        {
            this.UpdateShipDetails();
        }

        if (this.TitleText != null)
        {
            if (this.TitleText.text != this.Title)
            {
                this.TitleText.text = this.Title;
            }
        }
    }

    private void UpdateShipDetails()
    {
        this.TotalValue?.UpdateDetail(ShipLoad.Value, "C");
        this.TotalWeight?.UpdateDetail(ShipLoad.Weight, "####0.0t");
    }
}
