
using System;

using Assets.Scripts.Extensions;

using UnityEngine;
using UnityEngine.UI;

public class ContainerDetailsBehaviour : MonoBehaviour
{
    public String Title;

    private Text TitleText;
    private DescriptionValueBehaviour totalValue;
    private DescriptionValueBehaviour totalWeight;

    private BasicContainer container;
    public BasicContainer Container
    {
        get
        {
            return this.container;
        }
        set
        {
            if (this.container != value)
            {
                this.container = value;
                this.UpdateContainerInformation();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.TitleText = this.transform.FindComponentOfChildByName<Text>("TitleText");
        this.totalValue = this.transform.FindComponentOfChildByName<DescriptionValueBehaviour>("ValueTextEdit");
        this.totalWeight = this.transform.FindComponentOfChildByName<DescriptionValueBehaviour>("WeightTextEdit");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.TitleText != null)
        {
            if (this.TitleText.text != this.Title)
            {
                this.TitleText.text = this.Title;
            }
        }
    }

    private void UpdateContainerInformation()
    {
        this.totalValue?.UpdateDetail(container.Value, "C");
        this.totalWeight?.UpdateDetail(container.Weight, "####0.0t");
    }
}
