using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStormEvent : SeaEvent
{
    [JsonIgnore]
    private GameObject parent;
    [JsonIgnore]
    private GameObject lightning1;
    [JsonIgnore]
    private GameObject lightning2;
    [JsonIgnore]
    private GameObject lightning3;

    [JsonIgnore]
    private float lightningInterval;
    [JsonIgnore]
    private float nextLightning;

    public override bool ExecuteEvent(ShipBehaviour ShipBehaviour, float time)
    {
        float relativeEventTime = time - StartingTime;
        if (relativeEventTime > Duration)
        {
            parent.SetActive(false);
            return true;
        }
        if (!parent.activeSelf)
        {
            parent.SetActive(true);
        }
        if (time > nextLightning)
        {
            DoLightning(lightning1, 0.005f, 0.9f);
            DoLightning(lightning2, 0.01f, 0.8f);
            DoLightning(lightning3, 0.015f, 0.99f);
            nextLightning += lightningInterval;
        }

        return false;
    }

    private void DoLightning(GameObject lightning, float activateChance, float deactivateChance)
    {
        if (lightning.activeSelf)
        {
            if (getRandom(deactivateChance))
            {
                lightning.SetActive(false);
            }
        }
        else
        {
            if (getRandom(activateChance))
            {
                lightning.SetActive(true);
            }
        }
    }

    public override void init(GameObject parent)
    {
        this.parent = parent;
        lightning1 = parent.transform.Find("TS_Blitz_1").gameObject;
        lightning2 = parent.transform.Find("TS_Blitz_2").gameObject;
        lightning3 = parent.transform.Find("TS_Blitz_3").gameObject;
        nextLightning = StartingTime;
    }

    private bool getRandom(float chance)
    {
        float rand = Random.Range(0, 1f);
        return rand < chance;
    }
}
