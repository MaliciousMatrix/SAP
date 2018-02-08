using SAP.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.Assignment
{
	public abstract class EveningAssignmentBase : ViewModelBase
	{
		public EveningAssignmentBase(int size, DayOfWeek day)
		{
			Day = day;
			defaultSize = size;
			AddMember = new DelegateCommand(ExecuteAddMember);
			DeleteMember = new DelegateCommand(ExecuteDeleteMember);
			SelectionChanged = new DelegateCommand(ExecuteSelectionChanged);

			ComboBoxValues = new ObservableCollection<int>();
			for (int i = 0; i < size; i++)
			{
				ExecuteAddMember(-1

					);
			}
			if (ComboBoxValues.Any())
			{
				IndexSelected = 0;
			}
		}
		private int defaultSize;
		private EveningJob activityType;
		public EveningJob ActivityType
		{
			get
			{
				return activityType;
			}
			protected set
			{
				activityType = value;
				RaisePropertyChanged();
			}
		}

		private bool isManagement;
		public bool IsManagement
		{
			get
			{
				return isManagement;
			}
			set
			{
				isManagement = value;
				RaisePropertyChanged();
				RaisePropertyChanged(nameof(NeedsStaff));
			}
		}

		public bool NeedsStaff
		{
			get
			{
				return !IsManagement;
			}
		}

		private Visibility managementCheckBoxVisibility = Visibility.Collapsed;
		public Visibility ManagementCheckBoxVisibility
		{
			get
			{
				return managementCheckBoxVisibility;
			}
			set
			{
				managementCheckBoxVisibility = value;
				RaisePropertyChanged();
			}
		}

		private DelegateCommand addMember;
		public DelegateCommand AddMember
		{
			get
			{
				return addMember;
			}
			set
			{
				addMember = value;
				RaisePropertyChanged();
			}
		}
		private void ExecuteAddMember(object obj)
		{
			ComboBoxValues.Add(-1);
		}

		private DelegateCommand deleteMember;
		public DelegateCommand DeleteMember
		{
			get
			{
				return deleteMember;
			}
			set
			{
				deleteMember = value;
				RaisePropertyChanged();
			}
		}
		private void ExecuteDeleteMember(object obj)
		{
			// TODO: What are we going to do to handle this case? 
		}

		private DayOfWeek day;
		public DayOfWeek Day
		{
			get
			{
				return day;
			}
			set
			{
				day = value;
				RaisePropertyChanged();
			}
		}

		private DelegateCommand selectionChanged;
		public DelegateCommand SelectionChanged
		{
			get
			{
				return selectionChanged;
			}
			set
			{
				selectionChanged = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteSelectionChanged(object obj)
		{
			SelectionChangedEventArgs args = (obj as SelectionChangedEventArgs);

			int indexToChange = -1;

			try
			{
				// First we try to check and see if there is a value in combo box values that is the same id as 
				// the staff member that we removed from the list. This is in a try catch because sometimes we are
				// not removing a staffmember and instead we are changing it from a random to a specific member.
				// In that case we want to find the cbv = -1 and use that index instead. 
				for (int i = 0; i < ComboBoxValues.Count; i++)
				{
					if (comboBoxValues[i] == (args.RemovedItems[0] as StaffMemberViewModel).WrappedStaffMember.IdNumber)
					{
						indexToChange = i;
						break;
					}
				}
			}
			catch { }

			// check for a cbv of -1 for victim index. 
			if (indexToChange == -1)
			{
				for (int i = 0; i < ComboBoxValues.Count; i++)
				{
					if (comboBoxValues[i] == -1)
					{
						indexToChange = i;
						break;
					}
				}
			}

			// If we didn't find a victim index something is wrong. 
			// TODO: change this to be better?
			if (indexToChange == -1)
			{
				throw new Exception("Tried to get evening activity... failed. ");
			}

			// Set the value to the id of the new selection. 
			comboBoxValues[indexToChange] = (args.AddedItems[0] as StaffMemberViewModel).WrappedStaffMember.IdNumber;
		}

		private ObservableCollection<int> comboBoxValues;
		public ObservableCollection<int> ComboBoxValues
		{
			get
			{
				return comboBoxValues;
			}
			set
			{
				comboBoxValues = value;
				RaisePropertyChanged();
			}
		}

		public IEnumerable<ActivityViewModel> GetSelectedComboBoxValues()
		{
			var returnValues = new List<ActivityViewModel>();
			if (IsManagement)
			{
				// If it is managagement (think campfire) we don't need to assign anyone to it so return an empty list.
				return returnValues;
			}

			foreach (var item in comboBoxValues)
			{
				returnValues.Add(new ActivityViewModel()
				{
					Assignment = ActivityType,
					//Day = this.Day,
					StaffMemberId = item,
				});
			}
			return returnValues;
		}

		private int indexSelected;
		public int IndexSelected
		{
			get => indexSelected;
			set
			{
				indexSelected = value;
				RaisePropertyChanged();
			}
		}

		public int GetNumberOfRequiredStaff()
		{
			return GetSelectedComboBoxValues().Count();
		}
	}
}
