using System.Collections.Generic;

using Assets.Scripts;

using UnityEngine;

public class ShipCargoBehavior : MonoBehaviour
{
    public ShipContainerSlotBehavior ShipContainerTemplate;
    public ShipCargoBay ShipContainer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void GenerateBaseSlots(UnityEngine.Events.UnityAction<ShipContainerSlotBehavior> onShipContainerSlotClicked)
    {
        var slots = new List<ShipContainerSlotBehavior>();
        var containerAmount = Core.GameState.Ship.ContainerCapacity;

        for (int i = 0; i < containerAmount; i++)
        {
            var newSlot = CloneSlot(new Vector2(i, 0), this.ShipContainerTemplate.transform);

            newSlot.ContainerClicked.AddListener(onShipContainerSlotClicked);
            //newSlot.transform.Translate(new Vector2(i, 0), this.ShipContainerTemplate.transform);
        }
    }

    public ShipContainerSlotBehavior GenerateShipSlot(ShipContainerSlotBehavior parentContainer)
    {
        return CloneSlot(new Vector2(parentContainer.Offset.x, parentContainer.Offset.y + 1), parentContainer.transform);
    }

    private ShipContainerSlotBehavior CloneSlot(Vector2 shipOffset, Transform relativeTo)
    {
        var newSlot = GameObject.Instantiate<ShipContainerSlotBehavior>(this.ShipContainerTemplate, ShipContainer.gameObject.transform);

        newSlot.Offset = shipOffset;

        newSlot.transform.Translate(shipOffset, relativeTo);

        this.ShipContainer.Slots.Add(newSlot);

        newSlot.gameObject.SetActive(true);

        return newSlot;
    }
}
