using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class CardChangeEvent : UnityEvent<GameObject, int> { }

public class WarGameManager : MonoBehaviour
{

    public CardChangeEvent changeP1CardMesh;
    public CardChangeEvent changeP2CardMesh;

    //player scores will display on the inspector -kk
    public int p1Score = 0;
    public int p2Score = 0;

    //set transform of where cards will show in inspector -kk
    public Transform p1Position;
    public Transform p2Position;

    //we will add different states here depending on what we need in the future.
    //for now it is very basic with two states to handle the war game. -kk
    public enum State
    {
        Idle,   //when game is ready for inputs (swipe or button press) -kk
        Busy    //when game is in transition (swipes or button presses are ignored until animations finish) -kk
    }

    //state of the game
    [HideInInspector]
    public State currentState;

    //boolean to switch for player action (if swipe, boolean switches to true until action performed)
    [HideInInspector]
    public bool actionDone = false; //when you swipe, DO STUFF (*FOR DANNY*)

    private int[] deck = new int[52];   //int array to hold card indexs
    private int deckIndex = 0;          //index to hold location in deck

    private int p1CardIndex;            //holds index of player's current card
    private int p2CardIndex;

    //when scene starts.. -kk
    void Start()
    {
        //set current state as idle
        currentState = State.Idle;

        //create the deck
        createDeck();
    }

    void Update()
    {
        //if player does an action (swipe or press still needs coding) change state
        if (actionDone && currentState == State.Idle)
        {
            StateChange(State.Busy);
        }

        //if player does action when animations are going, invalidate action
        if (actionDone && currentState == State.Busy)
        {
            actionDone = false;
        }
    }

    void StateChange(State nextState)
    {
        if(nextState == State.Busy)
        {
            //get random cards and show
            p1CardIndex = deck[deckIndex];
            //instantiate card prefab using deckIndex value
            GameObject p1Card = (GameObject)Instantiate(Resources.Load(deckIndex.ToString()), p1Position);
            changeP1CardMesh.Invoke(p1Card, p1CardIndex);
            //increment deckIndex so next player gets next card in the deck
            deckIndex++;
            p2CardIndex = deck[deckIndex];
            GameObject p2Card = (GameObject)Instantiate(Resources.Load(deckIndex.ToString()), p2Position);
            changeP2CardMesh.Invoke(p2Card, p2CardIndex);

            deckIndex++;
            //compare cards, award points
            if (p1CardIndex > p2CardIndex)
                p1Score++;
            if (p2CardIndex > p1CardIndex)
                p2Score++;
            //animate interactions (*WORK WITH MICHAEL*)

            //set state as idle
            currentState = State.Idle;
        }
    }

    void createDeck()
    {
        //populate deck array with ints 1-52
        for (int i = 0; i < 52; i++)
        {
            deck[i] = i + 1;
        }

        //shuffle ints in array
        for (int k = deck.Length - 1; k > 0; k--)
        {
            var r = Random.Range(0, k);
            var tmp = deck[k];
            deck[k] = deck[r];
            deck[r] = tmp;
        }
    }
}