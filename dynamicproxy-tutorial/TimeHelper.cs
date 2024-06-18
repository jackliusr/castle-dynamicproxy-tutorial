using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtPartyLibrary;

public sealed class TimeHelper : ITimeHelper
{
    public int GetHour(string dateTime)
    {
        DateTime time = DateTime.Parse(dateTime);
        return time.Hour;
    }

    public int GetMinute(string dateTime)
    {
        DateTime time = DateTime.Parse(dateTime);
        return time.Minute;
    }

    public int GetSecond(string dateTime)
    {
        DateTime time = DateTime.Parse(dateTime);
        return time.Second;
    }
}
