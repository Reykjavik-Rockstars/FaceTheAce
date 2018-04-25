public class AceTargetingZone : TargetingZone
{
    protected override void Awake()
    {
        GameInfo.singleton.aceTargetZone = this;
    }

    protected override void Start()
    {
        //GameInfo.singleton.aceTargetZone = this;
    }

}