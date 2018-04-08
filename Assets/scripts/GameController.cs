using UnityEngine;

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
    }

    public bool AddPlayer(string nickname)
    {
        return m_game.ListPlayer(new ActivePlayer(nickname));
    }
}