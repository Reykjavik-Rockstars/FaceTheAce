using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public static GameInfo singleton;

    const int MAX_PLAYERS = 5;
    int playerCount = 0;

    public BossPlayer Boss;
    public Player self;
    public List<Player> Players;
    public List<CardDisplay> Deck;

    public List<CardDisplay> unresolvedCards;
    public List<Effect> ActiveEffects;

    public List<TargetingZone> playerTargetZones;
    public TargetingZone selfTargetZone;
    public TargetingZone aceTargetZone;

    void Awake()
    {
        singleton = this;
        Players = new List<Player>();
        ActiveEffects = new List<Effect>();
        unresolvedCards = new List<CardDisplay>();
        playerTargetZones = new List<TargetingZone>();

        GameObject PlayerObject = new GameObject();
        PlayerObject.name = "Player 1_Object";
        PlayerObject.AddComponent<ActivePlayer>();
        ActivePlayer player = PlayerObject.GetComponent<ActivePlayer>();
        player.Username = "Player 1";
        self = player;

        GameObject AceObject = new GameObject();
        AceObject.name = "AceObject";
        AceObject.AddComponent<BossPlayer>();
        Boss = AceObject.GetComponent<BossPlayer>();
        Boss.Username = "Ace";
    }

    private void Start()
    {
        aceTargetZone.target = Boss;
        selfTargetZone.target = self;
    }

    public bool ListPlayer(string username)
    {
        if (playerCount == MAX_PLAYERS)
            return false;
        else
        {
            GameObject PlayerObject = new GameObject();
            PlayerObject.name = username+"_Object";
            PlayerObject.AddComponent<ActivePlayer>();
            ActivePlayer player = PlayerObject.GetComponent<ActivePlayer>();
            player.Username = username;
            Players.Add(player);
            playerCount++;
            return true;
        }
    }
};