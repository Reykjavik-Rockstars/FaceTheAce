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
        System.Random r = new System.Random();
        int rInt = r.Next(0, cards.Length);

        if (GameObject.FindWithTag("Hand").transform.childCount < 5 && FSM.singleton.currentState == FSM.gameState.Draw)
        {
            GameObject newCard = Instantiate(cards[rInt]) as GameObject;
            newCard.transform.SetParent(GameObject.FindWithTag("Hand").transform);
            if (GameObject.FindWithTag("Hand").transform.childCount == 5) FSM.singleton.nextTurnButton.interactable = true;
        }
    }

}
