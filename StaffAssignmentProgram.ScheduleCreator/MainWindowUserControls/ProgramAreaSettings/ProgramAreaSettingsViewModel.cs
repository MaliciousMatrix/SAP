using SAP.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.ProgramAreaSettings
{
	public class ProgramAreaSettingsViewModel : ScreenViewModelBase
	{

		private static ProgramAreaSettingsViewModel instance;
		public static ProgramAreaSettingsViewModel Instance
		{
			get
			{
				if (instance == null)
					instance = new ProgramAreaSettingsViewModel();
				return instance;
			}
		}
		private ProgramAreaSettingsViewModel()
		{
			name = "Program Area Settings";
			Init();
		}

		public override void Initialize(ScheduleCreationInfo scheduleCreationInfo)
		{
			base.Initialize(scheduleCreationInfo);

			_activeProgramAreas = scheduleCreationInfo.ActiveWorkAreas.Where(x => x.IsProgramArea).ToLocationViewModel();
			LocationViewModel.Advance = this.Advance;
			foreach (var area in _activeProgramAreas)
			{
				area.AssignedStaffnames = new List<string>();
				foreach (var member in scheduleCreationInfo.ActiveStaffMembers)
				{
					if (member.PStaffAssignment == area.WrappedLocation)
					{
						area.AssignedStaffnames.Add(member.Name);
					}
				}
			}
            RaisePropertyChanged(nameof(ActiveProgramAreas));
		}

		public override void Resolve()
		{
			
		}
        
        private ObservableCollection<LocationViewModel> _activeProgramAreas;
        public ObservableCollection<LocationViewModel> ActiveProgramAreas
        {
            get => _activeProgramAreas;
            set
            {
                _activeProgramAreas = value;
                RaisePropertyChanged();
            }
        }

		protected override bool CanExecuteAdvance(object obj)
		{
			int total = 0;
			foreach(var area in ActiveProgramAreas)
			{
				total += area.WrappedLocation.TargetStaffPercent;
			}
			return total == 100;
		}

		private bool _assignHalfOff;
		public bool AssignHalfOff
		{
			get => _assignHalfOff;
			set
			{
				_assignHalfOff = value;
				RaisePropertyChanged();
			}
		}

		public List<string> StaffTypes
		{
			get
			{
				List<string> returnValue = new List<string> { "P-Staff", "Counselors", "Both" };
				return returnValue;
			}
		}

		private string staffTypeOnEveningDishes;
		public string StaffTypeOnEveningDishes
		{
			get
			{
				return staffTypeOnEveningDishes;
			}
			set
			{
				staffTypeOnEveningDishes = value;
				RaisePropertyChanged();
			}
		}
	}

	internal static class Extensions
	{
		internal static ObservableCollection<LocationViewModel> ToLocationViewModel(this IEnumerable<Location> locationList)
		{
			return locationList.Select(x => new LocationViewModel(x)).ToObservableCollection();
		}
	}
}
