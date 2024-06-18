using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace dynamicproxy_tutorial.Test;

public class PersistantTest
{
    private readonly ITestOutputHelper _output;
    ProxyGenerator generator = new ProxyGenerator();

    public  PersistantTest(ITestOutputHelper output)
    {
        _output = output;
    }
    [Fact]
    public void Test_Persistant()
    {
        var savePhysicalAssembly = true;
        var strongAssemblyName = ModuleScope.DEFAULT_ASSEMBLY_NAME;
        var strongModulePath = ModuleScope.DEFAULT_FILE_NAME;
        var weakAssemblyName = "Foo.Bar.Proxies";
        var weakModulePath = "Foo.Bar.Proxies.dll";
        var scope = new ModuleScope(
            savePhysicalAssembly,
            true, //disable sign
            strongAssemblyName,
            strongModulePath,
            weakAssemblyName,
            weakModulePath);
        var builder = new DefaultProxyBuilder(scope);
        var generator = new ProxyGenerator(builder);
        _output.WriteLine(scope.WeakNamedModuleName);
    }

}
