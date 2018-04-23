using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class Effect : MonoBehaviour
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
    public string getName {
        get { return _name; }
    }

    protected string _description;
    public string getDescription
    {
        get { return _description; }
    }

    protected Sprite _artwork;
    public Sprite getArt
    {
        get { return _artwork; }
    }
    protected virtual void Awake()
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

    public virtual void SetTarget(Player selection)
    {
        List<Player> TargetList = new List<Player>();
        TargetList.Add(selection);
        _targets = TargetList;
    }

    public virtual void RemoveTarget(Player selection)
    {
        if (_targets.Contains(selection))
            _targets.Remove(selection);
    }
};