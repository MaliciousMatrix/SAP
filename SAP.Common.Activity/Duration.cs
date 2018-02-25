using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public class Duration
	{
		public Duration(Time startTime, Time endTime)
		{
			if (endTime <= startTime)
				throw new ArgumentOutOfRangeException("End time must be greater than start time.");

			EndTime = endTime;
			StartTime = startTime;
		}
		public Time StartTime { get; private set; }
		public Time EndTime { get; private set; }

		private static bool PrivateConflictsWith(Duration t1, Duration t2)
		{
			if (t2.StartTime > t1.StartTime && t2.StartTime < t1.EndTime)
			{
				return true;
			}
			//if(t2.EndTime > t1.StartTime && t2.EndTime < t1.EndTime)
			//{
			//    return true;
			//}

			return false;
		}
		public bool ConfilctsWith(Duration Duration, bool inclusive = false)
		{
			if (inclusive)
			{
				if (this.StartTime == Duration.EndTime || this.EndTime == Duration.StartTime)
					return true;
			}
			if (this.StartTime == Duration.StartTime || this.EndTime == Duration.EndTime)
				return true;

			// Much easier than writing out all logic twice :)
			return PrivateConflictsWith(this, Duration) || PrivateConflictsWith(Duration, this);
		}
	}
}
