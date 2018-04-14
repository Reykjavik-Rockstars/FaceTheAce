public class TargetingZone : DropZone {

    public Player target;
    public Draggable myCard;

    protected virtual void Awake()
    {
        GameInfo.singleton.playerTargetZones.Add(this);
    }

    protected override void EnteredEvent(Draggable d)
    {
        if (target != null)
        {
            CardDisplay card = d.gameObject.GetComponent<CardDisplay>();
            card.effect.SetTarget(target);
            FSM.singleton.nextTurnButton.interactable = true;
        }
    }

    protected override void DroppedEvent(Draggable d)
    {
        if (this.transform.childCount < 2 && target != null)
        {
            d.parentToReturnTo = this.transform;
            myCard = d;
            CardDisplay card = d.gameObject.GetComponent<CardDisplay>();
            GameInfo.singleton.unresolvedCards.Add(card);
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
            FSM.singleton.nextTurnButton.interactable = false;
            if (myCard != null)
            {
                GameInfo.singleton.unresolvedCards.Remove(myCard.gameObject.GetComponent<CardDisplay>());
                myCard = null;
            }
        }
    }
}
