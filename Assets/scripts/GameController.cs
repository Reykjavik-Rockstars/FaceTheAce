using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController singleton;

    public int NumPlayers;
    GameInfo m_game;

    // Use this for initialization
    void Awake()
    {
        singleton = this;
        m_game = new GameInfo();
        
        // CHEAP WAY TO GET THINGS RUNNING FOR DEMO
        AddPlayer("Player 1");
        m_game.CurrentPlayer = m_game.Players[0];


        UpdateUI();
    }

    public bool AddPlayer(string nickname)
    {
        return m_game.ListPlayer(new ActivePlayer(nickname));
    }

    public void UpdateUI()
    {
        var curPlayer = m_game.CurrentPlayer;
        var curHand = m_game.CurrentPlayer.Hand;
        if (curPlayer.HasPlayedCard &&
            curHand.GetHeldCardsCount() == curHand.GetMaxCardsCount())
        {
            FSM.singleton.nextTurnButton.interactable = true;
        }
        else
        {
            FSM.singleton.nextTurnButton.interactable = false;
        }


        var aceHealth = GameObject.FindWithTag("Ace_Health").GetComponent<Text>();
        aceHealth.text = "Ace  Health: " + GameInfo.singleton.Boss.Health.ToString();

        Debug.Log("Boss Health: " + GameInfo.singleton.Boss.Health.ToString());
    }

    public void EndTurn()
    {
        Debug.Log("EndTurn occurred");
        var playArea = GameObject.FindWithTag("playArea_P1");
        var playAreaChild = playArea.transform.GetChild(0);
        var cardPlayed = playAreaChild.GetComponentInChildren<CardDisplay>();
        Debug.Log("Card played name: " + cardPlayed.nameText);
        var effect = cardPlayed.GetEffect();
        effect.SetTarget(GameInfo.singleton.Boss);
        cardPlayed.GetEffect().Activate();
        //GameInfo.singleton.unresolvedCards.Add(cardPlayed);
        foreach (Transform child in playArea.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        GameInfo.singleton.CurrentPlayer.Hand.RemoveCard(cardPlayed);
        UpdateUI();
    }

}