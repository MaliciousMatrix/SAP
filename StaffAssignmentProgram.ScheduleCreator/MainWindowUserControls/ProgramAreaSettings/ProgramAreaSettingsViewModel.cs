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
			InitDefaultUIValues();

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
			scheduleCreationInfo.NumberOnCampfire = new int[]
			{
				numberOnCampfire, // Sunday
				numberOnCampfire, // Monday
				numberOnCampfire, // Tuesday
				numberOnCampfire, // Wednesday
				numberOnCampfire, // Thursday
				numberOnCampfire, // Friday
			};

			scheduleCreationInfo.NumberOnQuiteCabin = new int[]
			{
				numberOnQuietCabin, // Sunday
				numberOnQuietCabin, // Monday
				numberOnQuietCabin, // Tuesday
				numberOnQuietCabin, // Wednesday
				numberOnQuietCabin, // Thursday
				numberOnQuietCabin // Friday
			};

			scheduleCreationInfo.NumberOnDishes = new int[,]
			{
				{ // Sunday
					0,
					0,
					numberOnDishes,
				},
				{ // Monday
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Tuesday
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Wednesday
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Thursdsay
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Friday
					numberOnDishes,
					numberOnDishes,
					numberOnDishes,
				},
				{ // Saturday
					numberOnDishes,
					0,
					0,
				},
			};
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

		private void InitDefaultUIValues()
		{
			AssignHalfOff = true;
			TakePreferencesIntoAccount = true;
			NumberOnDishes = "4";
			NumberOnCampfire = "4";
			NumberOnQuietCabin = "2";
			StaffTypeOnEveningDishes = "P-Staff";
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

		private bool _takePreferencesIntoAccount;
		public bool TakePreferencesIntoAccount
		{
			get => _takePreferencesIntoAccount;
			set
			{
				_takePreferencesIntoAccount = value;
				RaisePropertyChanged();
			}
		}

		private int numberOnDishes;
		public string NumberOnDishes
		{
			get
			{
				return numberOnDishes.ToString();
			}
			set
			{
				int val = numberOnDishes;
				Int32.TryParse(value, out val);
				numberOnDishes = val;
				RaisePropertyChanged();
			}
		}

		private int numberOnCampfire;
		public string NumberOnCampfire
		{
			get
			{
				return numberOnCampfire.ToString();
			}
			set
			{
				int val = numberOnCampfire;
				Int32.TryParse(value, out val);
				numberOnCampfire = val;
				RaisePropertyChanged();
			}
		}

		private int numberOnQuietCabin;
		public string NumberOnQuietCabin
		{
			get
			{
				return numberOnQuietCabin.ToString();
			}
			set
			{
				int val = numberOnQuietCabin;
				Int32.TryParse(value, out val);
				numberOnQuietCabin = val;
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
