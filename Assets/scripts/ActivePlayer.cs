using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ActivePlayer : Player
{
    const int MAX_HAND_CARD_COUNT = 3;
    const int BASE_HEALTH = 50;
    GameObject player_username_display;
    GameObject player_health_display;
    GameObject player_area;

    void Awake()
    {
        Health = BASE_HEALTH;
        Hand = new Hand(MAX_HAND_CARD_COUNT);

    }

    void Start()
    {

        player_id = this.transform.name[1] - 47; // converting ascii digit to real id (0 -> 48, 1 -> 49, etc.) 
                                                 // also adjusting 1 extra to account for ui naming (p1_name instead of p0_name)
        string display_ui_name = "p" + player_id + "_name";
        string display_ui_health = "p" + player_id + "_health";
        string ui_player_area = "p" + player_id + "_area";

        // Set color of username ui
        player_username_display = GameObject.Find(display_ui_name);
        player_username_display.GetComponent<Text>().color = this.GetComponent<Image>().color;// pull color from Pilot <Image>
        Color c = this.GetComponent<Image>().color;

        // Make Pilot Image transparent, only needed the color
        c.a = 0;
        this.GetComponent<Image>().color = c;

        player_health_display = GameObject.Find(display_ui_health);
        player_area = GameObject.Find(ui_player_area);

        Username = this.transform.name;
        Username = Username.Remove(0, 4); //remove [#] in front of object name
        player_username_display.GetComponent<Text>().text = Username;//update username ui
        player_health_display.GetComponent<Text>().text = "Health: " + Health; //update health ui
        this.transform.SetParent(player_area.transform);// set Pilot object to proper area
        this.transform.localPosition = Vector3.zero;// center object in p<#>_area

    }

    public override void Die()
    {
        //let player die normally
        base.Die();

        //check if every player is dead. if yes, end game. if not, do nothing.
        bool everyoneIsDead = true;
        foreach (Player p in GameInfo.singleton.Players)
        {
            if (!p.isDead)
                everyoneIsDead = false;
        }

        if (everyoneIsDead)
            SceneManager.LoadScene("loseScreen");
    }
};