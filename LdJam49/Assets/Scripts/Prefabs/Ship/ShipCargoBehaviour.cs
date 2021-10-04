using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;

public class ShipCargoBehaviour : MonoBehaviour
{
    public ShipContainerSlotBehaviour ShipContainerTemplate;
    public ShipCargoBay ShipContainer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void RenderCargo()
    {
        if (Core.GameState.Ship.ShipLoad.Containers.Count > 0)
        {
            foreach (var container in Core.GameState.Ship.ShipLoad.Containers)
            {
                GenerateShipSlot(container);
            }
        }
    }

    public void GenerateBaseSlots(UnityEngine.Events.UnityAction<ShipContainerSlotBehaviour> onShipContainerSlotClicked)
    {
        var slots = new List<ShipContainerSlotBehaviour>();
        var containerAmount = Core.GameState.Ship.ContainerCapacity;

        for (int i = 0; i < containerAmount; i++)
        {
            var newSlot = CloneSlot(new Vector2(i, 0), this.ShipContainerTemplate.transform);

            if (onShipContainerSlotClicked != default)
            {
                newSlot.ContainerClicked.AddListener(onShipContainerSlotClicked);
            }
        }
    }

    public ShipContainerSlotBehaviour GenerateShipSlot(LoadedContainer loadedContainer)
    {
        return this.GenerateShipSlot(loadedContainer.Offset, this.ShipContainerTemplate.transform);
    }

    public ShipContainerSlotBehaviour GenerateShipSlot(Vector2 offset, Transform parentTransform)
    {
        return CloneSlot(offset, parentTransform);
    }

    private ShipContainerSlotBehaviour CloneSlot(Vector2 shipOffset, Transform relativeTo)
    {
        var newSlot = GameObject.Instantiate<ShipContainerSlotBehaviour>(this.ShipContainerTemplate, ShipContainer.gameObject.transform);

        newSlot.Offset = shipOffset;

        newSlot.transform.Translate(shipOffset, relativeTo);

        this.ShipContainer.Slots.Add(newSlot);

        newSlot.gameObject.SetActive(true);

        return newSlot;
    }
}
