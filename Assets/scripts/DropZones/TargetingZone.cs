public class TargetingZone : DropZone {

    public Player target;

    protected virtual void Start()
    {
        GameInfo.singleton.playerTargetZones.Add(this);
    }

    protected override void EnteredEvent(Draggable d)
    {
        if (target != null)
        {
            CardDisplay card = d.gameObject.GetComponent<CardDisplay>();
            card.effect.SetTarget(target);
        }
    }

    protected override void DroppedEvent(Draggable d)
    {
        if (this.transform.childCount < 2 && target != null)
        {
            d.parentToReturnTo = this.transform;
        }
        else
        {
            RemovedEvent(d);
        }
    }

    protected override void RemovedEvent(Draggable d)
    {
        if (target != null)
        {
            CardDisplay card = d.gameObject.GetComponent<CardDisplay>();
            card.effect.RemoveTarget(target);
        }
    }
}
