public class Sidewinder : Effect
{
    public Sidewinder() : base()
    {
        _name = "Sidewinder";
    }

    public override void Activate()
    {
        base.Activate();
        _targets[0].ReceiveDamage(5, _owner);
        Inactivate();
    }
}