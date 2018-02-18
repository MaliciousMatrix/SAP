using SAP.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.Assignment
{
    public class MiscAssignmentViewModel : ViewModelBase
    {
        public MiscAssignmentViewModel(Activity activity, int size, bool hasManagementSelection)
        {
            AddMember = new DelegateCommand(ExecuteAddMember);
            DeleteMember = new DelegateCommand(ExecuteDeleteMember);
            _activity = activity;
            _size = size;
            ComboBoxValues = new ObservableCollection<StaffWrapper>();
            for(int i = 0; i < size; i++)
            {
                ExecuteAddMember(null);
            }
        }

        private Activity _activity;
		public Activity AssignedActivity
		{
			get => _activity;
		}

        private int _size;

        private ObservableCollection<StaffWrapper> _comboBoxValues;
        public ObservableCollection<StaffWrapper> ComboBoxValues
        {
            get => _comboBoxValues;
            set
            {
                _comboBoxValues = value;
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
			StaffWrapper wrapper = new StaffWrapper()
			{
				StaffMember = StaffMember.Random
			};

			ComboBoxValues.Add(wrapper);
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

        private bool CanExecuteDeleteMember(object obj)
        {
            return false;
        }

		public void Assign()
		{
			foreach(var item in ComboBoxValues)
			{
				if (item.StaffMember.IsRealStaffMember())
				{
					item.StaffMember.Activities.Add(_activity);
				}
			}
		}

		public class StaffWrapper : ViewModelBase
		{
			private StaffMember _staffMember; 
			public StaffMember StaffMember
			{
				get => _staffMember;
				set
				{
					_staffMember = value;
					RaisePropertyChanged();
				}
			}
		}
    }
}
