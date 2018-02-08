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

namespace SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.AddEditStaff
{
	/// <summary>
	/// Interaction logic for AddEditStaff.xaml
	/// </summary>
	public partial class AddEditStaff : Window
	{
		private AddEditStaffViewModel aesVM;

		public AddEditStaff(StaffMemberViewModel Staff)
		{
			aesVM = new AddEditStaffViewModel(Staff, false);
			DataContext = aesVM;
			aesVM.ClosingRequest += (sender, e) => this.Close();
			InitializeComponent();
		}
		public AddEditStaff(List<Preference> preferences)
		{
			var member = new StaffMemberViewModel(new StaffMember("", 0, DateTime.Today, "", "", preferences, ""));
			aesVM = new AddEditStaffViewModel(member, true);
			DataContext = aesVM;
			aesVM.ClosingRequest += (sender, e) => this.Close();
			InitializeComponent();
		}

		public StaffMemberViewModel Staff
		{
			get
			{
				return aesVM.SelectedStaff;
			}
		}
		public bool SaveStaff
		{
			get
			{
				return aesVM.SaveChanges;
			}
		}
	}
}
