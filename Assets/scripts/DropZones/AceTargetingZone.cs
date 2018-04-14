public class AceTargetingZone : TargetingZone
{
    protected override void Start()
    {
        GameInfo.singleton.aceTargetZone = this;
    }
}