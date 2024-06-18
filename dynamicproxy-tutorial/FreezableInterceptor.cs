using Castle.DynamicProxy;
using System.Reflection;

namespace dynamicproxy_tutorial;

public class FreezableInterceptor : IInterceptor, IFreezable
{
    public void Freeze()
    {
        IsFrozen = true;
    }

    public bool IsFrozen { get; private set; }





    public void Intercept(IInvocation invocation)
    {
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
