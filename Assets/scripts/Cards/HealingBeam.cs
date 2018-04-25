using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBeam : Effect {
    protected override void Awake()
    {
        base.Awake();
        _name = "Healing Beam";
        _description = "Heal your whole party by 30 health points!";
        _rarity = (int)Rarity.rare;
    }

    public override void Activate()
    {
        base.Activate();
        foreach (Player p in _targets){
            p.CmdReceiveHeal(30);
        }
        Inactivate();
    }

    public override void SetTarget(Player selection)
    {
        if( GameInfo.singleton.Players.Contains(selection)){
            _targets = GameInfo.singleton.Players;
        }
        else if (GameInfo.singleton.Boss == selection) {
            _targets.Add(selection);
        }
        
    }
}
