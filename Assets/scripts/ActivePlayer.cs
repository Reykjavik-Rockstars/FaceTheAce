using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class ActivePlayer : Player
{
    public const int MAX_HAND_CARD_COUNT = 3;
    public const int BASE_HEALTH = 50;
    GameObject player_username_display;
    GameObject player_health_display;
    GameObject player_area;

    void Awake()
    {
        Hand = new Hand(MAX_HAND_CARD_COUNT);
        DontDestroyOnLoad(gameObject);
        MAX_HEALTH = 50;
        Health = BASE_HEALTH;
    }

    public override void OnStartLocalPlayer()
    {
        GameInfo.singleton.self = this;
        GameObject GameInitializer = new GameObject();
        GameInitializer.AddComponent<MainGameInitializer>();
    }

    void Start()
    {
        Username = this.transform.name;
        Username = Username.Remove(0, 4); //remove [#] in front of object name
        //player_username_display.GetComponent<Text>().text = Username;//update username ui
        //player_health_display.GetComponent<Text>().text = "Health: " + Health; //update health ui
        //this.transform.SetParent(player_area.transform);// set Pilot object to proper area
        //this.transform.localPosition = Vector3.zero;// center object in p<#>_area

        if (!isLocalPlayer)
        {
            GameInfo.singleton.preListPlayer(this);
        }
        player_id = this.transform.name[1] - 47; // converting ascii digit to real id (0 -> 48, 1 -> 49, etc.) 
                                                 // also adjusting 1 extra to account for ui naming (p1_name instead of p0_name)
        string display_ui_name = "p" + player_id + "_name";
        string display_ui_health = "p" + player_id + "_health";
        string ui_player_area = "p" + player_id + "_area";

        // Set color of username ui
        player_username_display = GameObject.Find(display_ui_name);
        ///player_username_display.GetComponent<Text>().color = this.GetComponent<Image>().color;// pull color from Pilot <Image>
        //Color c = this.GetComponent<Image>().color;

        // Make Pilot Image transparent, only needed the color
        //c.a = 0;
        //this.GetComponent<Image>().color = c;

        //player_health_display = GameObject.Find(display_ui_health);
        //player_area = GameObject.Find(ui_player_area);

    }

    public override void CmdDie()
    {
        //let player die normally
        base.CmdDie();

        //check if every player is dead. if yes, end game. if not, do nothing.
        bool everyoneIsDead = true;

        if (GameInfo.singleton)
        {
            foreach (Player p in GameInfo.singleton.Players)
            {
                if (!p.isDead)
                    everyoneIsDead = false;
            }
        }
        if (everyoneIsDead)
            SceneManager.LoadScene("loseScreen");
    }
};