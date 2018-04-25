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

    public TargetingZone selfTargetZone;
    public TargetingZone aceTargetZone;

    public List<TargetingZone> playerTargetZones;


    void Awake()
    {
        singleton = this;
        Players = new List<Player>();
        ActiveEffects = new List<Effect>();
        unresolvedCards = new List<CardDisplay>();
        playerTargetZones = new List<TargetingZone>();

        ListPlayer("Player 1");
        self = Players[0];

        GameObject AceObject = new GameObject();
        AceObject.name = "AceObject";
        AceObject.AddComponent<BossPlayer>();
        Boss = AceObject.GetComponent<BossPlayer>();
        Boss.Username = "Ace";
    }

    private void Start()
    {
        aceTargetZone.target = Boss;
        selfTargetZone.target = Players[0];
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

    public void ClearField()
    {
        foreach (Transform child in aceTargetZone.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in selfTargetZone.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (TargetingZone targetZone in playerTargetZones)
        {
            foreach (Transform child in targetZone.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void HideField()
    {
        CanvasGroup group;
        foreach (Transform child in aceTargetZone.transform)
        {
            group = child.gameObject.GetComponent<CanvasGroup>();
            group.alpha = 0f;
            group.blocksRaycasts = false;
        }
        foreach (Transform child in selfTargetZone.transform)
        {
            group = child.gameObject.GetComponent<CanvasGroup>();
            group.alpha = 0f;
            group.blocksRaycasts = false;
        }
        foreach (TargetingZone targetZone in playerTargetZones)
        {

            foreach (Transform child in targetZone.transform)
            {
                group = child.gameObject.GetComponent<CanvasGroup>();
                group.alpha = 0f;
                group.blocksRaycasts = false;
            }
        }
    }
};