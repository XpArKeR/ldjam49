using System.Collections.Generic;
using System.IO;

using Assets.Scripts;
using Assets.Scripts.Constants;

using UnityEngine;

public class Port : MonoBehaviour
{
    public IList<ContainerBehaviour> AvailableContainers = new List<ContainerBehaviour>();
    public LandContainerSlotBehavior ContainerSlot1;
    public LandContainerSlotBehavior ContainerSlot2;
    public LandContainerSlotBehavior ContainerSlot3;
    public ContainerDetailsBehaviour ContainerDetails;

    public ShipContainerSlotBehavior ShipContainerTemplate;
    public ShipCargoBay ShipContainer;

    private LandContainerSlotBehavior seletedLandContainer;

    public void SelectContainer(LandContainerSlotBehavior containerSlotBehavior)
    {
        this.seletedLandContainer = containerSlotBehavior;

        this.UpdateContainerInfo();
    }

    public void SetSail()
    {
        Core.BackgroundAudioManager.Stop();
        Core.ChangeScene(SceneNames.HighSea);
    }

    // Start is called before the first frame update
    void Start()
    {
        Core.BackgroundAudioManager?.Play(Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Scenes", "Port", "Background_Slow")), true);

        var ship = Core.GameState?.Ship;

        if (ship == default)
        {
            ship = new BasicShip()
            {

            };
        }

        if (ship != default)
        {
            var containerAmount = 6;

            for (int i = 0; i < containerAmount; i++)
            {
                var newSlot = CloneSlot(new Vector2(i, 0), this.ShipContainerTemplate.transform);

                newSlot.ContainerClicked.AddListener(this.ShipContainerSelceted);
                //newSlot.transform.Translate(new Vector2(i, 0), this.ShipContainerTemplate.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ContainerSlot1.Container == default)
        {
            SpawnContainer(ContainerSlot1);
        }

        if (ContainerSlot2.Container == default)
        {
            SpawnContainer(ContainerSlot2);
        }

        if (ContainerSlot3.Container == default)
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
    }

    private void SpawnContainer(LandContainerSlotBehavior containerSlotBehavior)
    {
        var container = new BasicContainer()
        {
            Weight = UnityEngine.Random.Range(0, 125f),
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

    private void ShipContainerSelceted(ShipContainerSlotBehavior container)
    {
        if (this.seletedLandContainer?.Container != default)
        {
            container.LoadedContainer = new LoadedContainer()
            {
                Container = this.seletedLandContainer.Container,
                Offset = container.Offset
            };

            this.seletedLandContainer.Container = default;

            this.GenerateShipSlot(container);

            container.ContainerClicked.RemoveListener(this.ShipContainerSelceted);
            this.seletedLandContainer = default;
        }
    }

    private void GenerateShipSlot(ShipContainerSlotBehavior container)
    {
        var newSlot = CloneSlot(new Vector2(container.Offset.x, container.Offset.y + 1), container.transform);

        newSlot.ContainerClicked.AddListener(this.ShipContainerSelceted);
        //newSlot.transform.Translate(new Vector2(container.Offset.x, container.Offset.y + 1), container.transform);
    }

    private ShipContainerSlotBehavior CloneSlot(Vector2 offset, Transform relativeTo)
    {
        var newSlot = GameObject.Instantiate<ShipContainerSlotBehavior>(this.ShipContainerTemplate);

        newSlot.transform.SetParent(ShipContainer.gameObject.transform);

        newSlot.Offset = offset;

        newSlot.transform.Translate(offset, relativeTo);

        this.ShipContainer.Slots.Add(newSlot);

        newSlot.gameObject.SetActive(true);

        return newSlot;
    }
}
