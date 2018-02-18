using SAP.Common;
using SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.Assignment;
using SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments.NightConflict;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments
{
	public class SetMiscAssignmentsViewModel : ScreenViewModelBase
	{
		private static SetMiscAssignmentsViewModel instance;
		public static SetMiscAssignmentsViewModel Instance
		{
			get
			{
				if (instance == null)
					instance = new SetMiscAssignmentsViewModel();
				return instance;
			}
		}
		private SetMiscAssignmentsViewModel()
		{
			name = "Set Misc Assignments";
			Init();
		}

		public override void Initialize(ScheduleCreationInfo scheduleCreationInfo)
		{
			base.Initialize(scheduleCreationInfo);
            ActiveStaffMembers = new ObservableCollection<StaffMember>(scheduleCreationInfo.ActiveStaffMembers);
            ActiveStaffMembers.Insert(0,StaffMember.Random);
            InitCampfires();
			InitQueitCabinPatrols();
			InitNightsOff();

		}

        public override void Resolve()
		{
			foreach(var activity in _campfires)
			{
				if (activity.IsManagement)
					scheduleCreationInfo.NumberOnCampfire[(int)activity.AssignedActivity.Day] = -1;
				else
				{
					activity.Assign();
					scheduleCreationInfo.NumberOnCampfire[(int)activity.AssignedActivity.Day] = activity.ComboBoxValues.Count;
				}
			}

			foreach (var activity in _nightsOff)
			{
				activity.Assign();
			}

			foreach (var activity in _quietCabinPatrols)
			{
				activity.Assign();
			}
		}



        private ObservableCollection<StaffMember> _activeStaffMembers;
		public ObservableCollection<StaffMember> ActiveStaffMembers
        {
            get => _activeStaffMembers;
            set
            {
                _activeStaffMembers = value;
                RaisePropertyChanged();
            }
        }

		#region Campfires

		private MiscAssignmentViewModel[] _campfires;

		private void InitCampfires()
		{
			SundayCampfire = new MiscAssignmentViewModel
				(
				Activity.SundayCampfire,
				scheduleCreationInfo.NumberOnCampfire[(int)Activity.SundayCampfire.Day],
				true);
			MondayCampfire = new MiscAssignmentViewModel
				(
				Activity.MondayCampfire,
				scheduleCreationInfo.NumberOnCampfire[(int)Activity.MondayCampfire.Day],
				true);
			TuesdayCampfire = new MiscAssignmentViewModel
				(
				Activity.TuesdayCampfire,
				scheduleCreationInfo.NumberOnCampfire[(int)Activity.TuesdayCampfire.Day],
				true);
			WednesdayCampfire = new MiscAssignmentViewModel
				(
				Activity.WednesdayCampfire,
				scheduleCreationInfo.NumberOnCampfire[(int)Activity.WednesdayCampfire.Day],
				true);
			ThursdayCampfire = new MiscAssignmentViewModel
				(
				Activity.ThursdayCampfire,
				scheduleCreationInfo.NumberOnCampfire[(int)Activity.ThursdayCampfire.Day],
				true);
			FridayCampfire = new MiscAssignmentViewModel
				(
				Activity.FridayCampfire,
				scheduleCreationInfo.NumberOnCampfire[(int)Activity.FridayCampfire.Day],
				true);

			_campfires = new MiscAssignmentViewModel[6]
			{
				SundayCampfire,
				MondayCampfire,
				TuesdayCampfire,
				WednesdayCampfire,
				ThursdayCampfire,
				FridayCampfire,
			};
		}

		private MiscAssignmentViewModel _sundayCampfire;
        private MiscAssignmentViewModel _mondayCampfire;
        private MiscAssignmentViewModel _tuesdayCampfire;
        private MiscAssignmentViewModel _wednesdayCampfire;
        private MiscAssignmentViewModel _thursdayCampfire;
        private MiscAssignmentViewModel _fridayCampfire;

        public MiscAssignmentViewModel SundayCampfire
        {
            get => _sundayCampfire;
            set
            {
                _sundayCampfire = value;
                RaisePropertyChanged();
            }
        }

        public MiscAssignmentViewModel MondayCampfire
        {
            get => _mondayCampfire;
            set
            {
                _mondayCampfire = value;
                RaisePropertyChanged();
            }
        }

		public MiscAssignmentViewModel TuesdayCampfire
		{
			get => _tuesdayCampfire;
			set
			{
				_tuesdayCampfire = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel WednesdayCampfire
		{
			get => _wednesdayCampfire;
			set
			{
				_wednesdayCampfire = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel ThursdayCampfire
		{
			get => _thursdayCampfire;
			set
			{
				_thursdayCampfire = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel FridayCampfire
		{
			get => _fridayCampfire;
			set
			{
				_fridayCampfire = value;
				RaisePropertyChanged();
			}
		}

		#endregion Campfires

		#region Nights Off 

		private MiscAssignmentViewModel[] _nightsOff;

		private void InitNightsOff()
		{
			MondayNightOff = new MiscAssignmentViewModel
				(
				Activity.MondayNightOff,
				0,
				false);
			TuesdayNightOff = new MiscAssignmentViewModel
				(
				Activity.TuesdayNightOff,
				0,
				false);
			WednesdayNightOff = new MiscAssignmentViewModel
				(
				Activity.WednesdayNightOff,
				0,
				false);
			ThursdayNightOff = new MiscAssignmentViewModel
				(
				Activity.ThursdayNightOff,
				0,
				false);

			_nightsOff = new MiscAssignmentViewModel[4]
			{
				MondayNightOff,
				TuesdayNightOff,
				WednesdayNightOff,
				ThursdayNightOff
			};
		}

		private MiscAssignmentViewModel _mondayNightOff;
		private MiscAssignmentViewModel _tuesdayNightOff;
		private MiscAssignmentViewModel _wednesdayNightOff;
		private MiscAssignmentViewModel _thursdayNightOff;

		public MiscAssignmentViewModel MondayNightOff
		{
			get => _mondayNightOff;
			set
			{
				_mondayNightOff = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel TuesdayNightOff
		{
			get => _tuesdayNightOff;
			set
			{
				_tuesdayNightOff = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel WednesdayNightOff
		{
			get => _wednesdayNightOff;
			set
			{
				_wednesdayNightOff = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel ThursdayNightOff
		{
			get => _thursdayNightOff;
			set
			{
				_thursdayNightOff = value;
				RaisePropertyChanged();
			}
		}

		#endregion Nights Off

		#region Quiet Cabin Patrols 

		private MiscAssignmentViewModel[] _quietCabinPatrols;

		private void InitQueitCabinPatrols()
		{
			SundayQuietCabin = new MiscAssignmentViewModel
				(
				Activity.SundayQuietCabin,
				scheduleCreationInfo.NumberOnQuiteCabin[(int)Activity.SundayQuietCabin.Day],
				false
				);
			MondayQuietCabin = new MiscAssignmentViewModel
				(
				Activity.MondayQuietCabin,
				scheduleCreationInfo.NumberOnQuiteCabin[(int)Activity.MondayQuietCabin.Day],
				false
				);
			TuesdayQuietCabin = new MiscAssignmentViewModel
				(
				Activity.TuesdayQuietCabin,
				scheduleCreationInfo.NumberOnQuiteCabin[(int)Activity.TuesdayQuietCabin.Day],
				false
				);
			WednesdayQuietCabin = new MiscAssignmentViewModel
				(
				Activity.WednesdayQuietCabin,
				scheduleCreationInfo.NumberOnQuiteCabin[(int)Activity.WednesdayQuietCabin.Day],
				false
				);
			ThursdayQuietCabin = new MiscAssignmentViewModel
				(
				Activity.ThursdayQuietCabin,
				scheduleCreationInfo.NumberOnQuiteCabin[(int)Activity.ThursdayQuietCabin.Day],
				false
				);
			FridayQuietCabin = new MiscAssignmentViewModel
				(
				Activity.FridayQuietCabin,
				scheduleCreationInfo.NumberOnQuiteCabin[(int)Activity.FridayQuietCabin.Day],
				false
				);

			_quietCabinPatrols = new MiscAssignmentViewModel[6]
			{
				SundayQuietCabin,
				MondayQuietCabin,
				TuesdayQuietCabin,
				WednesdayQuietCabin,
				ThursdayQuietCabin,
				FridayQuietCabin
			};
		}

		private MiscAssignmentViewModel _sundayQuietCabin;
		private MiscAssignmentViewModel _mondayQuietCabin;
		private MiscAssignmentViewModel _tuesdayQuietCabin;
		private MiscAssignmentViewModel _wednesdayQuietCabin;
		private MiscAssignmentViewModel _thursdayQuietCabin;
		private MiscAssignmentViewModel _fridayQuietCabin;

		public MiscAssignmentViewModel SundayQuietCabin
		{
			get => _sundayQuietCabin;
			set
			{
				_sundayQuietCabin = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel MondayQuietCabin
		{
			get => _mondayQuietCabin;
			set
			{
				_mondayQuietCabin = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel TuesdayQuietCabin
		{
			get => _tuesdayQuietCabin;
			set
			{
				_tuesdayQuietCabin = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel WednesdayQuietCabin
		{
			get => _wednesdayQuietCabin;
			set
			{
				_wednesdayQuietCabin = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel ThursdayQuietCabin
		{
			get => _thursdayQuietCabin;
			set
			{
				_thursdayQuietCabin = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel FridayQuietCabin
		{
			get => _fridayQuietCabin;
			set
			{
				_fridayQuietCabin = value;
				RaisePropertyChanged();
			}
		}

		#endregion Quiet Cabin Patrols 





		//private CampfireViewModel[] _campfires;
		//private NightOffViewModel[] _nightsOff;
		//private QuietCabinViewModel[] _quietCabins;




		//#region Evening job assignment

		//#region Campfire 

		////private void InitCampfires()
		////{
		////	SundayCampfire = new CampfireViewModel(numberOnCampfire, DayOfWeek.Sunday, true);
		////	MondayCampfire = new CampfireViewModel(numberOnCampfire, DayOfWeek.Monday, false);
		////	TuesdayCampfire = new CampfireViewModel(numberOnCampfire, DayOfWeek.Tuesday, false);
		////	WednesdayCampfire = new CampfireViewModel(numberOnCampfire, DayOfWeek.Wednesday, false);
		////	ThursdayCampfire = new CampfireViewModel(numberOnCampfire, DayOfWeek.Thursday, false);
		////	FridayCampfire = new CampfireViewModel(numberOnCampfire, DayOfWeek.Friday, true);
		////}

		////private CampfireViewModel sundayCampfire;
		////private CampfireViewModel mondayCampfire;
		////private CampfireViewModel tuesdayCampfire;
		////private CampfireViewModel wednesdayCampfire;
		////private CampfireViewModel thursdayCampfire;
		////private CampfireViewModel fridayCampfire;

		//public CampfireViewModel SundayCampfire
		//{
		//	get
		//	{
		//		return _campfires[(int)DayOfWeek.Sunday];
		//	}
		//	set
		//	{
		//		_campfires[(int)DayOfWeek.Sunday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public CampfireViewModel MondayCampfire
		//{
		//	get
		//	{
		//		return _campfires[(int)DayOfWeek.Monday];
		//	}
		//	set
		//	{
		//		_campfires[(int)DayOfWeek.Monday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public CampfireViewModel TuesdayCampfire
		//{
		//	get
		//	{
		//		return _campfires[(int)DayOfWeek.Tuesday];
		//	}
		//	set
		//	{
		//		_campfires[(int)DayOfWeek.Tuesday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public CampfireViewModel WednesdayCampfire
		//{
		//	get
		//	{
		//		return _campfires[(int)DayOfWeek.Wednesday];
		//	}
		//	set
		//	{
		//		_campfires[(int)DayOfWeek.Wednesday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public CampfireViewModel ThursdayCampfire
		//{
		//	get
		//	{
		//		return _campfires[(int)DayOfWeek.Thursday];
		//	}
		//	set
		//	{
		//		_campfires[(int)DayOfWeek.Thursday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public CampfireViewModel FridayCampfire
		//{
		//	get
		//	{
		//		return _campfires[(int)DayOfWeek.Friday];
		//	}
		//	set
		//	{
		//		_campfires[(int)DayOfWeek.Friday] = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//#endregion Campfire

		//#region Nights Off

		////private void InitNightsOff()
		////{
		////	MondayNightOff = new NightOffViewModel(DayOfWeek.Monday);
		////	TuesdayNightOff = new NightOffViewModel(DayOfWeek.Tuesday);
		////	WednesdayNightOff = new NightOffViewModel(DayOfWeek.Wednesday);
		////	ThursdayNightOff = new NightOffViewModel(DayOfWeek.Thursday);
		////}

		////private NightOffViewModel mondayNightOff;
		////private NightOffViewModel tuesdayNightOff;
		////private NightOffViewModel wednesdayNightOff;
		////private NightOffViewModel thursdayNightOff;

		//public NightOffViewModel MondayNightOff
		//{
		//	get
		//	{
		//		return _nightsOff[(int)DayOfWeek.Monday];
		//	}
		//	set
		//	{
		//		_nightsOff[(int)DayOfWeek.Monday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public NightOffViewModel TuesdayNightOff
		//{
		//	get
		//	{
		//		return _nightsOff[(int)DayOfWeek.Tuesday];
		//	}
		//	set
		//	{
		//		_nightsOff[(int)DayOfWeek.Tuesday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public NightOffViewModel WednesdayNightOff
		//{
		//	get
		//	{
		//		return _nightsOff[(int)DayOfWeek.Wednesday];
		//	}
		//	set
		//	{
		//		_nightsOff[(int)DayOfWeek.Wednesday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public NightOffViewModel ThursdayNightOff
		//{
		//	get
		//	{
		//		return _nightsOff[(int)DayOfWeek.Thursday];
		//	}
		//	set
		//	{
		//		_nightsOff[(int)DayOfWeek.Thursday] = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//#endregion Nights Off

		//#region QuietCabin

		////private void InitQuietCabins()
		////{
		////	SundayQuietCabin = new QuietCabinViewModel(numberOnQuietCabin, DayOfWeek.Sunday);
		////	MondayQuietCabin = new QuietCabinViewModel(numberOnQuietCabin, DayOfWeek.Monday);
		////	TuesdayQuietCabin = new QuietCabinViewModel(numberOnQuietCabin, DayOfWeek.Tuesday);
		////	WednesdayQuietCabin = new QuietCabinViewModel(numberOnQuietCabin, DayOfWeek.Wednesday);
		////	ThursdayQuietCabin = new QuietCabinViewModel(numberOnQuietCabin, DayOfWeek.Thursday);
		////	FridayQuietCabin = new QuietCabinViewModel(numberOnQuietCabin, DayOfWeek.Friday);
		////}

		////private QuietCabinViewModel sundayQuietCabin;
		////private QuietCabinViewModel mondayQuietCabin;
		////private QuietCabinViewModel tuesdayQuietCabin;
		////private QuietCabinViewModel wednesdayQuietCabin;
		////private QuietCabinViewModel thursdayQuietCabin;
		////private QuietCabinViewModel fridayQuietCabin;

		//public QuietCabinViewModel SundayQuietCabin
		//{
		//	get
		//	{
		//		return _quietCabins[(int)DayOfWeek.Sunday];
		//	}
		//	set
		//	{
		//		_quietCabins[(int)DayOfWeek.Sunday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public QuietCabinViewModel MondayQuietCabin
		//{
		//	get
		//	{
		//		return _quietCabins[(int)DayOfWeek.Monday];
		//	}
		//	set
		//	{
		//		_quietCabins[(int)DayOfWeek.Monday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public QuietCabinViewModel TuesdayQuietCabin
		//{
		//	get
		//	{
		//		return _quietCabins[(int)DayOfWeek.Tuesday];
		//	}
		//	set
		//	{
		//		_quietCabins[(int)DayOfWeek.Tuesday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public QuietCabinViewModel WednesdayQuietCabin
		//{
		//	get
		//	{
		//		return _quietCabins[(int)DayOfWeek.Wednesday];
		//	}
		//	set
		//	{
		//		_quietCabins[(int)DayOfWeek.Wednesday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public QuietCabinViewModel ThursdayQuietCabin
		//{
		//	get
		//	{
		//		return _quietCabins[(int)DayOfWeek.Thursday];
		//	}
		//	set
		//	{
		//		_quietCabins[(int)DayOfWeek.Thursday] = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//public QuietCabinViewModel FridayQuietCabin
		//{
		//	get
		//	{
		//		return _quietCabins[(int)DayOfWeek.Friday];
		//	}
		//	set
		//	{
		//		_quietCabins[(int)DayOfWeek.Friday] = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//#endregion QuietCabin

		//private void ResolveAndSetEveningAssignments()
		//{
		//	foreach (var member in ActiveStaffMembers)
		//	{
		//		IEnumerable<ActivityViewModel> activities = GetAssignedEveningActivitiesFromStaffMemberId(member.IdNumber);

		//		List<EveningJob>[] activitiesByNight = new List<EveningJob>[]
		//		{
		//			new List<EveningJob>(),
		//			new List<EveningJob>(),
		//			new List<EveningJob>(),
		//			new List<EveningJob>(),
		//			new List<EveningJob>(),
		//			new List<EveningJob>(),
		//		};

		//		foreach (var a in activities)
		//		{
		//			activitiesByNight[(int)a.Day].Add(a.Assignment);
		//		}

		//		for (int i = 0; i < member.WrappedStaffMember.EveningActivities.Count(); i++)
		//		{
		//			if (member.WrappedStaffMember.EveningActivities[i] != EveningJob.None)
		//			{
		//				activitiesByNight[i].Add(member.WrappedStaffMember.EveningActivities[i]);
		//			}
		//			// TODO: Change this, this doesn't resolve the conflicts. Just removes them. 
		//			activitiesByNight[i] = activitiesByNight[i].Distinct().ToList();
		//		}

		//		bool hasConflicts = false;
		//		foreach (var activity in activitiesByNight)
		//		{
		//			if (activity.Count() > 1)
		//			{
		//				hasConflicts = true;
		//				break;
		//			}
		//		}
		//		ResolveEveningConflicts conflicts = null;
		//		if (hasConflicts)
		//		{
		//			conflicts = new ResolveEveningConflicts(member, activitiesByNight);
		//			conflicts.ShowDialog();
		//		}

		//		for (int i = 0; i < 6; i++)
		//		{
		//			if (activitiesByNight[i].Count == 1)
		//			{
		//				member.WrappedStaffMember.EveningActivities[i] = activitiesByNight[i].First();
		//			}
		//		}

		//		if (conflicts != null)
		//		{
		//			var assn = conflicts.GetAssignments();
		//			for (int i = 0; i < 6; i++)
		//			{
		//				if (assn[i] != EveningJob.None)
		//				{
		//					member.WrappedStaffMember.EveningActivities[i] = assn[i];
		//				}
		//			}
		//		}
		//	}
		//}

		//private IEnumerable<ActivityViewModel> GetAssignedEveningActivitiesFromStaffMemberId(int idNumber)
		//{
		//	IEnumerable<ActivityViewModel> activities = new List<ActivityViewModel>();

		//	activities = activities.Concat(SundayCampfire.GetSelectedComboBoxValues());
		//	activities = activities.Concat(MondayCampfire.GetSelectedComboBoxValues());
		//	activities = activities.Concat(TuesdayCampfire.GetSelectedComboBoxValues());
		//	activities = activities.Concat(WednesdayCampfire.GetSelectedComboBoxValues());
		//	activities = activities.Concat(ThursdayCampfire.GetSelectedComboBoxValues());
		//	activities = activities.Concat(FridayCampfire.GetSelectedComboBoxValues());

		//	activities = activities.Concat(MondayNightOff.GetSelectedComboBoxValues());
		//	activities = activities.Concat(TuesdayNightOff.GetSelectedComboBoxValues());
		//	activities = activities.Concat(WednesdayNightOff.GetSelectedComboBoxValues());
		//	activities = activities.Concat(ThursdayNightOff.GetSelectedComboBoxValues());

		//	activities = activities.Concat(SundayQuietCabin.GetSelectedComboBoxValues());
		//	activities = activities.Concat(MondayQuietCabin.GetSelectedComboBoxValues());
		//	activities = activities.Concat(TuesdayQuietCabin.GetSelectedComboBoxValues());
		//	activities = activities.Concat(WednesdayQuietCabin.GetSelectedComboBoxValues());
		//	activities = activities.Concat(ThursdayQuietCabin.GetSelectedComboBoxValues());
		//	activities = activities.Concat(FridayQuietCabin.GetSelectedComboBoxValues());

		//	return activities.Where(x => x.StaffMemberId == idNumber);
		//}

		//#endregion Evening job assignment
	}
}
