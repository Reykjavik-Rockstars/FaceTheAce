using UnityEngine;
//using UnityEditor.UI;

public class TargetingZone : DropZone {

    public Player target;
    public Draggable myCard;

    protected virtual void Awake()
    {
        //GameInfo.singleton.playerTargetZones.Add(this);
    }

    protected virtual void Start()
    {
        //GameInfo.singleton.playerTargetZones.Add(this);
    }
    protected override void EnteredEvent(Draggable d)
    {
        if (target != null)
        {
            Debug.Log("Entered target zone of " + target.Username + "...");
            CardDisplay card = d.gameObject.GetComponent<CardDisplay>();
            card.effect.SetTarget(target);
            FSM.singleton.nextTurnButton.interactable = true;
            Vector3 newPos = this.gameObject.transform.position;
            newPos.y += 20.0f;
            this.gameObject.transform.position = newPos; 
        }
    }

    protected override void DroppedEvent(Draggable d)
    {
        Debug.Log("DroppedEvent(), transform.childCount = " + this.transform.childCount.ToString());
        
        if (this.transform.GetComponent<CardDisplay>() == null && target != null)
        {
            Debug.Log("DroppedEvent(), Changing card's parent...");
            d.parentToReturnTo = this.transform;
            myCard = d;
            CardDisplay card = d.gameObject.GetComponent<CardDisplay>();
            GameInfo.singleton.self.Hand.RemoveCard(card);
            GameInfo.singleton.unresolvedCards.Add(card);
            Vector3 newPos = this.gameObject.transform.position;
            newPos.y -= 20.0f;
            this.gameObject.transform.position = newPos;
        }
        else
        {
            Debug.Log("DroppedEvent(), using old parent...");
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
            Vector3 newPos = this.gameObject.transform.position;
            newPos.y -= 20.0f;
            this.gameObject.transform.position = newPos;
            if (myCard != null)
            {
                GameInfo.singleton.unresolvedCards.Remove(myCard.gameObject.GetComponent<CardDisplay>());
                myCard = null;
            }
        }
    }
}
