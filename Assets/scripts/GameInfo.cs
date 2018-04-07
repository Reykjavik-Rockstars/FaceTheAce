using System.Collections.Generic;

public class GameInfo
{
    public static GameInfo singleton;

    const int MAX_PLAYERS = 5;
    int playerCount = 0;

    public BossPlayer Boss;
    public List<Player> Players;
    public List<Card> Deck;

    public List<Card> unresolvedCards;
    public List<Effect> ActiveEffects;

    public GameInfo()
    {
        singleton = this;
        Boss = new BossPlayer("Ace");
        Players = new List<Player>();
        ActiveEffects = new List<Effect>();
        unresolvedCards = new List<Card>();
    }

    public bool ListPlayer(Player p)
    {
        if (playerCount == MAX_PLAYERS) return false;
        else
        {
            Players.Add(p);
            return true;
        }
    }
};