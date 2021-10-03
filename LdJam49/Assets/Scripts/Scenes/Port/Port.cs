using System.Collections.Generic;
using System.IO;

using Assets.Scripts;

using UnityEngine;

public class Port : MonoBehaviour
{
    public IList<ContainerBehaviour> AvailableContainers = new List<ContainerBehaviour>();
    public ContainerSlotBehavior ContainerSlot1;
    public ContainerSlotBehavior ContainerSlot2;
    public ContainerSlotBehavior ContainerSlot3;
    public ContainerDetailsBehaviour ContainerDetails;

    private ContainerSlotBehavior selectedContainer;

    public void SelectContainer(ContainerSlotBehavior containerSlotBehavior)
    {
        this.selectedContainer = containerSlotBehavior;

        this.UpdateContainerInfo();
    }

    // Start is called before the first frame update
    void Start()
    {
        Core.AmbienceAudioManager?.Play(Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Scenes", "Port", "Background_Slow")), true);
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

    private void SpawnContainer(ContainerSlotBehavior containerSlotBehavior)
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
        if (this.selectedContainer != default)
        {
            this.ContainerDetails.gameObject.SetActive(true);
            this.ContainerDetails.Container = this.selectedContainer.Container;
        }
        else
        {
            this.ContainerDetails.gameObject.SetActive(false);
        }
    }
}
