public class SelfTargetingZone : TargetingZone
{
    protected override void Start()
    {
        GameInfo.singleton.selfTargetZone = this;
    }
}