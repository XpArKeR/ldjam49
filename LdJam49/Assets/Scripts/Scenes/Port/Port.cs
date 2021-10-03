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
        Core.ChangeScene(SceneNames.HighSea);
    }

    // Start is called before the first frame update
    void Start()
    {
        Core.AmbienceAudioManager?.Play(Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Scenes", "Port", "Background_Slow")), true);

        var ship = Core.GameState?.Ship;

        if (ship == default)
        {
            ship = new BasicShip()
            {

            };
        }

        if (ship != default)
        {
            var containerAmount = 3;

            for (int i = 0; i < containerAmount; i++)
            {
                var newSlot = GameObject.Instantiate<ShipContainerSlotBehavior>(this.ShipContainerTemplate);

                newSlot.ContainerClicked.AddListener(this.ShipContainerSelceted);
                
                newSlot.transform.SetParent(ShipContainer.gameObject.transform);

                newSlot.gameObject.SetActive(true);

                newSlot.transform.Translate(new Vector2(this.ShipContainer.transform.position.x + i, 0));

                this.ShipContainer.Slots.Add(newSlot);
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
        }
    }
}
