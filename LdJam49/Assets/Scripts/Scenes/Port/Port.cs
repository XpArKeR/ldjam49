using System;
using System.Collections.Generic;
using System.IO;

using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

public class Port : MonoBehaviour
{
    public IList<ContainerBehaviour> AvailableContainers = new List<ContainerBehaviour>();
    public ContainerSlotBehavior ContainerSlot1;
    public ContainerSlotBehavior ContainerSlot2;
    public ContainerSlotBehavior ContainerSlot3;
    public Text ContainerDescription;

    // Start is called before the first frame update
    void Start()
    {
        Core.AmbienceAudioManager.Play(Core.ResourceCache.GetAudioClip(Path.Combine("Audio", "Scenes", "Port", "Background_Slow")), true);
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

    public void OnSlotMouseEnter(ContainerSlotBehavior hoveredElement)
    {
        if (hoveredElement.Container != default)
        {
            this.ContainerDescription.text = String.Format("Container Weight: {0:##.0.00}t", hoveredElement.Container.Weight);
        }
    }

    public void OnSlotMouseExit(ContainerSlotBehavior hoveredElement)
    {
        this.ContainerDescription.text = default;
    }

    private void SpawnContainer(ContainerSlotBehavior containerSlotBehavior)
    {
        var container = new BasicContainer()
        {
            Weight = UnityEngine.Random.Range(0, 125f)
        };

        containerSlotBehavior.Container = container;
    }
}
