using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerSlotBehavior : MonoBehaviour
{
    public Port Port;
    public BasicContainer Container;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        this.Port.OnSlotMouseEnter(this);
    }

    private void OnMouseExit()
    {
        this.Port.OnSlotMouseExit(this);
    }
}
