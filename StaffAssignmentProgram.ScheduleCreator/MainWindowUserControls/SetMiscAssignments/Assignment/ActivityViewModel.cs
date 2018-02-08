using SAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.Assignment
{
	public class ActivityViewModel
	{
		public int StaffMemberId { get; set; } = -1;
		public EveningJob Assignment { get; set; } = EveningJob.None;

		//public bool Equals(ActivityViewModel activity)
		//{
		//	return activity.StaffMemberId == this.StaffMemberId && activity.Assignment == this.Assignment && activity.Day == this.Day;
		//}
	}
}
