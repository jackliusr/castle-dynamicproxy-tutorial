using Castle.DynamicProxy;
using dynamicproxy_tutorial;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace dynamicproxy_tutorial.Test;

public class MixinTests
{
    private static readonly ProxyGenerator generator = new ProxyGenerator();
    private readonly ITestOutputHelper output;

    public MixinTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void Test_Minxin()
    {
        var options = new ProxyGenerationOptions();
        options.AddMixinInstance(new Dictionary<string, object>());
        var person = (Person)generator.CreateClassProxy(typeof(Person), 
            typeof(Dictionary<string,object>).GetInterfaces().ToArray(), 
            options);
        var dictionary = person as IDictionary;
        dictionary.Add("Next Leave", DateTime.Now.AddMonths(4));
        UseSomewhereElse(person);
    }

    private void UseSomewhereElse(Person person)
    {
        var dictionary = person as IDictionary<string, object>;
        var date = ((DateTime)dictionary["Next Leave"]).Date;
        output.WriteLine("Next leave date of {0} is {1}", person.Name, date);

    }
}
