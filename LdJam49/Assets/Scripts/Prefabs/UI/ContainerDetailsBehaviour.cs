using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContainerDetailsBehaviour : MonoBehaviour
{
    public Text ValueText;
    public Text WeightText;

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

    private void UpdateContainerInformation()
    {
        if (this.Container != default)
        {
            this.ValueText.text = this.Container.Value.ToString("C");
            this.WeightText.text = this.Container.Weight.ToString("####0.0t");
        }
        else
        {
            this.ValueText.text = "";
            this.WeightText.text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
