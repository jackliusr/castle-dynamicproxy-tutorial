using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirtPartyLibrary;

namespace dynamicproxy_tutorial;

public class TimeFix
{
    private ProxyGenerator _generator = new ProxyGenerator();
    private ProxyGenerationOptions _options = new ProxyGenerationOptions { Selector = new TimeFixSelector() };

    public ITimeHelper Fix(ITimeHelper item)
    {
        return (ITimeHelper)_generator.CreateInterfaceProxyWithTarget(typeof(ITimeHelper), item, _options);
    }
}
