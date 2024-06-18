using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial.Test;
public class MoreInterfaces
{
    private static readonly ProxyGenerator generator = new ProxyGenerator();
    [Fact]
    public void ClassProxy_should_implement_additional_interfaces()
    {
        object proxy = generator.CreateClassProxy(
          typeof(EnsurePartnerStatusRule),
          new[] { typeof(ISupportsInvalidation) },
          new InvalidationInterceptor());

        Assert.IsAssignableFrom<ISupportsInvalidation>(proxy);
    }
    [Fact]
    public void ClassProxy_for_class_already_implementing_additional_interfaces()
    {
        object proxy = generator.CreateClassProxy(
          typeof(ApplyDiscountRule),
          new[] { typeof(ISupportsInvalidation) });
        Assert.IsAssignableFrom<ISupportsInvalidation>(proxy);
        var exception = Record.Exception(() => (proxy as ISupportsInvalidation).Invalidate());
        Assert.Null(exception);
    }
    [Fact]
    public void InterfaceProxy_should_implement_additional_interfaces()
    {
        object proxy = generator.CreateInterfaceProxyWithTarget(
          typeof(IClientRule),
          new[] { typeof(ISupportsInvalidation) },
          new ApplyDiscountRule());
        Assert.IsAssignableFrom<ISupportsInvalidation>(proxy);
        var exception = Record.Exception(() => (proxy as ISupportsInvalidation).Invalidate());
        Assert.Null(exception);
    }
}

