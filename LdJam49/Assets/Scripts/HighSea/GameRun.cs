using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameRun : MonoBehaviour
{

    public ShipBehaviour ShipBehaviour;
    public Text LevelDisplay;
    public Text GameOverDisplay;

    private Level Level;
    private List<SeaEvent> CurrentEvents;
    private int EventIndex;
    private SeaEvent nextEvent;



    void Start()
    {




        if (Level == default)
        {
            Level = GetDefaultLevel();
            StartLevel();
        }

        if (EventIndex > Level.Events.Count)
        {
            //ERROR
        }
        nextEvent = Level.Events[EventIndex];

    }

    private void StartLevel()
    {
        EventIndex = 0;
        CurrentEvents = new List<SeaEvent>();
        if (Level.Events == null)
        {
            Level.Events = new List<SeaEvent>();
        }
        LevelDisplay.text = Level.Name;
    }

    private Level GetDefaultLevel()
    {
        return JasonHandler.GetDefaultLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Level == null)
        {
            return;

        }
        CheckForNewEvents();
        ExecuteCurrentEvents();
        try
        {

            CheckShipStatus();
        }
        catch (ShipDownException )
        {
            GameOverDisplay.gameObject.SetActive(true);
            ShipBehaviour.SinkShip();
        }

    }

    private void CheckForNewEvents()
    {
        if (nextEvent != null && Time.time > nextEvent.StartingTime)
        {
            CurrentEvents.Add(nextEvent);
            EventIndex++;
            if (EventIndex < Level.Events.Count)
            {
                nextEvent = Level.Events[EventIndex];
            }
            else
            {
                nextEvent = null;
            }

        }
    }

    private void ExecuteCurrentEvents()
    {

        for (int i = CurrentEvents.Count - 1; i >= 0; i--)
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

        if (ShipBehaviour.Ship.Draft > Level.WaterDepth)
        {
            throw new ShipDownException("Scratch: " + ShipBehaviour.Ship.Draft + " : " + Level.WaterDepth);
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
