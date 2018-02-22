using SAP.Common;
using SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.SelectActiveMembers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator
{
	public class StaffMemberViewModel : ViewModelBase, ISelectableViewModel
	{
		public StaffMemberViewModel(StaffMember staffMember, bool isSelected = false)
		{
			wrappedStaffMember = staffMember;
			IsSelected = isSelected;
			AssignedProgramAreaText = "None";
		}
		private StaffMember wrappedStaffMember;
		public StaffMember WrappedStaffMember
		{
			get
			{
				return wrappedStaffMember;
			}
			set
			{
				wrappedStaffMember = value;
				RaisePropertyChanged();
			}
		}

		public void UpdateExposedISelectableMembers()
		{
			RaisePropertyChanged(nameof(Name));
		}

		private bool isSelected;
		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				isSelected = value;
				RaisePropertyChanged();
			}
		}

		public string NickName
		{
			get
			{
				return WrappedStaffMember.NickName;
			}
			set
			{
				WrappedStaffMember.NickName = value;
				RaisePropertyChanged();
			}
		}
		public string FullName
		{
			get
			{
				return WrappedStaffMember.FullName;
			}
			set
			{
				WrappedStaffMember.FullName = value;
				RaisePropertyChanged();
			}
		}
		public string Name
		{
			get
			{
				return WrappedStaffMember.Name;
			}
		}
		public int IdNumber
		{
			get
			{
				return WrappedStaffMember.IdNumber;
			}
			internal set => WrappedStaffMember.IdNumber = value;
		}
		public string Email
		{
			get
			{
				return WrappedStaffMember.Email;
			}
			set
			{
				WrappedStaffMember.Email = value;
				RaisePropertyChanged();
			}
		}
		public string PhoneNumber
		{
			get
			{
				return WrappedStaffMember.PhoneNumber;
			}
			set
			{
				WrappedStaffMember.PhoneNumber = value;
				RaisePropertyChanged();
			}
		}
		public DateTime Birthday
		{
			get
			{
				return WrappedStaffMember.Birthday;
			}
			set
			{
				WrappedStaffMember.Birthday = value;
				RaisePropertyChanged();
				RaisePropertyChanged(nameof(IsEighteen));
				RaisePropertyChanged(nameof(CurrentAge));
			}
		}

		public ObservableCollection<Preference> Preferences
		{
			get
			{
				return new ObservableCollection<Preference>(WrappedStaffMember.Preferences);
			}
			set
			{
				WrappedStaffMember.Preferences = value.ToList();
				RaisePropertyChanged();
			}
		}


		public string[,] AfternoonAssignment
		{
			get
			{
				return WrappedStaffMember.AfternoonAssignment;
			}
			set
			{
				WrappedStaffMember.AfternoonAssignment = value;
				RaisePropertyChanged();
			}
		}

		public Cabin AssignedCabin
		{
			get
			{
				return WrappedStaffMember.AssignedCabin;
			}
			set
			{
				WrappedStaffMember.AssignedCabin = value;
				RaisePropertyChanged();
			}
		}

		public bool IsEighteen
		{
			get
			{
				return WrappedStaffMember.IsEighteen;
			}
		}

		public int CurrentAge
		{
			get
			{
				return WrappedStaffMember.CurrentAge;
			}
		}

		public void SetAfternoonAssignment(string value)
		{
			WrappedStaffMember.SetAllAfternoonAssignments(value);
			RaisePropertyChanged(nameof(AfternoonAssignment));
		}

		private string assignedProgramAreaText;
		public string AssignedProgramAreaText
		{
			get
			{
				return assignedProgramAreaText;
			}
			set
			{
				assignedProgramAreaText = value;
				RaisePropertyChanged();
			}
		}

		public void SetOvernightIfNeeded()
		{
			if (AssignedCabin == null)
			{
				return;
			}
		}

		public static StaffMemberViewModel RandomStaffMemberSelection = new StaffMemberViewModel(new StaffMember("Random", -1, DateTime.Today, "", "", null));
	}
}
