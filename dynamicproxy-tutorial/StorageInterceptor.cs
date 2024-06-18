using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

internal class StorageInterceptor: IInterceptor
{
    private readonly IStorage _secondaryStorage;

    public StorageInterceptor(IStorage secondaryStorage)
    {
        _secondaryStorage = secondaryStorage;
    }

    public void Intercept(IInvocation invocation)
    {
        var primaryStorage = invocation.InvocationTarget as PrimaryStorage;
        if (primaryStorage.IsUp == false)
        {
            ChangeToSecondaryStorage(invocation);
        }
        invocation.Proceed();
    }

    private void ChangeToSecondaryStorage(IInvocation invocation)
    {
        var changeProxyTarget = invocation as IChangeProxyTarget;
        changeProxyTarget.ChangeInvocationTarget(_secondaryStorage);
    }
}
