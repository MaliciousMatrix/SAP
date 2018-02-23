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
        public MiscAssignmentViewModel(Activity activity, IEnumerable<IMember> activeMembers, int size)
        {
            AddMember = new DelegateCommand(ExecuteAddMember);
            DeleteMember = new DelegateCommand(ExecuteDeleteMember);
			ActiveMembers = new ObservableCollection<IMember>(activeMembers);
            _activity = activity;
            _size = size;
            ComboBoxValues = new ObservableCollection<MemberWrapper>();
            for(int i = 0; i < size; i++)
            {
                ExecuteAddMember(null);
            }
			RaisePropertyChanged(nameof(Day));
        }

		private ObservableCollection<IMember> _activeMembers;
		public ObservableCollection<IMember> ActiveMembers
		{
			get => _activeMembers;
			set
			{
				_activeMembers = value;
				RaisePropertyChanged();
			}
		}

		private Activity _activity;
		public Activity AssignedActivity
		{
			get => _activity;
		}

        private int _size;

        private ObservableCollection<MemberWrapper> _comboBoxValues;
        public ObservableCollection<MemberWrapper> ComboBoxValues
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

		// TODO: determine if this is necessary or if we should just remove this checkbox all together. 
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
			MemberWrapper wrapper = new MemberWrapper()
			{
				Member = ActiveMembers.First()
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
			foreach (var item in ComboBoxValues)
			{
				if (item.Member.IsRealMember())
				{
					item.Member.AssignActivity(AssignedActivity);
				}
			}
		}

		public string Day
		{
			get => _activity.Day.ToString();
		}

		public class MemberWrapper : ViewModelBase
		{
			private IMember _member; 
			public IMember Member
			{
				get => _member;
				set
				{
					_member = value;
					RaisePropertyChanged();
				}
			}
		}

    }
}
