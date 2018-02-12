using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.NetworkSystem;

[System.Serializable]
public class CommandLabel : UnityEvent<string> { }

public class HostController : MonoBehaviour {

    public static HostController singleton;

    public CommandLabel CommandIP;

	void Awake () {
        singleton = this;
	}

    void Start()
    {
        CommandIP.Invoke(Network.player.externalIP); //This doesn't really seem to do anything.
        //Utimately this will need to display the host's IP for use
    }

}
