using SAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.Assignment
{
	public class CampfireViewModel : EveningAssignmentBase
	{
		public CampfireViewModel(int size, DayOfWeek day, bool isManagement) : base(size, day)
		{
			IsManagement = isManagement;
			ActivityType = EveningJob.Campfire;
			ManagementCheckBoxVisibility = System.Windows.Visibility.Visible;
		}
	}
}
