using Castle.DynamicProxy;
using System.Reflection;

namespace dynamicproxy_tutorial;

public class FreezableProxyGenerationHook : IProxyGenerationHook
{
    public bool ShouldInterceptMethod(Type type, MethodInfo memberInfo)
    {
        return memberInfo.IsSpecialName &&
           (IsSetterName(memberInfo.Name) ||
             IsGetterName(memberInfo.Name));
    }
    private bool IsGetterName(string name)
    {
        return name.StartsWith("get_", StringComparison.Ordinal);
    }

    private bool IsSetterName(string name)
    {
        return name.StartsWith("set_", StringComparison.Ordinal);
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