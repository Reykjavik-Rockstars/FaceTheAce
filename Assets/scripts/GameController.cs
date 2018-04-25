using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController singleton;

    public int NumPlayers;

    private GameInfo gameInfo;

    private Text instructionsText;
    private Text gameStateText;
    private Text aceHealthText;
    public Text selfHealthText;
    public List<Text> playerHealthTexts;
    public Text selfNameText;
    public List<Text> playerNameTexts;

    bool inGame = false;

    // Use this for initialization
    void Awake()
    {
        singleton = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        gameInfo = GameInfo.singleton;
    }

    public void MainGameStart()
    {
        instructionsText = GameObject.FindWithTag("instructions_text").GetComponent<Text>();
        gameStateText = GameObject.FindWithTag("current_game_state_text").GetComponent<Text>();
        aceHealthText = GameObject.FindWithTag("ace_health_text").GetComponent<Text>();
        selfHealthText = GameObject.FindWithTag("p1_health_text").GetComponent<Text>();
        selfNameText = GameObject.FindWithTag("p1_name_text").GetComponent<Text>();

        for (int i = 2; i <= 5; ++i)
        {
            var go = GameObject.FindWithTag("p" + i + "_health_text");
            playerHealthTexts.Add(go ? go.GetComponent<Text>() : null);
            go = GameObject.FindWithTag("p" + i + "_name_text");
            playerNameTexts.Add(go ? go.GetComponent<Text>() : null);
        }

        inGame = true;
    }

    void Update()
    {
        if (inGame) {
            gameStateText.text = "Game State:\n" + FSM.singleton.currentState.ToString();
            aceHealthText.text = "Ace  Health: " + gameInfo.Boss.Health.ToString();
            if (gameInfo.Players.Count > 0)
            {
                selfHealthText.text = "Health: " + gameInfo.self.Health.ToString();
                selfNameText.text = gameInfo.self.Username;
            }
            for (int i = 1; i <= 4; ++i)
            {
                if (gameInfo.Players.Count > i)
                {
                    playerHealthTexts[i - 1].text = "Health: " + gameInfo.Players[i].Health.ToString();
                    playerNameTexts[i - 1].text = gameInfo.Players[i].Username;
                }
            }

            switch (FSM.singleton.currentState)
            {
                case FSM.gameState.Draw:
                    instructionsText.text = "Instructions:\n"
                        + "Click the lower-right deck until you have 3 cards. Then click End Turn.";
                    break;
                case FSM.gameState.Select:
                    instructionsText.text = "Instructions:\n"
                        + "Drag a card from your hand to the desired target. Then click End Turn.";
                    break;
                case FSM.gameState.Action:
                    instructionsText.text = "Instructions:\n"
                        + "Click End Turn.";
                    break;
                case FSM.gameState.Confirm:
                    break;
            }
        }
    }
}