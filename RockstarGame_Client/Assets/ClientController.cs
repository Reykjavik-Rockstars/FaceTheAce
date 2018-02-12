using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//The CommandLabel event is used to send strings to change label text.
//Label to be changed can be selected using the Unity event management system
//in the editor. A class must hold a public CommandLabel field to make use of
//this class.
[System.Serializable]
public class CommandLabel : UnityEvent<string> { };

public class ClientController : MonoBehaviour {

    public static ClientController singleton;

    public CommandLabel CommandIPLabel;
    public CommandLabel CommandUsernameLabel;

    void Awake()
    {
        singleton = this;
    }

    //Pressing this button triggers the system to check if the current IP address
    //and username are valid.
    //TODO: Link this with the network system to validate that the IP address
    //indicates an actual game host.
    public void submitButtonPressed()
    {
        bool ipValid = false;
        if (ipValid = IPSystem.singleton.IsValid())
        {
            CommandIPLabel.Invoke("IP Address Accepted");
        }
        else
        {
            CommandIPLabel.Invoke("IP Address Rejected!");
        }

        bool unValid = false;
        if (unValid = ClientInfo.singleton.IsValid())
        {
            CommandUsernameLabel.Invoke("Username Accepted");
        }
        else
        {
            CommandUsernameLabel.Invoke("Username Rejected!");
        }

        if (ipValid && unValid)
        {
            SceneManager.LoadScene("HandScreen");
            //This will eventually need to validate if the IP address indicates an actual
            //host and not just some random IP.
        }
    }
}