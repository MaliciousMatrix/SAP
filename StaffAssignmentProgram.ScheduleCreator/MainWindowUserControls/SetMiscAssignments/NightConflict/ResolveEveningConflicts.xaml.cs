using SAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.NightConflict
{
	/// <summary>
	/// Interaction logic for ResolveEveningConflicts.xaml
	/// </summary>
	public partial class ResolveEveningConflicts : Window
	{
		private ResolveEveningConflictsViewModel recvm;
		public ResolveEveningConflicts(StaffMemberViewModel staffMember, List<EveningJob>[] possibleSelections)
		{
			WindowStyle = WindowStyle.None;
			recvm = new ResolveEveningConflictsViewModel(staffMember, possibleSelections);
			DataContext = recvm;
			recvm.ClosingRequest += (sender, e) => this.Close();
			InitializeComponent();
		}

		public EveningJob[] GetAssignments()
		{
			EveningJob[] returnValues = new EveningJob[]
			{
				EveningJob.None,
				EveningJob.None,
				EveningJob.None,
				EveningJob.None,
				EveningJob.None,
				EveningJob.None,
			};

			foreach (var conflict in recvm.NightConflicts)
			{
				returnValues[(int)conflict.Day] = (EveningJob)Enum.Parse(typeof(EveningJob), conflict.Assignment);
			}

			return returnValues;
		}
	}
}
