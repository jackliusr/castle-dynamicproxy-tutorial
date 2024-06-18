using dynamicproxy_tutorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dynamicproxy_part01.Test;

public class Tests
{
    private PrimaryStorage _primaryStorage;
    private SecondaryStorage _secondaryStorage;
    private StorageFactory _sut;

    public Tests()
    {
        _primaryStorage = new PrimaryStorage { IsUp = true };
        _sut = new StorageFactory(_primaryStorage);
        _secondaryStorage = new SecondaryStorage();
        _sut.SecondaryStorage = _secondaryStorage;
    }

    [Fact]
    public void Save_should_use_primaryStorage_when_it_is_up()
    {
        IStorage storage = _sut.GetStorage();
        string message = "message";
        storage.Save(message);

        Assert.Empty(_secondaryStorage.Items);
        Assert.NotEmpty(_primaryStorage.Items);
        Assert.Equal(message, _primaryStorage.Items.First());
    }

    [Fact]
    public void Save_should_use_secondaryStorage_when_primaryStorage_is_down()
    {
        _primaryStorage.IsUp = false;
        IStorage storage = _sut.GetStorage();
        string message = "message";
        storage.Save(message);

        Assert.Empty(_primaryStorage.Items);
        Assert.NotEmpty(_secondaryStorage.Items);
        Assert.Equal(message, _secondaryStorage.Items.First());
    }

    [Fact]
    public void Save_should_go_back_to_primaryStorage_when_is_goes_from_down_to_up()
    {
        IStorage storage = _sut.GetStorage();
        string message1 = "message1";
        string message2 = "message2";
        string message3 = "message3";

        storage.Save(message1);
        _primaryStorage.IsUp = false;
        storage.Save(message2);
        _primaryStorage.IsUp = true;
        storage.Save(message3);
        IList<object> primary = _primaryStorage.Items;
        IList<object> secondary = _secondaryStorage.Items;

        Assert.Equal(2, primary.Count);
        Assert.Equal(1, secondary.Count);
        Assert.Contains(message1, primary);
        Assert.Contains(message3, primary);
        Assert.Contains(message2, secondary);
    }
}
