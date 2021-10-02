using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameRun : MonoBehaviour
{

    public ShipBehaviour Ship;

    private List<SeaEvent> Events;
    private List<SeaEvent> CurrentEvents;
    private int EventIndex;
    private SeaEvent nextEvent;


    void Start()
    {

        CurrentEvents = new List<SeaEvent>();

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
                Direction = 1,
                StartingTime = 10,
                Duration = 2
            }
        };
        return newEvents;
    }

    // Update is called once per frame
    void Update()
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

        ExecuteCurrentEvents();
    }

    private void ExecuteCurrentEvents()
    {

        for (int i = CurrentEvents.Count - 1; i >= 0 ; i--)
        {
            SeaEvent currentEvent = CurrentEvents[i];
            Debug.Log("Executing Event: " + currentEvent.EventName);
            if (currentEvent.ExecuteEvent(Ship, Time.time))
            {
                CurrentEvents.RemoveAt(i);
            }
        }
    }
}
