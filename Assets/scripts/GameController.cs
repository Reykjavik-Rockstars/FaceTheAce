using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController singleton;

    public int NumPlayers;

    // Use this for initialization
    void Awake()
    {
        singleton = this;
    }

    public bool AddPlayer(string nickname)
    {
        return GameInfo.singleton.ListPlayer(nickname);
    }
}