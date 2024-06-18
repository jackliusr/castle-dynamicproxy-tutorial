using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

public class StorageFactory
{
    private readonly IStorage _primaryStorage;
    private ProxyGenerator _generator;

    public StorageFactory(IStorage primaryStorage)
    {
        _primaryStorage = primaryStorage;
        _generator = new ProxyGenerator();
    }

    public IStorage SecondaryStorage { private get; set; }

    public IStorage GetStorage()
    {
        var interceptor = new StorageInterceptor(SecondaryStorage);
        object storage = _generator.CreateInterfaceProxyWithTargetInterface(typeof(IStorage), _primaryStorage, interceptor);
        return storage as IStorage;
    }
}
