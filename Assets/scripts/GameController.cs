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

        p2HealthText = GameObject.FindWithTag("p2_health_text").GetComponent<Text>();
        p3HealthText = GameObject.FindWithTag("p3_health_text").GetComponent<Text>();
        p4HealthText = GameObject.FindWithTag("p4_health_text").GetComponent<Text>();
        p5HealthText = GameObject.FindWithTag("p5_health_text").GetComponent<Text>();
        p2NameText = GameObject.FindWithTag("p2_name_text").GetComponent<Text>();
        p3NameText = GameObject.FindWithTag("p3_name_text").GetComponent<Text>();
        p4NameText = GameObject.FindWithTag("p4_name_text").GetComponent<Text>();
        p5NameText = GameObject.FindWithTag("p5_name_text").GetComponent<Text>();

        p2HealthText = GameObject.FindWithTag("p2_health_text").GetComponent<Text>();
        p3HealthText = GameObject.FindWithTag("p3_health_text").GetComponent<Text>();
        p4HealthText = GameObject.FindWithTag("p4_health_text").GetComponent<Text>();
        p5HealthText = GameObject.FindWithTag("p5_health_text").GetComponent<Text>();
        p2NameText = GameObject.FindWithTag("p2_name_text").GetComponent<Text>();
        p3NameText = GameObject.FindWithTag("p3_name_text").GetComponent<Text>();
        p4NameText = GameObject.FindWithTag("p4_name_text").GetComponent<Text>();
        p5NameText = GameObject.FindWithTag("p5_name_text").GetComponent<Text>();
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
        p1HealthText.text = "Health: " + gameInfo.Players[0].Health.ToString();
        switch (FSM.singleton.currentState)
        {
            case FSM.gameState.Draw:
                instructionsText.text = "Instructions:\n"
                    + "Draw 3 cards and\n"
                    + "click End Turn.";
                break;
            case FSM.gameState.Select:
                instructionsText.text = "Instructions:\n"
                    + "BLAH BLAH BLAH";
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