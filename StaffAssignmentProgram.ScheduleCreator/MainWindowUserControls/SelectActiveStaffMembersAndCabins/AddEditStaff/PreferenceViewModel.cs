using SAP.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.AddEditStaff
{
	public class PreferenceViewModel : ViewModelBase
	{
		public PreferenceViewModel(Preference wrappedPreference)
		{
			WrappedPreference = wrappedPreference;
			InitValues();
		}

		private void InitValues()
		{
			ProgramAreaName = WrappedPreference.ProgramAreaName;
			PreferenceValue = WrappedPreference.PreferenceValue;
		}

		private Preference wrappedPreference;
		public Preference WrappedPreference
		{
			get
			{
				return wrappedPreference;
			}
			set
			{
				wrappedPreference = value;
				RaisePropertyChanged();
			}
		}

		private string programAreaName;
		public string ProgramAreaName
		{
			get
			{
				return programAreaName;
			}
			set
			{
				programAreaName = value;
				RaisePropertyChanged();
			}
		}

		private int preferenceValue;
		public int PreferenceValue
		{
			get
			{
				return preferenceValue;
			}
			set
			{
				preferenceValue = value;
				RaisePropertyChanged();
			}
		}

		public void SaveChanges()
		{
			WrappedPreference.PreferenceValue = PreferenceValue;
			WrappedPreference.ProgramAreaName = ProgramAreaName;
		}

		public ObservableCollection<PreferenceValue> PreferenceValues
		{
			get
			{
				return GetPreferenceValues();
			}
		}
		private ObservableCollection<PreferenceValue> GetPreferenceValues()
		{
			return new ObservableCollection<PreferenceValue>(Enum.GetValues(typeof(PreferenceValue)).Cast<PreferenceValue>().ToList());
		}
	}
}
