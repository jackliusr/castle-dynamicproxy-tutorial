using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirtPartyLibrary;

public interface ITimeHelper
{
    int GetHour(string dateTime);
    int GetMinute(string dateTime);
    int GetSecond(string dateTime);
}