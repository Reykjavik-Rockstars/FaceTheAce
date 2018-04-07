using System.Collections.Generic;

public abstract class Effect
{
    public List<Player> Targets;

    protected string _name;
    public string name
    {
        get
        {
            return _name;
        }
    }

    protected void Activate(List<Effect> EffectsFile)
    {
        GameInfo.singleton.ActiveEffects.Add(this);
    }

    protected void Inactivate()
    {
        GameInfo.singleton.ActiveEffects.Remove(this);
    }
};