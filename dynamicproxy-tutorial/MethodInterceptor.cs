using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

internal class MethodInterceptor : IInterceptor
{
    private readonly Delegate _impl;

    public MethodInterceptor(Delegate @delegate)
    {
        this._impl = @delegate;
    }

    public Delegate Delegate { get { return _impl; }}

    public void Intercept(IInvocation invocation)
    {
        var result = this._impl.DynamicInvoke(invocation.Arguments);
        invocation.ReturnValue = result;
    }
}
