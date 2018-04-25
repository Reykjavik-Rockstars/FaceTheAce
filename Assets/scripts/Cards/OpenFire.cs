﻿public class OpenFire : Effect
{
    protected override void Awake()
    {
        base.Awake();
        _name = "Open Fire";
        _description = "Deals 5 damage to target.";
        _rarity = (int)Rarity.common;
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].ReceiveDamage(5, _owner);
        Inactivate();
    }
}