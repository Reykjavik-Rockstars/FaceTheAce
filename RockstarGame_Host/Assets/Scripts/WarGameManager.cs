using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class CardChangeEvent : UnityEvent<GameObject, int> { }

public class WarGameManager : MonoBehaviour
{
   public static WarGameManager singleton;

    public CardChangeEvent changeP1CardMesh;
    public CardChangeEvent changeP2CardMesh;

	public Text scoreText;

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

   private GameObject p1Card;
   private GameObject p2Card;

   void Awake()
   {
      singleton = this;
      
      //set current state as idle
      currentState = State.Idle;

      //create the deck
      createDeck();

      //Instantiate the cards - tgh
      p1Card = (GameObject)Instantiate(Resources.Load("PlayingCard"), p1Position);
      p2Card = (GameObject)Instantiate(Resources.Load("PlayingCard"), p2Position);

      //Get their transforms - tgh
      p1Position = p1Card.transform;
      p2Position = p2Card.transform;

      //Set their positions to the appropriate place - tgh
      p1Position.position = new Vector3(-1, 3, 0);
      p2Position.position = new Vector3(1, 3, 0);
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
            deckIndex = Random.Range(0, 52);
            //Debug.Log(deckIndex);

            //get random cards and show
            p1CardIndex = deck[deckIndex];
            changeP1CardMesh.Invoke(p1Card, p1CardIndex);
            //increment deckIndex so next player gets next card in the deck
            deckIndex = Random.Range(0, 52);
            //Debug.Log(deckIndex);
            p2CardIndex = deck[deckIndex];
            changeP2CardMesh.Invoke(p2Card, p2CardIndex);

            //compare cards, award points
            if (p1CardIndex/4 > p2CardIndex/4)
                p1Score++;
            else if (p2CardIndex/4 > p1CardIndex/4)
                p2Score++;
            //animate interactions (*WORK WITH MICHAEL*)

            //set state as idle
			scoreText.text = "Player 1: " + p1Score + "      Player 2: " + p2Score;
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