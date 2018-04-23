using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalStrike : Effect {
    protected override void Awake()
    {
        base.Awake();
        _name = "CriticalStrike";
        _description = "Critical Strike! Opponenet receives damage between 10 - 30 damage points!";
        _rarity = (int)Rarity.rare;
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].ReceiveDamage((int)Random.Range(10.0f,30.0f), _owner);
        Inactivate();
    }
}
