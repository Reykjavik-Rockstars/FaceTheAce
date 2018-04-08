using System.Collections.Generic;

public abstract class Effect
{
    protected List<Player> _targets;
    public List<Player> Targets {
        get { return _targets; }
    }

    protected Player _owner;
    public Player Owner
    {
        get { return _owner; }
        set { _owner = value; }
    }

    protected string _name;
    public string Name {
        get{ return _name; }
    }

    public Effect()
    {
        _targets = new List<Player>();
    }

    public virtual void Activate()
    {
        GameInfo.singleton.ActiveEffects.Add(this);
    }

    public virtual void Inactivate()
    {
        GameInfo.singleton.ActiveEffects.Remove(this);
    }

    public virtual void SetTargets(List<Player> selection)
    {
        _targets = selection;
    }
};