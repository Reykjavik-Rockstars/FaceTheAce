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
    private Text p1HealthText;
    private Text p2HealthText;
    private Text p3HealthText;
    private Text p4HealthText;
    private Text p5HealthText;
    private Text p1NameText;
    private Text p2NameText;
    private Text p3NameText;
    private Text p4NameText;
    private Text p5NameText;

    // Use this for initialization
    void Awake()
    {
        singleton = this;
        instructionsText = GameObject.FindWithTag("instructions_text").GetComponent<Text>();
        gameStateText = GameObject.FindWithTag("current_game_state_text").GetComponent<Text>();
        aceHealthText = GameObject.FindWithTag("ace_health_text").GetComponent<Text>();
        p1HealthText = GameObject.FindWithTag("p1_health_text").GetComponent<Text>();
        p1NameText = GameObject.FindWithTag("p1_name_text").GetComponent<Text>();

        var go = GameObject.FindWithTag("p2_health_text");
        p2HealthText = go ? go.GetComponent<Text>() : null;
        go = GameObject.FindWithTag("p2_name_text");
        p2NameText = go ? go.GetComponent<Text>() : null;

        go = GameObject.FindWithTag("p3_health_text");
        p3HealthText = go ? go.GetComponent<Text>() : null;
        go = GameObject.FindWithTag("p3_name_text");
        p3NameText = go ? go.GetComponent<Text>() : null;

        go = GameObject.FindWithTag("p4_health_text");
        p4HealthText = go ? go.GetComponent<Text>() : null;
        go = GameObject.FindWithTag("p4_name_text");
        p4NameText = go ? go.GetComponent<Text>() : null;

        go = GameObject.FindWithTag("p5_health_text");
        p5HealthText = go ? go.GetComponent<Text>() : null;
        go = GameObject.FindWithTag("p5_name_text");
        p5NameText = go ? go.GetComponent<Text>() : null;

    }

    void Start()
    {
        gameInfo = GameInfo.singleton;
        p1NameText.text = gameInfo.Players[0].Username;
    }
    void Update()
    {
        gameStateText.text = "Game State:\n" + FSM.singleton.currentState.ToString();
        aceHealthText.text = "Ace  Health: " + gameInfo.Boss.Health.ToString();
        if (gameInfo.Players.Count > 0)
            p1HealthText.text = "Health: " + gameInfo.Players[0].Health.ToString();
        if (gameInfo.Players.Count > 1)
            p2HealthText.text = "Health: " + gameInfo.Players[1].Health.ToString();
        if (gameInfo.Players.Count > 2)
            p3HealthText.text = "Health: " + gameInfo.Players[2].Health.ToString();
        if (gameInfo.Players.Count > 3)
            p4HealthText.text = "Health: " + gameInfo.Players[3].Health.ToString();
        if (gameInfo.Players.Count > 4)
            p5HealthText.text = "Health: " + gameInfo.Players[4].Health.ToString();

        switch (FSM.singleton.currentState)
        {
            case FSM.gameState.Draw:
                instructionsText.text = "Instructions:\n"
                    + "Draw 3 cards and click End Turn.";
                break;
            case FSM.gameState.Select:
                instructionsText.text = "Instructions:\n"
                    + "Drag a card from your hand to the desired target. Then click End Turn";
                break;
            case FSM.gameState.Action:
                break;
            case FSM.gameState.Confirm:
                break;
        }
    }

    public bool AddPlayer(string nickname)
    {
        return GameInfo.singleton.ListPlayer(nickname);
    }
}