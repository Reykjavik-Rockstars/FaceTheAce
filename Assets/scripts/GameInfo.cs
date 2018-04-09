using UnityEngine;
using System.Collections.Generic;

public class GameInfo
{
    public static GameInfo singleton;

    const int MAX_PLAYERS = 5;
    int playerCount = 0;

    public BossPlayer Boss;
    public List<Player> Players;
    //public List<CardDisplay> Deck;
    public List<CardDisplay> unresolvedCards;
    public List<Effect> ActiveEffects;
    
    public Player CurrentPlayer;

    public GameInfo()
    {
        Debug.Log("GameInfo being created...");
        singleton = this;
        Boss = new BossPlayer("Ace");
        Players = new List<Player>();
        ActiveEffects = new List<Effect>();
        unresolvedCards = new List<CardDisplay>();
    }

    public bool ListPlayer(Player p)
    {
        if (playerCount == MAX_PLAYERS)
        {
            Debug.Log("New player not added!");
            return false;
        }
        else
        {
            Debug.Log("New player added!");
            Players.Add(p);
            return true;
        }
    }
};