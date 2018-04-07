using UnityEngine;

public class Player : MonoBehaviour
{
    public string Username;
    public int Health;
    public Hand Hand;

    public Del_Int OnDamaged;
    public void ReceiveDamage(int damage, Player source)
    {
        if (OnDamaged != null) OnDamaged(damage);
    }

    public Del_Int OnHealed;
    public void ReceiveHeal(int heal, Player source)
    {
        if (OnHealed != null) OnHealed(heal);
    }

    public Del_Void OnDeath;
    void Die()
    {
        if (OnDeath != null) OnDeath();
    }

    public Del_ListCard OnCardDraw;
    public Del_Card OnSelect;
    public Del_Player_Card OnTarget;
    public Del_Player_Card OnTargeted;
};