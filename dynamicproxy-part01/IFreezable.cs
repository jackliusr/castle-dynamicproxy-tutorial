using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_part01;

public interface IFreezable
{
    bool IsFrozen { get; }
    void Freeze();
}
