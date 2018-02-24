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
			if (endTime > startTime)
				throw new ArgumentOutOfRangeException();

			EndTime = endTime;
			StartTime = startTime;
		}
		public Time StartTime { get; private set; }
		public Time EndTime { get; private set; }
	}
}
