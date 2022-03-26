using System.Collections.Generic;

using Assets.Scripts;
using Assets.Scripts.Base;
using Assets.Scripts.Constants;
using Assets.Scripts.Extensions;

using UnityEngine;
using UnityEngine.UI;

public class GameRun : MonoBehaviour
{
    private bool isStarted = false;

    public ShipBehaviour ShipBehaviour;
    public ShipCargoBehaviour ShipCargoBehavior;
    public Text LevelDisplay;
    public Text TimeDisplay;
    public Text GameOverDisplay;
    public Text LevelCompletedDisplay;
    public Image ArrivalImage;

    public GameObject ThunderStorm;
    public GameObject Ground;

    private Level Level;
    private List<SeaEvent> CurrentEvents;
    private int EventIndex;
    private SeaEvent nextEvent;

    private float timeCounter;

    private float levelCompletedTime;

    void Start()
    {
        if (!isStarted)
        {
            if (Core.Game.BackgroundAudioManager?.IsPlaying == true)
            {
                Core.Game.BackgroundAudioManager.Stop();
            }

            Core.Game.BackgroundAudioManager?.Play("HighSeaBackground", true);


            if (Level == default)
            {
#if UNITY_EDITOR
                if (Core.Game.State == default)
                {
                    var gameState = new GameState()
                    {
                        CurrentScene = SceneNames.HighSea,
                        Ship = ShipManager.GetDefaultShip()
                    };

                    Core.Game.Start(gameState);
                }
#endif

                Level = LevelManager.GetLevel(Core.Game.State.CurrentLevel);
                StartLevel();
            }

            this.ShipCargoBehavior.RenderCargo();

            if (EventIndex > Level.Events.Count)
            {
                //ERROR
            }
            nextEvent = Level.Events[EventIndex];

            InitEvents();

            this.isStarted = true;
        }
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        if (Level == null)
        {
            return;

        }

        if (levelCompletedTime == 0 && timeCounter > Level.Length)
        {
            this.ArrivalImage.gameObject.SetActive(true);
            StartCoroutine(this.ArrivalImage.Fade(false));

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

            ShipBehaviour.CheckShipStatus();
        }
        catch (ShipDownException)
        {
            GameOverDisplay.gameObject.SetActive(true);
            ShipBehaviour.SinkShip();
        }
    }

    private void LevelCompleted()
    {
        if (Level.IsLast)
        {
            Core.Game.ChangeScene(SceneNames.EndScene);
        }
        else
        {
            Core.Game.ChangeScene(SceneNames.Port);

            Core.Game.State.Ship.Unload();

            Core.Game.State.CurrentLevel = LevelManager.GetNextLevel(Level.Name).Name;
        }
    }

    private void InitEvents()
    {
        foreach (SeaEvent seaEvent in Level.Events)
        {
            if (typeof(ThunderStormEvent) == seaEvent.GetType())
            {
                seaEvent.init(ThunderStorm);
            }
            else if (typeof(DepthEvent) == seaEvent.GetType())
            {
                seaEvent.init(Ground);
            }
        }
    }

    private void StartLevel()
    {
        EventIndex = 0;
        levelCompletedTime = 0;
        CurrentEvents = new List<SeaEvent>();
        ShipBehaviour.WaterDepth = Level.WaterDepth;

        if (Level.Events == null)
        {
            Level.Events = new List<SeaEvent>();
        }

        //        LevelDisplay.text = Level.Name;
        LevelDisplay.text = Level.Start;
        TimeDisplay.text = Level.Destination;
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
}
