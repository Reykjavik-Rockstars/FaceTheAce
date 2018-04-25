using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Player : NetworkBehaviour
{

    bool flag = true;
    public int MAX_HEALTH;

    [SyncVar]
    public string Username;
    [SyncVar]
    public int Health;
    public Hand Hand;
    //on start, player is not dead. Only dead once hp falls to 0 or less
    public bool isDead = false;

    public int player_id = -1;

    void Start()
    {

    }

    private void Update()
    {
        showMessage();
    }

    void showMessage()
    {
        if (flag)
        {
            //infoDisplay.GetComponent<Text>().text += "nice";
            flag = false;
        }
    }

    public Del_Int OnDamaged;
    [Command]
    public virtual void CmdReceiveDamage(int damage)
    {
        if (OnDamaged != null) OnDamaged(damage);

        //only receive damage if player is alive
        if(!isDead)
        {
            //if damage is less than player health, deal normal damage
            if (Health > 0 && Health >= damage)
                Health = Health - damage;
            //if health is less than or equal to damage, health goes to 0 and player dies
            else if (Health <= damage)
            {
                Health = 0;
                CmdDie();
            }
            //make sure player health is 0 for other conditions. prevent negative health.
            else
                Health = 0;
        }
    }

    public Del_Int OnHealed;
    [Command]
    public virtual void CmdReceiveHeal(int heal)
    {
        if (OnHealed != null) OnHealed(heal);
        
        //only heal if player is alive
        if(!isDead)
        {
            //add health normally if health is normal
            if(Health >= 0)
            {
                Health = Health + heal;
            }
            //if health is below 0 for some reason, reset health to 0 and heal normally
            else
            {
                Health = 0;
                Health = Health + heal;
            }
        }
        if (Health > MAX_HEALTH)
        {
            Health = MAX_HEALTH;
        }
    }

    public Del_Void OnDeath;
    [Command]
    public virtual void CmdDie()
    {
        if (OnDeath != null) OnDeath();
        isDead = true;
    }

    public Del_ListCard OnCardDraw;
    public Del_Card OnSelect;
    public Del_Player_Card OnTarget;
    public Del_Player_Card OnTargeted;
};