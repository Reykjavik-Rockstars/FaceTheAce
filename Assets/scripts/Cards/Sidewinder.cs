public class Sidewinder : Effect
{
    protected override void Awake()
    {
        base.Awake();
        _name = "Sidewinder";
        _description = "Deals 75 damage to target. (uncommon, cannot be negated).";
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].ReceiveDamage(75, _owner);
        Inactivate();
    }
}