﻿public class Sidewinder : Effect
{
    protected override void Awake()
    {
        base.Awake();
        _name = "Sidewinder";
        _description = "Deals 5 damage to target. (uncommon, cannot be negated).";
        _rarity = (int)Rarity.uncommon;
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].CmdReceiveDamage(5);
        Inactivate();
    }
}