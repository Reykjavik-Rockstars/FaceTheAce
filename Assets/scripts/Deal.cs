using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Deal : MonoBehaviour, IPointerClickHandler
{
    GameObject[] cards;
    //string[] cards = { "Rocket Power", "Wahta Essence" };
    public void Start()
    {
        cards = Resources.LoadAll<GameObject>("Cards");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Deal.OnPointerClick, THIS IS WORKING");
        System.Random r = new System.Random();
        int rInt = r.Next(0, cards.Length);

        var player = GameInfo.singleton.CurrentPlayer;
        var hand = player.Hand;
        var frontEndHand = GameObject.FindWithTag("Hand");

        if (hand.GetHeldCardsCount() < hand.GetMaxCardsCount()) // &&
            //FSM.singleton.currentState == FSM.gameState.Draw)
        {
            // create new card gameobject
            GameObject newCard = Instantiate(cards[rInt]) as GameObject;
            newCard.transform.SetParent(frontEndHand.transform);
            
            // hook up to backend
            CardDisplay card = newCard.GetComponent<CardDisplay>();
            hand.AddCard(card);     
        }
        
    }

}
