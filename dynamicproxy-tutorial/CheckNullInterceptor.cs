using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

internal class CheckNullInterceptor: IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        if (invocation.Arguments[0] == null)
        {
            invocation.ReturnValue = 0;
            return;
        }
        invocation.Proceed();
    }
}
