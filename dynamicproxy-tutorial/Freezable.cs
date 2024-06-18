using Castle.DynamicProxy;

namespace dynamicproxy_tutorial;

public static class Freezable
{
    private static readonly IInterceptorSelector _selector = new FreezableInterceptorSelector();
    private static readonly ProxyGenerator Generator = new ProxyGenerator();
    public static bool IsFreezable(object obj)
    {
        return AsFreezable(obj) != null;
    }
    private static IFreezable AsFreezable(object target)
    {
        if (target == null)
            return null;
        var hack = target as IProxyTargetAccessor;
        if (hack == null)
            return null;
        return hack.GetInterceptors().FirstOrDefault(i => i is FreezableInterceptor) as IFreezable;
    }

    public static void Freeze(object freezable)
    {
        var interceptor = AsFreezable(freezable);
        if (interceptor == null)
            throw new NotFreezableObjectException(freezable);
        interceptor.Freeze();
    }

    public static bool IsFrozen(object obj)
    {
        var freezable = AsFreezable(obj);
        return freezable != null && freezable.IsFrozen;
    }

    public static TFreezable MakeFreezable<TFreezable>() where TFreezable : class, new()
    {
        var freezableInterceptor = new FreezableInterceptor();
        var options = new ProxyGenerationOptions(new FreezableProxyGenerationHook())
        {
            Selector = _selector,
        };
        var proxy = Generator.CreateClassProxy(typeof(TFreezable),
            options,
            new CallLoggingInterceptor(), freezableInterceptor);
        return proxy as TFreezable;
    }
}
