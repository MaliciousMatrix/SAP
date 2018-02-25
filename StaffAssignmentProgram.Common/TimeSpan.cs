using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class TimeSpan
	{
		public TimeSpan(Time startTime, Time endTime)
		{
			if (endTime >= startTime)
				throw new ArgumentOutOfRangeException("End time must be greater than start time.");

			EndTime = endTime;
			StartTime = startTime;
		}
		public Time StartTime { get; private set; }
		public Time EndTime { get; private set; }

        private static bool PrivateConflictsWith(TimeSpan t1, TimeSpan t2)
        {
            if (t2.StartTime >= t1.StartTime && t2.StartTime <= t1.EndTime)
            {
                return true;
            }
            if(t2.EndTime >= t1.StartTime && t2.EndTime <= t1.EndTime)
            {
                return true;
            }

            return false;
        }
        public bool ConfilctsWith(TimeSpan timeSpan, bool inclusive = false)
        {
            if (inclusive)
            {
                if (this.StartTime == timeSpan.EndTime || this.EndTime == timeSpan.StartTime)
                    return true;
            }

            // Much easier than writing out all logic twice :)
            return PrivateConflictsWith(this, timeSpan) || PrivateConflictsWith(timeSpan, this);           
        }
	}
}
