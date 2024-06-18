using Castle.DynamicProxy;
using System.Reflection;

namespace dynamicproxy_tutorial;

public class FreezableInterceptor : IInterceptor, IFreezable, IHasCount
{
    private int _count = 0;
    public void Freeze()
    {
        IsFrozen = true;
    }

    public bool IsFrozen { get; private set; }

    public int Count {  get { return _count; } }

    public void Intercept(IInvocation invocation)
    {
        _count++;
        if (IsFrozen && IsSetter(invocation.Method))
        {
            throw new ObjectFrozenException();
        }
        invocation.Proceed();
    }

    private static bool IsSetter(MethodInfo method)
    {
        return method.IsSpecialName && method.Name.StartsWith("set_", StringComparison.OrdinalIgnoreCase);
    }
}
