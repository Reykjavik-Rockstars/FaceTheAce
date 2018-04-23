using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Player : NetworkBehaviour
{

    bool flag = true;

    public string Username;
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
    public virtual void ReceiveDamage(int damage, Player source)
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
                Die();
            }
            //make sure player health is 0 for other conditions. prevent negative health.
            else
                Health = 0;
        }
    }

    public Del_Int OnHealed;
    public virtual void ReceiveHeal(int heal, Player source)
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
    }

    public Del_Void OnDeath;
    public virtual void Die()
    {
        if (OnDeath != null) OnDeath();
        isDead = true;
    }

    public Del_ListCard OnCardDraw;
    public Del_Card OnSelect;
    public Del_Player_Card OnTarget;
    public Del_Player_Card OnTargeted;
};