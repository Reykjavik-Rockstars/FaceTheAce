using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

	public new string name;
	public string description;

	public Sprite artwork;

	//public int manaCost;
	public int attack;
	public int health;
    // 0.0 rare - 1.0 common!
    public struct Rarity
    {
        public const double Common = 0.5;
        public const double UnCommon = 0.25;
        public const double Rare = 0.15;
        public const double Epic = 0.08;
        public const double Legendary = 0.02;
    };

    public bool isAttack;
    public bool isHeal;

    Effect effect;
}

public abstract class Effect
{
    //protected Player source;
    //protected Player target;

    public abstract void PlaceTriggers();
    public abstract void Setup();
    public abstract void RemoveTriggers();
    public abstract void Complete();
}
public class openFire : Effect
{
    public override void Complete()
    {
        throw new System.NotImplementedException();
    }

    public override void PlaceTriggers()
    {
       // FSM. += DoDamage();
       // FSM.EndOfTurn += RemoveTriggers();
    }

    public override void RemoveTriggers()
    {
        throw new System.NotImplementedException();
    }

    public override void Setup()
    {
        throw new System.NotImplementedException();
    }

    void DoDamage ()
    {
    //    target.ReceiveDamage(5,source);
    }
}

public class Sidewinder : Effect
{
    public override void Complete()
    {
        throw new System.NotImplementedException();
    }

    public override void PlaceTriggers()
    {
     //   FSM.EndOfTurn += RemoveTriggers();
    }

    public override void RemoveTriggers()
    {
        throw new System.NotImplementedException();
    }

    public override void Setup()
    {
        throw new System.NotImplementedException();
    }

    void DoDamage()
    {
    //    target.ReceiveDamage(5, source);
    }

}
/* Not yet implemented!!!
public class DodgeRoll : Effect
{
    public override void PlaceTriggers()
    {
        FSM.EndOfTurn += RemoveTriggers();
    }


}
*/

public class Suppression : Effect
{
    int countdown = 4;

    public override void PlaceTriggers()
    {
     //   FSM.EndOfTurn += CountDown();
    }
    void DoDamage()
    {

      //  target.ReceiveDamage(2,source);
    }

    void CountDown()
    {
        countdown--;
        if(countdown == 0)
        {
            RemoveTriggers();
        }
    }

    public override void Setup()
    {
        throw new System.NotImplementedException();
    }

    public override void RemoveTriggers()
    {
        throw new System.NotImplementedException();
    }

    public override void Complete()
    {
        throw new System.NotImplementedException();
    }
}