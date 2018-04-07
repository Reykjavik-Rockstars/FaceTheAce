using UnityEngine;

public class GameController : MonoBehaviour
{
    public int NumPlayers;
    GameInfo m_game;

    // Use this for initialization
    void Awake()
    {
        m_game = new GameInfo();
    }

    public bool AddPlayer(string nickname)
    {
        return m_game.ListPlayer(new ActivePlayer(nickname));
    }
}