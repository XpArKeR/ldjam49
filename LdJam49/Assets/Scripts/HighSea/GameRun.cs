using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRun : MonoBehaviour
{

    public ShipBehaviour ShipBehaviour;

    private List<SeaEvent> Events;
    private List<SeaEvent> CurrentEvents;
    private int EventIndex;
    private SeaEvent nextEvent;

    private float WaterDepth;


    void Start()
    {

        CurrentEvents = new List<SeaEvent>();
        WaterDepth = 100;

        if (Events == default)
        {
            Events = GetDefaultEvents();
        }
        EventIndex = 0;
        if (EventIndex > Events.Count)
        {
            //ERROR
        }
        nextEvent = Events[EventIndex];

    }

    private List<SeaEvent> GetDefaultEvents()
    {
        List<SeaEvent> newEvents = new List<SeaEvent>() {
            new WindEvent()
            {
                EventName = "Blast",
                Strength = 2000f,
                Direction = -1,
                StartingTime = 2,
                Duration = 20
            }
        };
        return newEvents;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForNewEvents();
        ExecuteCurrentEvents();
        try
        {

            CheckShipStatus();
        }
        catch (ShipDownException e)
        {
            Debug.LogException(e, this);
        }
    }

    private void CheckForNewEvents()
    {
        if (nextEvent != null && Time.time > nextEvent.StartingTime)
        {
            CurrentEvents.Add(nextEvent);
            EventIndex++;
            if (EventIndex < Events.Count)
            {
                nextEvent = Events[EventIndex];
            }
            else
            {
                nextEvent = null;
            }

        }
    }

    private void ExecuteCurrentEvents()
    {

        for (int i = CurrentEvents.Count - 1; i >= 0 ; i--)
        {
            SeaEvent currentEvent = CurrentEvents[i];
            Debug.Log("Executing Event: " + currentEvent.EventName);
            if (currentEvent.ExecuteEvent(ShipBehaviour, Time.time))
            {
                CurrentEvents.RemoveAt(i);
            }
        }
    }

    private void CheckShipStatus()
    {
        CheckIfAfloat();
    }

    private void CheckIfAfloat()
    {

        if (ShipBehaviour.Ship.Draft > WaterDepth)
        {
            throw new ShipDownException("Scratch: " + ShipBehaviour.Ship.Draft + " : " + WaterDepth);
        }

        CheckDraftAngle();
    }

    private void CheckDraftAngle()
    {
        //float hm = ShipBehaviour.Ship.Height * ShipBehaviour.Ship.EffectiveMassPoint.y;
        //float mDraft = ShipBehaviour.Ship.MaxDraft - hm;
        //float alpha = Mathf.Atan2(mDraft, ShipBehaviour.Ship.Width / 2);
        //float squaaaar = Mathf.Sqrt(Mathf.Pow(ShipBehaviour.Ship.Width / 2, 2) + Mathf.Pow(mDraft, 2));
        //float row = squaaaar * Mathf.Sin(alpha - (Mathf.PI / 180) * ShipBehaviour.ShipAngle);

        //if (row <= ShipBehaviour.Ship.Draft - hm)
        //{
        //    throw new ShipDownException("Tilted: " + row + " : " + (ShipBehaviour.Ship.Draft - hm));
        //}

        if (ShipBehaviour.ShipAngle < ShipBehaviour.MinAngle || ShipBehaviour.ShipAngle > ShipBehaviour.MaxAngle)
        {
            throw new ShipDownException("Tilted!! with angle  " + ShipBehaviour.MaxAngle);
        }
    }
}
