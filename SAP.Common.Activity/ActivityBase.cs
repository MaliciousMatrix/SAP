using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public abstract class ActivityBase : IActivity
	{
		protected internal ActivityBase(DayOfWeek day)
		{
			TimeSpan = CreateDuration(day, StartTime, EndTime);
		}

		public Duration TimeSpan { get; protected set; }

		public abstract ActivityType Type { get; }

		public DayOfWeek Day
		{
			get
			{
				return TimeSpan.StartTime.Day | TimeSpan.EndTime.Day;
			}
		}

		protected abstract double StartTime { get; }
		protected abstract double EndTime { get; }

		public bool ConflictsWith(IActivity activity)
		{
			return this.TimeSpan.ConfilctsWith(activity.TimeSpan);
		}

		public bool Equals(IActivity activity)
		{
			return activity.Type == this.Type && activity.TimeSpan == this.TimeSpan;
		}

		//public override string ToString()
		//{
		//    return $"{Day} {Type}";
		//}
		protected static Duration CreateDuration(DayOfWeek day, double start, double end)
		{
			Time startTime = new Time(day, start);
			Time endTime = new Time(day, end);
			return new Duration(startTime, endTime);
		}
	}
}
