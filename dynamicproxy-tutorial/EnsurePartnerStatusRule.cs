namespace dynamicproxy_part01;

public class EnsurePartnerStatusRule : ISupportsInvalidation
{
    private bool _validated= false;
    public void Invalidate()
    {
        _validated = false;
    }
}