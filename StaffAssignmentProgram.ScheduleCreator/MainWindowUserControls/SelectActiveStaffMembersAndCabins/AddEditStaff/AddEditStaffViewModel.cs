using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.AddEditStaff
{
	class AddEditStaffViewModel : ViewModelBase
	{
		public AddEditStaffViewModel(StaffMemberViewModel _staff, bool isNewStaff)
		{
			IsNewStaff = isNewStaff;
			selectedStaff = _staff;
			InitValues();
		}

		private void InitValues()
		{
			Save = new DelegateCommand(ExecuteSave);
			Cancel = new DelegateCommand(ExecuteCancel);
			IdNumber = IsNewStaff ? "Unassigned" : selectedStaff.IdNumber.ToString();
			FullName = selectedStaff.FullName;
			NickName = selectedStaff.NickName;
			Birthday = SelectedStaff.Birthday;
			Email = SelectedStaff.Email;
			PhoneNumber = SelectedStaff.PhoneNumber;
			Preferences = new ObservableCollection<PreferenceViewModel>();
			foreach (var preference in SelectedStaff.Preferences)
			{
				Preferences.Add(new PreferenceViewModel(preference));
			}
		}
		public bool SaveChanges { get; private set; } = false;
		public bool IsNewStaff { get; private set; }
		private StaffMemberViewModel selectedStaff;
		public StaffMemberViewModel SelectedStaff
		{
			get
			{
				return selectedStaff;
			}
		}

		private ObservableCollection<PreferenceViewModel> preferences;
		public ObservableCollection<PreferenceViewModel> Preferences
		{
			get
			{
				return preferences;
			}
			set
			{
				preferences = value;
				RaisePropertyChanged();
			}
		}

		private string idNumber;
		public string IdNumber
		{
			get
			{
				return idNumber;
			}
			private set
			{
				idNumber = value;
				RaisePropertyChanged();
			}
		}

		private string fullName;
		public string FullName
		{
			get
			{
				return fullName;
			}
			set
			{
				fullName = value;
				RaisePropertyChanged();
			}
		}

		private string nickName;
		public string NickName
		{
			get
			{
				return nickName;
			}
			set
			{
				nickName = value;
				RaisePropertyChanged();
			}
		}

		private DateTime birthday;
		public DateTime Birthday
		{
			get
			{
				return birthday;
			}
			set
			{
				birthday = value;
				RaisePropertyChanged();
			}
		}

		private string email;
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
				RaisePropertyChanged();
			}
		}

		private string phoneNumber;
		public string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}
			set
			{
				phoneNumber = value;
				RaisePropertyChanged();
			}
		}

		private DelegateCommand save;
		public DelegateCommand Save
		{
			get
			{
				return save;
			}
			set
			{
				save = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteSave(object obj)
		{
			SaveChanges = true;
			selectedStaff.FullName = FullName;
			selectedStaff.NickName = NickName;
			selectedStaff.Birthday = Birthday;
			selectedStaff.Email = Email;
			selectedStaff.PhoneNumber = PhoneNumber;
			foreach (var preference in Preferences)
			{
				preference.SaveChanges();
			}
			ExecuteCancel(obj);
		}

		private DelegateCommand cancel;
		public DelegateCommand Cancel
		{
			get
			{
				return cancel;
			}
			set
			{
				cancel = value;
				RaisePropertyChanged();
			}
		}

		private void ExecuteCancel(object obj)
		{
			OnClosingRequest();
		}
	}
}
