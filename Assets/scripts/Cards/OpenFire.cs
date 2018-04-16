public class OpenFire : Effect
{
    protected override void Awake()
    {
        base.Awake();
        _name = "Open Fire";
        _description = "Deals 5 damage to target.";
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].ReceiveDamage(50, _owner);
        Inactivate();
    }
}