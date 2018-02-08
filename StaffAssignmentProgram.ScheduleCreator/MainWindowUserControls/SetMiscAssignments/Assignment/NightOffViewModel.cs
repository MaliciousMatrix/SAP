using SAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.Assignment
{
	public class NightOffViewModel : EveningAssignmentBase
	{
		public NightOffViewModel(DayOfWeek day) : base(0, day)
		{
			ActivityType = EveningJob.Off;
		}
	}
}
