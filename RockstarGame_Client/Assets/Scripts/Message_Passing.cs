using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Message_Passing : NetworkBehaviour
{
    //public GameObject PlayingPlayer; // Assuming PlayingPlayer knows their networking details (e.g. ip) access attributes this way
    GameObject sharedDisplay;
    public Button playButton;

    void Start()
    {
        sharedDisplay = GameObject.Find("msgBoard"); // instead of Debug.log will print to canvas in game scene
    }


    private void Update()
    {
        if (!isLocalPlayer) // players cannot interfere with other player functionality
            return;

        int[] cardDeck = new int[52]; //simulated deck

        if (Input.GetKeyDown(KeyCode.Space)) // simulates an action, say card played (prevents spamming on msgBoard)
        {
            System.Random rnd = new System.Random();// send random card to msgBoard
            int randomCard = rnd.Next(1, 52);
            CmdPlayCard(randomCard);
            Debug.Log("test!");
        }
    }


    [Command]
    void CmdPlayCard(int card)
    {
        sharedDisplay.GetComponent<Text>().text += "i played card #" + card.ToString() + "!\n";
    }
}