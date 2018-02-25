using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class Time
	{
		public Time(DayOfWeek day, double hour)
		{
			Day = day;
			Hour = hour;
		}
		public DayOfWeek Day { get; private set; }

		private double _hour;
		public double Hour
		{
			get => _hour;
			private set
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
			minute = (int)((Hour - hour) * 60);

			if (!getAsMilitary)
			{
				postfix = (hour >= 12) ? " pm" : " am";
				hour %= 12;
				if (hour == 0)
					hour += 12;
			}
			return ($"{GetHoursString(hour, getAsMilitary)}:{GetMinutesAsString(minute)}{postfix}");

		}

		private string GetHoursString(int hours, bool getAsMilitary)
		{
			string s = hours.ToString();
			if (!getAsMilitary || s.Length == 2)
				return s;
			return "0" + s;
		}
		private string GetMinutesAsString(int minutes)
		{
			string s = minutes.ToString();
			while (s.Length < 2)
				s = "0" + s;
			return s;
		}

		public bool Equals(Time other)
		{
			return other.Day == this.Day && other.Hour == this.Hour;
		}

		public static bool operator ==(Time first, Time second)
		{
			return first.Equals(second);
		}

		public static bool operator !=(Time first, Time second)
		{
			return !(first.Equals(second));
		}

		public static bool operator >(Time first, Time second)
		{
			if ((int)first.Day > (int)second.Day)
				return true;
			if ((int)first.Day < (int)second.Day)
				return false;
			return first.Hour > second.Hour;
		}

		public static bool operator <(Time first, Time second)
		{
			return !(first > second) && first != second;
		}

		public static bool operator >=(Time first, Time second)
		{
			return first > second || first == second;
		}

		public static bool operator <=(Time first, Time second)
		{
			return first < second || first == second;
		}
	}
}
