namespace dynamicproxy_part01;

public class ApplyDiscountRule : ISupportsInvalidation, IClientRule
{
    private bool _validated = false;
    public void Invalidate()
    {
        _validated = true;
    }
}