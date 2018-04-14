public class AceTargetingZone : TargetingZone
{
    protected override void Awake()
    {
        GameInfo.singleton.aceTargetZone = this;
    }
}