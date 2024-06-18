
using System.Xml.Linq;

namespace dynamicproxy_tutorial.Test;

public class WithNonVirtualMethod : Pet
{
    internal int NonVirtualMethod()
    {
        return Name.Length;

    }
}