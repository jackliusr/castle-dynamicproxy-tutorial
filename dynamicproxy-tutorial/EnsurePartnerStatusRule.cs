namespace dynamicproxy_tutorial;

public class EnsurePartnerStatusRule : ISupportsInvalidation
{
    private bool _validated= false;
    public void Invalidate()
    {
        _validated = false;
    }
}