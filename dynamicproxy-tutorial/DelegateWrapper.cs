using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

public class DelegateWrapper
{
    public static T WrapAs<T>(Delegate impl) where T : class
    {
        var generator = new ProxyGenerator();
        var proxy = generator.CreateInterfaceProxyWithoutTarget(typeof(T), new MethodInterceptor(impl));
        return (T)proxy;
    }
    public static TInterface WrapAs<TInterface>(Delegate d1, Delegate d2) where TInterface : class
    {
        var generator = new ProxyGenerator();
        var options = new ProxyGenerationOptions { Selector = new DelegateSelector() };

        var proxy = generator.CreateInterfaceProxyWithoutTarget(typeof(TInterface),
            new Type[0], options,
            new MethodInterceptor(d1),
            new MethodInterceptor(d2)
            );
    
        return (TInterface)proxy;
    }

}
