using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public static class Extensions
    {
        public static bool IsWorkingDay(this DateTime dt)
        {
            return dt.DayOfWeek != DayOfWeek.Saturday &&
                dt.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}
