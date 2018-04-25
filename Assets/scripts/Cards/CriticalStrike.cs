using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalStrike : Effect {
    protected override void Awake()
    {
        base.Awake();
        _name = "Critical Strike";
        _description = "Critical Strike! Opponenet receives damage between 10 - 35 damage points!";
        _rarity = (int)Rarity.epic;
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].CmdReceiveDamage((int)Random.Range(10.0f,35.0f));
        Inactivate();
    }
}
