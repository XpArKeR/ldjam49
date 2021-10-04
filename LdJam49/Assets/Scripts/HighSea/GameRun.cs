using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.UI;

public class GameRun : MonoBehaviour
{

    public ShipBehaviour ShipBehaviour;
    public Text LevelDisplay;
    public Text TimeDisplay;
    public Text GameOverDisplay;
    public Text LevelCompletedDisplay;

    public GameObject ThunderStorm;

    private Level Level;
    private List<SeaEvent> CurrentEvents;
    private int EventIndex;
    private SeaEvent nextEvent;

    private float timeCounter;

    private float levelCompletedTime;

    void Start()
    {
        if (Core.BackgroundAudioManager?.IsPlaying == true)
        {
            Core.BackgroundAudioManager.Stop();
        }

        Core.BackgroundAudioManager?.Play(System.IO.Path.Combine("Audio", "Scenes", "HighSea", "HighSeaBackground"), true);


        if (Level == default)
        {
#if UNITY_EDITOR
            if (Core.GameState == default)
            {
                var gameState = new GameState()
                {
                    CurrentScene = SceneNames.HighSea,
                    Ship = ShipManager.GetDefaultShip()
                };
                gameState.Ship.SetDefaultValues();
                Core.StartGame(gameState);
            }
#endif

            Level = LevelManager.GetLevel(Core.GameState.CurrentLevel);
            StartLevel();
        }

        if (EventIndex > Level.Events.Count)
        {
            //ERROR
        }
        nextEvent = Level.Events[EventIndex];

        InitEvents();
    }



    void Update()
    {
        timeCounter += Time.deltaTime;
        TimeDisplay.text = timeCounter.ToString("#0.0");
        if (Level == null)
        {
            return;

        }
        if (levelCompletedTime == 0 && timeCounter > Level.Length)
        {
            levelCompletedTime = timeCounter + 3f;
            LevelCompletedDisplay.gameObject.SetActive(true);
        }

        if (levelCompletedTime != 0 && levelCompletedTime < timeCounter)
        {
            LevelCompleted();
            return;
        }

        CheckForNewEvents();
        ExecuteCurrentEvents();
        try
        {

            CheckShipStatus();
        }
        catch (ShipDownException)
        {
            GameOverDisplay.gameObject.SetActive(true);
            ShipBehaviour.SinkShip();
        }

    }

    private void LevelCompleted()
    {
        Core.ChangeScene(SceneNames.Port);
        Core.GameState.CurrentLevel = LevelManager.GetNextLevel(Level.Name).Name;
    }

    private void InitEvents()
    {
        foreach (SeaEvent seaEvent in Level.Events)
        {
            if (typeof(ThunderStormEvent) == seaEvent.GetType())
            {
                seaEvent.init(ThunderStorm);
            }
        }
    }

    private void StartLevel()
    {
        EventIndex = 0;
        levelCompletedTime = 0;
        CurrentEvents = new List<SeaEvent>();
        if (Level.Events == null)
        {
            Level.Events = new List<SeaEvent>();
        }
        LevelDisplay.text = Level.Name;
    }

    private void CheckForNewEvents()
    {
        if (nextEvent != null && timeCounter > nextEvent.StartingTime)
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
//            Debug.Log("Executing Event: " + currentEvent.EventName);
            if (currentEvent.ExecuteEvent(ShipBehaviour, timeCounter))
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
