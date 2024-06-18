using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial
{
    public class AdjustTimeToUtcInterceptor: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var argument = (string)invocation.Arguments[0];
            DateTimeOffset result;
            if (DateTimeOffset.TryParse(argument, out result))
            {
                argument = result.UtcDateTime.ToString();
                invocation.Arguments[0] = argument;
            }
            try
            {
                invocation.Proceed();
            }
            catch (FormatException)
            {
                invocation.ReturnValue = 0;
            }
        }
    }
}
