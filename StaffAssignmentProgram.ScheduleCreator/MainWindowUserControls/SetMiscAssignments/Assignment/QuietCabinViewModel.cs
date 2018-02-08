using SAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.Assignment
{
	public class QuietCabinViewModel : EveningAssignmentBase
	{
		public QuietCabinViewModel(int size, DayOfWeek day) : base(size, day)
		{
			ActivityType = EveningJob.QuietCabin;
		}
	}
}
