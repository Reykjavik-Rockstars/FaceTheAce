using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waduhek : Effect {
    protected override void Awake()
    {
        base.Awake();
        _name = "Waduhek?";
        _description = "Waduhek waduhek wadu wadu wadu waduhek! Hek wadu hek wadu wadu waduhek!";
        _rarity = (int)Rarity.legendary;
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].isDead = false;
        _targets[0].Health = _targets[0].MAX_HEALTH;
        Inactivate();
    }

}
