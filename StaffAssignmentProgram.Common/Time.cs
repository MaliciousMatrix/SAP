using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class Time
	{
		public DayOfWeek Day { get; set; }

		private double _hour;
		public double Hour
		{
			get => _hour;
			set
			{
				if (value >= 0 && value < 24)
					_hour = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}

		public string GetHourAsClockTime(bool getAsMilitary = false)
		{
			int hour = 0;
			int minute = 0;
			string postfix = String.Empty;

			hour = (int)Hour;
			minute = (int)(Hour - hour) * 60;

			if (!getAsMilitary)
			{
				postfix = (hour >= 12) ? "pm" : "am";
				hour %= 12;
				if (hour == 0)
					hour += 12;
			}

			return $"{hour}:{minute} {postfix}";

		}

		public bool Equals(Time other)
		{
			return other.Day == this.Day && other.Hour == this.Hour;
		}

		public static bool operator > (Time first, Time second)
		{
			if ((int)first.Day > (int)second.Day)
				return true;
			if ((int)first.Day < (int)second.Day)
				return false;
			return first.Hour > second.Hour;
		}
		public static bool operator < (Time first, Time second)
		{
			return !(first > second) && !first.Equals(second); 
		}
	}
}
