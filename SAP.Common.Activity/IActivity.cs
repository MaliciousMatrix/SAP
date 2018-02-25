using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Activity
{
	public interface IActivity
	{
		Duration Time { get; }
		ActivityType Type { get; }
		DayOfWeek Day { get; }

		bool ConflictsWith(IActivity activity);
	}
}
