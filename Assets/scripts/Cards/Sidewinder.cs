public class Sidewinder : Effect
{
    protected override void Awake()
    {
        base.Awake();
        _name = "Sidewinder";
        _description = "Deals 5 damage to target. (uncommon, cannot be negated).";
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].ReceiveDamage(5, _owner);
        Inactivate();
    }
}