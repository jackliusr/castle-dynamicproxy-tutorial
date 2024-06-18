using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

public class FreezableProxyGenerationHook : IProxyGenerationHook
{
    public bool ShouldInterceptMethod(Type type, MethodInfo memberInfo)
    {
        return memberInfo.Name.StartsWith("set_", StringComparison.Ordinal);
    }

    public void NonVirtualMemberNotification(Type type, MemberInfo memberInfo)
    {
    }

    public void MethodsInspected()
    {
    }

    public void NonProxyableMemberNotification(Type type, MemberInfo memberInfo)
    {
        throw new NotImplementedException();
    }
}