using System.Collections;
using System.Collections.Generic;
using System.IO;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;
using UnityEngine.UI;

public class Port : MonoBehaviour
{
    public IList<ContainerBehaviour> AvailableContainers = new List<ContainerBehaviour>();
    public LandContainerSlotBehaviour ContainerSlot1;
    public LandContainerSlotBehaviour ContainerSlot2;
    public LandContainerSlotBehaviour ContainerSlot3;
    public ContainerDetailsBehaviour ContainerDetails;

    public ShipCargoBehaviour ShipCargo;

    public ShipBehaviour ShipBehaviour;

    public Text GameOverDisplay;

    private LandContainerSlotBehaviour seletedLandContainer;

    private bool LoadHighSeasStarted = false;
    private float LoadSecondsLeft = 0;

    public void SelectContainer(LandContainerSlotBehaviour containerSlotBehavior)
    {
        if (this.seletedLandContainer != default)
        {
            this.seletedLandContainer.IsSelected = false;
        }

        this.seletedLandContainer = containerSlotBehavior;
        this.seletedLandContainer.IsSelected = true;

        this.UpdateContainerInfo();
    }

    public void SetSail()
    {
        if (Core.BackgroundAudioManager?.IsPlaying == true)
        {
            Core.BackgroundAudioManager?.Stop();
        }

        if (Core.EffectsAudioManager != default)
        {
            Core.EffectsAudioManager?.Play(Path.Combine("Audio", "Effects", "Ship", "ShipHornShortShort"));
            //            StartCoroutine(Core.EffectsAudioManager.WaitForSound(onEffectFinished));
            //StartCoroutine(DelayChangeScene(1f));
            Core.ChangeScene(SceneNames.HighSea2);
        }
        else
        {
            onEffectFinished();
        }
    }

/*    IEnumerator DelayChangeScene(float seconds)
    {
        LoadHighSeasStarted = true;
        LoadSecondsLeft = seconds;
        do
        {
            yield return new WaitForSeconds(1);
        } while (--LoadSecondsLeft > 0);

        Core.ChangeScene(SceneNames.HighSea2);
    }*/

    private void onEffectFinished()
    {
        Core.ChangeScene(SceneNames.HighSea2);
    }

    // Start is called before the first frame update
    void Start()
    {
        Core.BackgroundAudioManager?.Play(Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Scenes", "Port", "Background_Slow")), true);

#if UNITY_EDITOR

        if (Core.GameState == default)
        {
            var gameState = new GameState()
            {
                CurrentScene = SceneNames.Port,
                Ship = ShipManager.GetDefaultShip()
            };
            Core.StartGame(gameState);
        }
#endif

        this.ShipCargo.GenerateBaseSlots(this.ShipContainerSelceted);
    }

    // Update is called once per frame
    void Update()
    {
        if (ContainerSlot1.Container == null)
        {
            SpawnContainer(ContainerSlot1);
        }

        if (ContainerSlot2.Container == null)
        {
            SpawnContainer(ContainerSlot2);
        }

        if (ContainerSlot3.Container == null)
        {
            SpawnContainer(ContainerSlot3);
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.SelectContainer(this.ContainerSlot1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.SelectContainer(this.ContainerSlot2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.SelectContainer(this.ContainerSlot3);
        }

        try
        {
            ShipBehaviour.WaterDepth = 130f;
            ShipBehaviour.CheckShipStatus();
        }
        catch (ShipDownException e)
        {
            GameOverDisplay.gameObject.SetActive(true);
            GameOverDisplay.text = "Game Over: " + e.Message;
            ShipBehaviour.SinkShip();
        }

    }

    private void SpawnContainer(LandContainerSlotBehaviour containerSlotBehavior)
    {
        //        float weight = UnityEngine.Random.Range(0, 80f);
        float weight = 30;
        var container = new BasicContainer()
        {
            Weight = weight,
            Value = System.Convert.ToDecimal((weight / 80.0f + UnityEngine.Random.Range(-0.5f, 0.5f))*100000f),
            Color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f))
        };

        containerSlotBehavior.Container = container;
    }

    private void UpdateContainerInfo()
    {
        if (this.seletedLandContainer != default)
        {
            this.ContainerDetails.gameObject.SetActive(true);
            this.ContainerDetails.Container = this.seletedLandContainer.Container;
        }
        else
        {
            this.ContainerDetails.gameObject.SetActive(false);
        }
    }

    private void ShipContainerSelceted(ShipContainerSlotBehaviour container)
    {
        if (this.seletedLandContainer?.Container != default)
        {
            container.LoadedContainer = new LoadedContainer()
            {
                Container = this.seletedLandContainer.Container,
                Offset = container.Offset
            };


            this.seletedLandContainer.IsSelected =false;
            this.seletedLandContainer.Container = default;

            var slot = this.ShipCargo.GenerateShipSlot(new Vector2(container.Offset.x, container.Offset.y + 1), container.transform);

            container.ContainerClicked.RemoveListener(this.ShipContainerSelceted);
            slot.ContainerClicked.AddListener(this.ShipContainerSelceted);
            this.seletedLandContainer = default;
            this.UpdateContainerInfo();

            Core.GameState.Ship.AddContainer(container.LoadedContainer);
        }
    }
}
