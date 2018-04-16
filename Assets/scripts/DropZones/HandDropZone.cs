using System.Collections.Generic;
using UnityEngine;

public class HandDropZone : DropZone {

    public static HandDropZone singleton;
    public List<CardDisplay> cards;
    Hand hand;

    protected void Awake()
    {
        singleton = this;
        cards = new List<CardDisplay>();
    }

    protected override void DroppedEvent(Draggable d)
    {
        if (this.transform.childCount < 6)
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
        if (!cards.Contains(d))
            cards.Add(d);
        Debug.Log("card added");
    }

    public void RemoveCard(CardDisplay d)
    {
        if (cards.Contains(d))
            cards.Remove(d);
        Debug.Log("card removed");
    }

    public void SetCardsBlockRaycast(bool block)
    {
        foreach (CardDisplay card in cards)
        {
            card.gameObject.GetComponent<CanvasGroup>().blocksRaycasts = block;
        }
    }
}