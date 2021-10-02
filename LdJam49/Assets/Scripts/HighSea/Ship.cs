using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public RectTransform ShipTransform;
    private Vector3 RotationAxis;
    void Start()
    {
        RotationAxis = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        ShipTransform.Rotate(RotationAxis, 5);
    }
}
