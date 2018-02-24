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
			_activeStaffMembers = new List<StaffMember>() { StaffMember.Random }.Concat(scheduleCreationInfo.ActiveStaffMembers).ToList();
			_activeCabins = new List<Cabin>() { Cabin.Random }.Concat(scheduleCreationInfo.ActiveCabins).ToList();

			InitializeMiscAssignmentViewModels();
		}

        public override void Resolve()
		{
			// TODO: This is the ideal way to take care of this and should eventually be implemented. 
			// Activities should be responisible for all of their own number management in scheduleCreationInfo. 
			//foreach (var activity in _allMiscAssignments)
			//{
			//	if (!activity.IsManagement)
			//		activity.Assign();
			//}

			foreach(var activity in _campfires)
			{
				scheduleCreationInfo.NumberOnCampfire[(int)activity.AssignedActivity.Day] = activity.ComboBoxValues.Count();
				activity.Assign();
			}

			foreach (var activity in _nightsOff)
			{
				activity.Assign();
			}

			foreach (var activity in _quietCabinPatrols)
			{
				scheduleCreationInfo.NumberOnQuiteCabin[(int)activity.AssignedActivity.Day] = activity.ComboBoxValues.Count();
				activity.Assign();
			}

			foreach(var activity in _powerUps)
			{
				scheduleCreationInfo.NumberOnPowerUp[(int)activity.AssignedActivity.Day] = activity.ComboBoxValues.Count();
				activity.Assign();
			}

			foreach(var activity in _tradingPosts)
			{
				scheduleCreationInfo.NumberOnTradingPost[(int)activity.AssignedActivity.Day] = activity.ComboBoxValues.Count();
				activity.Assign();
			}

			foreach(var activity in _flagLowerings)
			{
				scheduleCreationInfo.NumberOnFlagLowering[(int)activity.AssignedActivity.Day] = activity.ComboBoxValues.Count();
				activity.Assign();
			}

			foreach(var activity in _flagRaisings)
			{
				scheduleCreationInfo.NumberOnFlagRaising[(int)activity.AssignedActivity.Day] = activity.ComboBoxValues.Count();
				activity.Assign();
			}

			foreach(var activity in _lunchGraces)
			{
				activity.Assign();
			}
		}

		private void InitializeMiscAssignmentViewModels()
		{
			_allMiscAssignments = new List<MiscAssignmentViewModel>();
			InitCampfires();
			InitNightsOff();
			InitQueitCabinPatrols();
			InitPowerUps();
			InitTradingPosts();
			InitFlagLowerings();
			InitFlagRaisings();
			InitLunchGraces();
		}

		private List<StaffMember> _activeStaffMembers;
		private List<Cabin> _activeCabins;
		private IEnumerable<MiscAssignmentViewModel> _allMiscAssignments;

		private void ConcatToAllMiscAssignments(IEnumerable<MiscAssignmentViewModel> assignmentList)
		{
			_allMiscAssignments = _allMiscAssignments.Concat(assignmentList);
		}

		#region Campfires

		private MiscAssignmentViewModel[] _campfires;

		private void InitCampfires()
		{
			// should have the same values due to it being initialized that way. 
			int defaultNumberOnCampfire = scheduleCreationInfo.NumberOnCampfire[0];
			MondayCampfire = new MiscAssignmentViewModel(Activity.MondayCampfire, _activeStaffMembers, defaultNumberOnCampfire);
			TuesdayCampfire = new MiscAssignmentViewModel(Activity.TuesdayCampfire, _activeStaffMembers, defaultNumberOnCampfire);
			WednesdayCampfire = new MiscAssignmentViewModel(Activity.WednesdayCampfire, _activeStaffMembers, defaultNumberOnCampfire);
			ThursdayCampfire = new MiscAssignmentViewModel(Activity.ThursdayCampfire, _activeStaffMembers, defaultNumberOnCampfire);

			_campfires = new MiscAssignmentViewModel[4]
			{
				MondayCampfire,
				TuesdayCampfire,
				WednesdayCampfire,
				ThursdayCampfire,
			};

			ConcatToAllMiscAssignments(_campfires);
		}

        private MiscAssignmentViewModel _mondayCampfire;
        private MiscAssignmentViewModel _tuesdayCampfire;
        private MiscAssignmentViewModel _wednesdayCampfire;
        private MiscAssignmentViewModel _thursdayCampfire;

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

		#endregion Campfires

		#region Nights Off 

		private MiscAssignmentViewModel[] _nightsOff;

		private void InitNightsOff()
		{
			// Night off count is determined later. By default we shouldn't have any inputs. 
			int defaultNightOffCount = 0;
			MondayNightOff = new MiscAssignmentViewModel(Activity.MondayNightOff, _activeStaffMembers, defaultNightOffCount);
			TuesdayNightOff = new MiscAssignmentViewModel(Activity.TuesdayNightOff, _activeStaffMembers, defaultNightOffCount);
			WednesdayNightOff = new MiscAssignmentViewModel(Activity.WednesdayNightOff, _activeStaffMembers, defaultNightOffCount);
			ThursdayNightOff = new MiscAssignmentViewModel(Activity.ThursdayNightOff, _activeStaffMembers, defaultNightOffCount);

			_nightsOff = new MiscAssignmentViewModel[4]
			{
				MondayNightOff,
				TuesdayNightOff,
				WednesdayNightOff,
				ThursdayNightOff
			};

			ConcatToAllMiscAssignments(_nightsOff);
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
			int defaultNumberOnQC = scheduleCreationInfo.NumberOnQuiteCabin[0];
			SundayQuietCabin = new MiscAssignmentViewModel(Activity.SundayQuietCabin, _activeStaffMembers, defaultNumberOnQC);
			MondayQuietCabin = new MiscAssignmentViewModel(Activity.MondayQuietCabin, _activeStaffMembers, defaultNumberOnQC);
			TuesdayQuietCabin = new MiscAssignmentViewModel(Activity.TuesdayQuietCabin, _activeStaffMembers, defaultNumberOnQC);
			WednesdayQuietCabin = new MiscAssignmentViewModel(Activity.WednesdayQuietCabin, _activeStaffMembers, defaultNumberOnQC);
			ThursdayQuietCabin = new MiscAssignmentViewModel(Activity.ThursdayQuietCabin, _activeStaffMembers, defaultNumberOnQC);
			FridayQuietCabin = new MiscAssignmentViewModel(Activity.FridayQuietCabin, _activeStaffMembers, defaultNumberOnQC);

			_quietCabinPatrols = new MiscAssignmentViewModel[6]
			{
				SundayQuietCabin,
				MondayQuietCabin,
				TuesdayQuietCabin,
				WednesdayQuietCabin,
				ThursdayQuietCabin,
				FridayQuietCabin
			};

			ConcatToAllMiscAssignments(_quietCabinPatrols);
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

		#region Powerup Assistants

		private MiscAssignmentViewModel[] _powerUps;

		private void InitPowerUps()
		{
			int numOnPowerup = scheduleCreationInfo.NumberOnPowerUp[0];
			MondayPowerUp = new MiscAssignmentViewModel(Activity.MondayPowerUp, _activeStaffMembers, numOnPowerup);
			TuesdayPowerUp = new MiscAssignmentViewModel(Activity.TuesdayPowerUp, _activeStaffMembers, numOnPowerup);
			WednesdayPowerUp = new MiscAssignmentViewModel(Activity.WednesdayPowerUp, _activeStaffMembers, numOnPowerup);
			ThursdayPowerUp = new MiscAssignmentViewModel(Activity.ThursdayPowerUp, _activeStaffMembers, numOnPowerup);
			FridayPowerUp = new MiscAssignmentViewModel(Activity.FridayPowerUp, _activeStaffMembers, numOnPowerup);

			_powerUps = new MiscAssignmentViewModel[5]
			{
				MondayPowerUp,
				TuesdayPowerUp,
				WednesdayPowerUp,
				ThursdayPowerUp,
				FridayPowerUp
			};

			ConcatToAllMiscAssignments(_powerUps);
		}

		private MiscAssignmentViewModel _mondayPowerUp;
		private MiscAssignmentViewModel _tuesdayPowerUp;
		private MiscAssignmentViewModel _wednesdayPowerUp;
		private MiscAssignmentViewModel _thursdayPowerUp;
		private MiscAssignmentViewModel _fridayPowerUp;

		public MiscAssignmentViewModel MondayPowerUp
		{
			get => _mondayPowerUp;
			set
			{
				_mondayPowerUp = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel TuesdayPowerUp
		{
			get => _tuesdayPowerUp;
			set
			{
				_tuesdayPowerUp = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel WednesdayPowerUp
		{
			get => _wednesdayPowerUp;
			set
			{
				_wednesdayPowerUp = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel ThursdayPowerUp
		{
			get => _thursdayPowerUp;
			set
			{
				_thursdayPowerUp = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel FridayPowerUp
		{
			get => _fridayPowerUp;
			set
			{
				_fridayPowerUp = value;
				RaisePropertyChanged();
			}
		}

		#endregion Powerup Assistants 

		#region Trading Post

		private MiscAssignmentViewModel[] _tradingPosts;

		private void InitTradingPosts()
		{
			int numOnTradingPost = scheduleCreationInfo.NumberOnTradingPost[0];
			MondayTradingPost = new MiscAssignmentViewModel(Activity.MondayTradingPost, _activeStaffMembers, numOnTradingPost);
			TuesdayTradingPost = new MiscAssignmentViewModel(Activity.TuesdayTradingPost, _activeStaffMembers, numOnTradingPost);
			WednesdayTradingPost = new MiscAssignmentViewModel(Activity.WednesdayTradingPost, _activeStaffMembers, numOnTradingPost);
			ThursdayTradingPost = new MiscAssignmentViewModel(Activity.ThursdayTradingPost, _activeStaffMembers, numOnTradingPost);
			FridayTradingPost = new MiscAssignmentViewModel(Activity.FridayTradingPost, _activeStaffMembers, numOnTradingPost);

			_tradingPosts = new MiscAssignmentViewModel[5]
			{
				MondayTradingPost,
				TuesdayTradingPost,
				WednesdayTradingPost,
				ThursdayTradingPost,
				FridayTradingPost
			};

			ConcatToAllMiscAssignments(_tradingPosts);
		}

		private MiscAssignmentViewModel _mondayTradingPost;
		private MiscAssignmentViewModel _tuesdayTradingPost;
		private MiscAssignmentViewModel _wednesdayTradingPost;
		private MiscAssignmentViewModel _thursdayTradingPost;
		private MiscAssignmentViewModel _fridayTradingPost;

		public MiscAssignmentViewModel MondayTradingPost
		{
			get => _mondayTradingPost;
			set
			{
				_mondayTradingPost = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel TuesdayTradingPost
		{
			get => _tuesdayTradingPost;
			set
			{
				_tuesdayTradingPost = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel WednesdayTradingPost
		{
			get => _wednesdayTradingPost;
			set
			{
				_wednesdayTradingPost = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel ThursdayTradingPost
		{
			get => _thursdayTradingPost;
			set
			{
				_thursdayTradingPost = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel FridayTradingPost
		{
			get => _fridayTradingPost;
			set
			{
				_fridayTradingPost = value;
				RaisePropertyChanged();
			}
		}

		#endregion Trading Post

		#region Flag Lowering 

		private MiscAssignmentViewModel[] _flagLowerings;

		private void InitFlagLowerings()
		{
			SundayFlagLowering = new MiscAssignmentViewModel(Activity.SundayFlagLowering, _activeCabins, 1);
			MondayFlagLowering = new MiscAssignmentViewModel(Activity.MondayFlagLowering, _activeCabins, 1);
			TuesdayFlagLowering = new MiscAssignmentViewModel(Activity.MondayFlagLowering, _activeCabins, 1);
			WednesdayFlagLowering = new MiscAssignmentViewModel(Activity.MondayFlagLowering, _activeCabins, 1);
			ThursdayFlagLowering = new MiscAssignmentViewModel(Activity.MondayFlagLowering, _activeCabins, 1);
			FridayFlagLowering = new MiscAssignmentViewModel(Activity.MondayFlagLowering, _activeCabins, 1);

			_flagLowerings = new MiscAssignmentViewModel[6]
			{
				SundayFlagLowering,
				MondayFlagLowering,
				TuesdayFlagLowering,
				WednesdayFlagLowering,
				ThursdayFlagLowering,
				FridayFlagLowering
			};

			ConcatToAllMiscAssignments(_flagLowerings);
		}

		private MiscAssignmentViewModel _sundayFlagLowering;
        private MiscAssignmentViewModel _mondayFlagLowering;
        private MiscAssignmentViewModel _tuesdayFlagLowering;
        private MiscAssignmentViewModel _wednesdayFlagLowering;
        private MiscAssignmentViewModel _thursdayFlagLowering;
        private MiscAssignmentViewModel _fridayFlagLowering;

		public MiscAssignmentViewModel SundayFlagLowering
		{
			get => _sundayFlagLowering;
			set
			{
				_sundayFlagLowering = value;
				RaisePropertyChanged();
			}
		}

        public MiscAssignmentViewModel MondayFlagLowering
        {
            get => _mondayFlagLowering;
            set
            {
                _mondayFlagLowering = value;
                RaisePropertyChanged();
            }
        }

        public MiscAssignmentViewModel TuesdayFlagLowering
        {
            get => _tuesdayFlagLowering;
            set
            {
                _tuesdayFlagLowering = value;
                RaisePropertyChanged();
            }
        }

        public MiscAssignmentViewModel WednesdayFlagLowering
        {
            get => _wednesdayFlagLowering;
            set
            {
                _wednesdayFlagLowering = value;
                RaisePropertyChanged();
            }
        }

        public MiscAssignmentViewModel ThursdayFlagLowering
        {
            get => _thursdayFlagLowering;
            set
            {
                _thursdayFlagLowering = value;
                RaisePropertyChanged();
            }
        }

		public MiscAssignmentViewModel FridayFlagLowering
		{
			get => _fridayFlagLowering;
			set
			{
				_fridayFlagLowering = value;
				RaisePropertyChanged();
			}
		}

		#endregion Flag Lowering 

		#region Flag Raising 

		private MiscAssignmentViewModel[] _flagRaisings;

		private void InitFlagRaisings()
		{
			MondayFlagRaising = new MiscAssignmentViewModel(Activity.MondayFlagRaising, _activeCabins, 1);
			TuesdayFlagRaising = new MiscAssignmentViewModel(Activity.TuesdayFlagRaising, _activeCabins, 1);
			WednesdayFlagRaising = new MiscAssignmentViewModel(Activity.WednesdayFlagRaising, _activeCabins, 1);
			ThursdayFlagRaising = new MiscAssignmentViewModel(Activity.ThursdayFlagRaising, _activeCabins, 1);
			FridayFlagRaising = new MiscAssignmentViewModel(Activity.FridayFlagRaising, _activeCabins, 1);
			SaturdayFlagRaising = new MiscAssignmentViewModel(Activity.SaturdayFlagRaising, _activeCabins, 1);

			_flagRaisings = new MiscAssignmentViewModel[6]
			{
				MondayFlagRaising,
				TuesdayFlagRaising,
				WednesdayFlagRaising,
				ThursdayFlagRaising,
				FridayFlagRaising,
				SaturdayFlagRaising
			};

			ConcatToAllMiscAssignments(_flagRaisings);
		}

		private MiscAssignmentViewModel _mondayFlagRaising;
		private MiscAssignmentViewModel _tuesdayFlagRaising;
		private MiscAssignmentViewModel _wednesdayFlagRaising;
		private MiscAssignmentViewModel _thursdayFlagRaising;
		private MiscAssignmentViewModel _fridayFlagRaising;
		private MiscAssignmentViewModel _saturdayFlagRaising;

		public MiscAssignmentViewModel MondayFlagRaising
		{
			get => _mondayFlagRaising;
			set
			{
				_mondayFlagRaising = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel TuesdayFlagRaising
		{
			get => _tuesdayFlagRaising;
			set
			{
				_tuesdayFlagRaising = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel WednesdayFlagRaising
		{
			get => _wednesdayFlagRaising;
			set
			{
				_wednesdayFlagRaising = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel ThursdayFlagRaising
		{
			get => _thursdayFlagRaising;
			set
			{
				_thursdayFlagRaising = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel FridayFlagRaising
		{
			get => _fridayFlagRaising;
			set
			{
				_fridayFlagRaising = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel SaturdayFlagRaising
		{
			get => _saturdayFlagRaising;
			set
			{
				_saturdayFlagRaising = value;
				RaisePropertyChanged();
			}
		}

		#endregion Flag Raising 

		#region Lunch Grace 

		private MiscAssignmentViewModel[] _lunchGraces;

		private void InitLunchGraces()
		{
			// should really always be one. 
			int numberOnLunchGrace = 1;
			MondayLunchGrace = new MiscAssignmentViewModel(Activity.MondayLunchGrace, _activeStaffMembers, numberOnLunchGrace);
			TuesdayLunchGrace = new MiscAssignmentViewModel(Activity.TuesdayLunchGrace, _activeStaffMembers, numberOnLunchGrace);
			WednesdayLunchGrace = new MiscAssignmentViewModel(Activity.WednesdayLunchGrace, _activeStaffMembers, numberOnLunchGrace);
			ThursdayLunchGrace = new MiscAssignmentViewModel(Activity.ThursdayLunchGrace, _activeStaffMembers, numberOnLunchGrace);
			FridayLunchGrace = new MiscAssignmentViewModel(Activity.FridayLunchGrace, _activeStaffMembers, numberOnLunchGrace);

			_lunchGraces = new MiscAssignmentViewModel[5]
			{
				MondayLunchGrace,
				TuesdayLunchGrace,
				WednesdayLunchGrace,
				ThursdayLunchGrace,
				FridayLunchGrace
			};

			ConcatToAllMiscAssignments(_lunchGraces);
		}

		private MiscAssignmentViewModel _mondayLunchGrace;
		private MiscAssignmentViewModel _tuesdayLunchGrace;
		private MiscAssignmentViewModel _wednesdayLunchGrace;
		private MiscAssignmentViewModel _thursdayLunchGrace;
		private MiscAssignmentViewModel _fridayLunchGrace;

		public MiscAssignmentViewModel MondayLunchGrace
		{
			get => _mondayLunchGrace;
			set
			{
				_mondayLunchGrace = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel TuesdayLunchGrace
		{
			get => _tuesdayLunchGrace;
			set
			{
				_tuesdayLunchGrace = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel WednesdayLunchGrace
		{
			get => _wednesdayLunchGrace;
			set
			{
				_wednesdayLunchGrace = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel ThursdayLunchGrace
		{
			get => _thursdayLunchGrace;
			set
			{
				_thursdayLunchGrace = value;
				RaisePropertyChanged();
			}
		}

		public MiscAssignmentViewModel FridayLunchGrace
		{
			get => _fridayLunchGrace;
			set
			{
				_fridayLunchGrace = value;
				RaisePropertyChanged();
			}
		}

		#endregion Lunch Grace 
	}
}
