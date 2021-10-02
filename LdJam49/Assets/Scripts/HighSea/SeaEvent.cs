public abstract class SeaEvent
{
    public string EventName { get; set; }

    public float Duration { get; set; }

    public float StartingTime { get; set; }

    public abstract bool ExecuteEvent(ShipBehaviour ShipBehaviour, float time);


}
