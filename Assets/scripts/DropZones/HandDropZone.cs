using System.Collections.Generic;
using UnityEngine;

public class HandDropZone : DropZone
{

    public static HandDropZone singleton;
    public Hand hand;

    protected void Awake()
    {
        singleton = this;
    }
    void Update()
    {
        if (hand == null)
            hand = GameInfo.singleton.self.Hand;
    }

    protected override void DroppedEvent(Draggable d)
    {
        if (this.transform.childCount <= hand.GetMaxHandCardsCount())
        {
            d.parentToReturnTo = this.transform;
        }
        else
        {
            RemovedEvent(d);
        }
    }

    protected override void EnteredEvent(Draggable d)
    {
        AddCard(d.GetComponent<CardDisplay>());
        SetCardsBlockRaycast(true);
    }

    protected override void RemovedEvent(Draggable d)
    {
        RemoveCard(d.GetComponent<CardDisplay>());
        SetCardsBlockRaycast(false);
    }

    public void AddCard(CardDisplay d)
    {
        hand.AddCard(d);
    }

    public void RemoveCard(CardDisplay d)
    {
        hand.RemoveCard(d);
    }

    public void SetCardsBlockRaycast(bool block)
    {
        foreach (CardDisplay card in hand.GetCards())
        {
            card.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = block;
        }
    }
}