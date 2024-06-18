namespace dynamicproxy_tutorial;

public class ApplyDiscountRule : ISupportsInvalidation, IClientRule
{
    private bool _validated = false;
    public void Invalidate()
    {
        _validated = true;
    }
}