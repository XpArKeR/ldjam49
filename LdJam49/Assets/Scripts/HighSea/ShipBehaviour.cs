using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    public RectTransform ShipTransform;
    public BasicShip Ship;
    private Vector3 RotationAxis;
    private 

    void Start()
    {
        RotationAxis = new Vector3(0, 0, 1);
        if (Ship == null)
        {
            Ship = new BasicShip();
            Ship.SetDefaultValues();
        }
    }

    // Update is called once per frame
    void Update()
    {

        //RotationAxis = new Vector3(0, calculateRotation(), 0) * Time.deltaTime;
        ShipTransform.Rotate(RotationAxis, 5);
    }

    //private float calculateRotation()
    //{
    //    float rotation;
    //    if (ShipTransform.rotation.eulerAngles.z < Ship.)


    //    return rotation;
    //    = MAX(IF(ABS(B14) <$E$4,$E$2 * ABS(B14),$E$5 +$E$3 * ABS(B14)), 0)
    //}
}
