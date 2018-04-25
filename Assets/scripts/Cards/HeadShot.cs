using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : Effect {
    protected override void Awake()
    {
        base.Awake();
        _name = "HeadShot";
        _description = "BOOM HEADSHOT! Does 35 damage.";
        _rarity = (int)Rarity.legendary;
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].ReceiveDamage(35, _owner);
        Inactivate();
    }

}
