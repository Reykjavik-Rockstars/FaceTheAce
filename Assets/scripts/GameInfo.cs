using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public static GameInfo singleton;

    const int MAX_PLAYERS = 5;
    int playerCount = 1;

    bool initialized = false;

    public BossPlayer Boss;
    public ActivePlayer self;

    public List<Player> Players;
    public List<ActivePlayer> PrejoinList;
    public List<CardDisplay> Deck;
    public List<CardDisplay> unresolvedCards;
    public List<Effect> ActiveEffects;

    public TargetingZone selfTargetZone;
    public TargetingZone aceTargetZone;
    public List<TargetingZone> playerTargetZones;

    GameObject placeholder_self;


    void Awake()
    {
        singleton = this;
        Players = new List<Player>();
        ActiveEffects = new List<Effect>();
        unresolvedCards = new List<CardDisplay>();
        playerTargetZones = new List<TargetingZone>();

        GameObject AceObject = new GameObject();
        DontDestroyOnLoad(AceObject);
        AceObject.name = "AceObject";
        AceObject.AddComponent<BossPlayer>();
        Boss = AceObject.GetComponent<BossPlayer>();
        Boss.Username = "Ace";
    }

    public void MainSceneStart()
    {
        ListSelf(self);
        initialized = true;
        foreach (ActivePlayer player in PrejoinList)
        {
            ListPlayer(player);
        }
        aceTargetZone.target = Boss;
        selfTargetZone.target = Players[0];
        GameController.singleton.selfNameText.text = self.Username;

        for (int i = 2; i <= 5; ++i)
        {
            var go = GameObject.FindWithTag("p" + i + "_area");
            playerTargetZones.Add(go ? go.GetComponent<TargetingZone>() : null);
            for (int j = 1; j <= 4; ++j)
            {
                if (Players.Count > j)
                {
                    playerTargetZones[j - 1].target = Players[j];
                }
            }
        }
    }

    public void ListSelf(ActivePlayer selfPlayer)
    {

        Players.Add(selfPlayer);
        self = selfPlayer;
    }

    public bool ListPlayer(ActivePlayer otherPlayer)
    {
        if (playerCount == MAX_PLAYERS)
            return false;
        else
        {
            Players.Add(otherPlayer);
            return true;
        }
    }

    public void preListPlayer(ActivePlayer otherPlayer)
    {
        if (initialized)
        {
            ListPlayer(otherPlayer);
        }
        else
        {
            PrejoinList.Add(otherPlayer);
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