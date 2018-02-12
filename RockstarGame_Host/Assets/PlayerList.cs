using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList : MonoBehaviour {
    public static PlayerList singleton;

    public CommandLabel CommandP1;
    public CommandLabel CommandP2;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        //This is a placeholder. Code will eventually be implemented by which the PlayerList can assign
        //player usernames to different text labels.
        CommandP1.Invoke("Placeholder P1");
        CommandP2.Invoke("Placeholder P2");
    }
}
