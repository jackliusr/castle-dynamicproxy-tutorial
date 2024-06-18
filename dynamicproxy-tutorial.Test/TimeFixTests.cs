using dynamicproxy_tutorial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirtPartyLibrary;

namespace dynamicproxy_part01.Test;

public class TimeFixTests
{
    private ITimeHelper _sut;
    public TimeFixTests()
    {
        var fix = new TimeFix();
        _sut = fix.Fix(new TimeHelper());
    }

    [Fact]
    public void GetMinute_should_return_0_for_null()
    {
        int minute = _sut.GetMinute(null);
        int second = _sut.GetSecond(null);
        int hour = _sut.GetHour(null);
        Assert.Equal(0, minute);
        Assert.Equal(0, second);
        Assert.Equal(0, hour);
    }

    [Fact]
    public void Fixed_GetHour_properly_handles_non_utc_time()
    {
        var dateTimeOffset = new DateTimeOffset(2009, 10, 11, 09, 32, 11, TimeSpan.FromHours(-4.5));
        DateTimeOffset utcTime = dateTimeOffset.ToUniversalTime();
        string noUtcTime = dateTimeOffset.ToString();
        int utcHour = _sut.GetHour(noUtcTime);
        Assert.Equal(utcTime.Hour, utcHour);
    }

    [Fact]
    public void Fixed_GetMinute_properly_handles_non_utc_time()
    {
        var dateTimeOffset = new DateTimeOffset(2009, 10, 11, 09, 32, 11, TimeSpan.FromMinutes(45));
        DateTimeOffset utcTime = dateTimeOffset.ToUniversalTime();
        string noUtcTime = dateTimeOffset.ToString();

        int utcMinute = _sut.GetMinute(noUtcTime);
        Assert.Equal(utcTime.Minute, utcMinute);
    }


    [Fact]
    public void Fixed_GetHour_hadles_entries_in_invalid_format()
    {
        int result = _sut.GetHour("BOGUS ARGUMENT");
        Assert.Equal(0, result);
    }
}
