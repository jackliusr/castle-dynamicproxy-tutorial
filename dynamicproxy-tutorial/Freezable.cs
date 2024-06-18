using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

public static class Freezable
{
    private static readonly IDictionary<object, IFreezable> InstanceMap 
        = new Dictionary<object, IFreezable>();

    private static readonly ProxyGenerator Generator = new ProxyGenerator();
    public static bool IsFreezable(object obj)
    {
        return obj != null && InstanceMap.ContainsKey(obj);
    }


    public static void Freeze(object freezable)
    {
        if (!IsFreezable(freezable))
        {
            throw new NotFreezableObjectException(freezable);
        }

        InstanceMap[freezable].Freeze();
    }

    public static bool IsFrozen(object freezable)
    {
        return IsFreezable(freezable) && InstanceMap[freezable].IsFrozen;
    }

    public static TFreezable MakeFreezable<TFreezable>() where TFreezable : class, new()
    {
        var freezableInterceptor = new FreezableInterceptor();
        var options = new ProxyGenerationOptions(new FreezableProxyGenerationHook());
        var proxy = Generator.CreateClassProxy(typeof(TFreezable),
            options,
            new CallLoggingInterceptor(), freezableInterceptor);
        InstanceMap.Add(proxy, freezableInterceptor);
        return proxy as TFreezable;
    }
}
