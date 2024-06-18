using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

public interface IStorage
{
    void Save(object data);
}
