public class SelfTargetingZone : TargetingZone
{
    protected override void Awake()
    {
        
    }
    protected override void Start()
    {
        GameInfo.singleton.selfTargetZone = this;
        //base.Start();
    }
}