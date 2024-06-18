using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ThirtPartyLibrary;

namespace dynamicproxy_tutorial;

public class TimeFixSelector : IInterceptorSelector
{
    private static readonly MethodInfo[] methodsToAdjust =
      new[]
      {
      typeof(ITimeHelper).GetMethod("GetHour"),
      typeof(ITimeHelper).GetMethod("GetMinute")
      };
    private CheckNullInterceptor _checkNull = new CheckNullInterceptor();
    private AdjustTimeToUtcInterceptor _utcAdjust = new AdjustTimeToUtcInterceptor();

    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        if (!methodsToAdjust.Contains(method))
            return new IInterceptor[] { _checkNull }.Union(interceptors).ToArray();
        return new IInterceptor[] { _checkNull, _utcAdjust }.Union(interceptors).ToArray();
    }
}