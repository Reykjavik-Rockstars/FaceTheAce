public class openFire : Effect
{
    public openFire() : base()
    {
        _name = "Open Fire";
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].ReceiveDamage(5, _owner);
        Inactivate();
    }
}