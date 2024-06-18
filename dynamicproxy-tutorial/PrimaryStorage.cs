using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_tutorial;

public class PrimaryStorage: IStorage
{
    private IList<object> _items = new List<object>();

    public IList<object> Items
    {
        get { return _items; }
    }

    public bool IsUp { get; set; }

    public void Save(object data)
    {
        _items.Add(data);
    }
}
