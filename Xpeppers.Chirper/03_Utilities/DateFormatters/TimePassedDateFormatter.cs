using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class TimePassedDateFormatter : IDateFormatter
    {
        public const double secondsInMinute = 60;
        public const double secondsInHour = secondsInMinute * 60;
        public const double secondsInDay = secondsInHour * 24;

        public string FormatDate(DateTime date)
        {
            double secondsPassed = (DateTime.Now - date).TotalSeconds;

            if (secondsPassed >= secondsInDay)
            {
                double daysPassed = secondsPassed / secondsInDay;
                return ConcatFormattedDate(daysPassed, "day");
            }

            if (secondsPassed >= secondsInHour)
            {
                double hoursPassed = secondsPassed / secondsInHour;
                return ConcatFormattedDate(hoursPassed, "hour");
            }

            if (secondsPassed >= secondsInMinute)
            {
                double minutesPassed = secondsPassed / secondsInMinute;
                return ConcatFormattedDate(minutesPassed, "minute");
            }

            return ConcatFormattedDate(secondsPassed, "second");
            
            //return string.Format("{0:dd/MM/yyyy hh:mm}", date);
        }

        private string ConcatFormattedDate(double units, string uom)
        {
            double roundedUnits = Math.Round(units, 0);
            return string.Format("({0:N0} {1}{2} ago)", roundedUnits, uom, ReturnPluralWhenNeeded(roundedUnits));
        }

        private string ReturnPluralWhenNeeded(double units)
        {
            if (units > 1)
                return "s";

            return "";
        }
    }
}
