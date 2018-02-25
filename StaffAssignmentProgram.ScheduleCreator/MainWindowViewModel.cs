using SAP.Common;
using SAP.ScheduleCreator.MainWindowUserControls;
using SAP.ScheduleCreator.MainWindowUserControls.AssignStaffToCabinsAndPStaff;
using SAP.ScheduleCreator.MainWindowUserControls.GenerationSettings;
using SAP.ScheduleCreator.MainWindowUserControls.ProgramAreaSettings;
using SAP.ScheduleCreator.MainWindowUserControls.ReviewSelectedStaffAndCabins;
using SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins;
using SAP.ScheduleCreator.MainWindowUserControls.SetCabinSchedules;
using SAP.ScheduleCreator.MainWindowUserControls.SetMiscAssignments;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator
{
	public class MainWindowViewModel : ViewModelBase
	{
		private ScheduleCreationInfo _scheduleCreationInfo;
		public MainWindowViewModel()
		{
			_scheduleCreationInfo = new ScheduleCreationInfo();
			InitDataFromDb();
			_screenObjects = InitScreenObjects();
			CurrentTab = 0;
		}

		private ScreenViewModelBase _currentScreen;
		public ScreenViewModelBase CurrentScreen
		{
			get => _currentScreen;
			set
			{
				_currentScreen = value;
				RaisePropertyChanged();
				//RaisePropertyChanged(nameof(CurrentTab));
				RaisePropertyChanged(nameof(CurrentStageText));
			}
		}

		private int _currentTab;
		public int CurrentTab
		{
			get => _currentTab;
			set
			{
				_currentTab = value;
				ChangeScreens();

				RaisePropertyChanged();
			}
		}

		private void ChangeScreens()
		{
			CurrentScreen?.Resolve();
			CurrentScreen = _screenObjects[_currentTab];

			// Update advance and retreat buttons. 
			CurrentScreen.Initialize(_scheduleCreationInfo);
			AdvanceStage = CurrentScreen.Advance;
			AdvanceStage.RaiseCanExecuteChanged();

			RetreatStage = CurrentScreen.Retreat;
			RetreatStage.RaiseCanExecuteChanged();
		}

		public string CurrentStageText
		{
			get => CurrentScreen.Name;
		}

		private DelegateCommand _advanceStage;

		public DelegateCommand AdvanceStage
		{
			get
			{
				return _advanceStage;
			}
			set
			{
				_advanceStage = value;
				RaisePropertyChanged();
			}
		}

		private DelegateCommand _retreatScreen;
		public DelegateCommand RetreatStage
		{
			get => _retreatScreen;
			set
			{
				_retreatScreen = value;
				RaisePropertyChanged();
			}
		}

		private List<ScreenViewModelBase> InitScreenObjects()
		{
			ScreenViewModelBase.StandardAdvance = this.ExecuteAdvanceScreen;
			ScreenViewModelBase.StandardRetreat = this.ExecuteRetreatScreen;

			var screens = new List<ScreenViewModelBase>();

			// Screens are assigned added to the list in the order they will appear in the program. ALWAYS
			// increment screenCount before initing a new ScreenViewModelBase object. 

			SelectActiveStaffMembersAndCabins = SelectActiveStaffMembersAndCabinsViewModel.Instance;
			SelectActiveStaffMembersAndCabins.ScreenNumber = screens.Count();
			screens.Add(SelectActiveStaffMembersAndCabins);

			SetCabinSchedules = SetCabinSchedulesViewModel.Instance;
			SetCabinSchedules.ScreenNumber = screens.Count();
			screens.Add(SetCabinSchedules);

			ReviewSelectedStaffAndCabins = ReviewSelectedStaffAndCabinsViewModel.Instance;
			ReviewSelectedStaffAndCabins.ScreenNumber = screens.Count();
			screens.Add(ReviewSelectedStaffAndCabins);

			AssignStaffToCabinsAndPStaff = AssignStaffToCabinsAndPStaffViewModel.Instance;
			AssignStaffToCabinsAndPStaff.ScreenNumber = screens.Count();
			screens.Add(AssignStaffToCabinsAndPStaff);

			ProgramAreaSettings = ProgramAreaSettingsViewModel.Instance;
			ProgramAreaSettings.ScreenNumber = screens.Count();
			screens.Add(ProgramAreaSettings);

			GenerationSettings = GenerationSettingsViewModel.Instance;
			GenerationSettings.ScreenNumber = screens.Count();
			screens.Add(GenerationSettings);

			SetMiscAssignments = SetMiscAssignmentsViewModel.Instance;
			SetMiscAssignments.ScreenNumber = screens.Count();
			screens.Add(SetMiscAssignments);

			return screens;
		}

		private void ExecuteAdvanceScreen(object obj)
		{
			++CurrentTab;
		}

		private void ExecuteRetreatScreen(object obj)
		{
			--CurrentTab;
		}

		private SelectActiveStaffMembersAndCabinsViewModel _selectActiveStaffMembersAndCabins;
		public SelectActiveStaffMembersAndCabinsViewModel SelectActiveStaffMembersAndCabins
		{
			get => _selectActiveStaffMembersAndCabins;
			set
			{
				_selectActiveStaffMembersAndCabins = value;
				RaisePropertyChanged();
			}
		}

		private SetCabinSchedulesViewModel _setCabinSchedules;
		public SetCabinSchedulesViewModel SetCabinSchedules
		{
			get => _setCabinSchedules;
			set
			{
				_setCabinSchedules = value;
				RaisePropertyChanged();
			}
		}

		private ReviewSelectedStaffAndCabinsViewModel _reviewSelectedStaffAndCabins;
		public ReviewSelectedStaffAndCabinsViewModel ReviewSelectedStaffAndCabins
		{
			get => _reviewSelectedStaffAndCabins;
			set
			{
				_reviewSelectedStaffAndCabins = value;
				RaisePropertyChanged();
			}
		}

		private AssignStaffToCabinsAndPStaffViewModel _assignStaffToCabinsAndPStaff;
		public AssignStaffToCabinsAndPStaffViewModel AssignStaffToCabinsAndPStaff
		{
			get => _assignStaffToCabinsAndPStaff;
			set
			{
				_assignStaffToCabinsAndPStaff = value;
				RaisePropertyChanged();
			}
		}

		private ProgramAreaSettingsViewModel _programAreaSettings;
		public ProgramAreaSettingsViewModel ProgramAreaSettings
		{
			get => _programAreaSettings;
			set
			{
				_programAreaSettings = value;
				RaisePropertyChanged();
			}
		}

		private GenerationSettingsViewModel _generationSettings;
		public GenerationSettingsViewModel GenerationSettings
		{
			get => _generationSettings;
			set
			{
				_generationSettings = value;
				RaisePropertyChanged();
			}
		}

		private SetMiscAssignmentsViewModel _setMiscAssignments;
		public SetMiscAssignmentsViewModel SetMiscAssignments
		{
			get => _setMiscAssignments;
			set
			{
				_setMiscAssignments = value;
				RaisePropertyChanged();
			}
		}

		private List<ScreenViewModelBase> _screenObjects = null;

		private void InitDataFromDb()
		{
			//var program = new ObservableCollection<LocationViewModel>();
			//foreach (var area in DataHandler.GetProgramAreas())
			//{
			//	program.Add(new LocationViewModel(area));
			//}
			//ProgramAreas = program;

			//var work = new ObservableCollection<string> { "None" };

			//foreach (var area in DataHandler.GetWorkAreas())
			//{
			//	work.Add(area.Name);
			//}
			//WorkAreaTexts = work;
		}

		private ObservableCollection<CabinViewModel> _cabins;
		public ObservableCollection<CabinViewModel> Cabins
		{
			get => _cabins;
			set
			{
				_cabins = value;
				RaisePropertyChanged();
			}
		}

		private ObservableCollection<StaffMemberViewModel> _staffMembers;
		public ObservableCollection<StaffMemberViewModel> StaffMembers
		{
			get => _staffMembers;
			set
			{
				_staffMembers = value;
				RaisePropertyChanged();
			}
		}

		public ObservableCollection<StaffMemberViewModel> ActiveStaffMembers
		{
			get
			{
				return new ObservableCollection<StaffMemberViewModel>(StaffMembers.Where(s => s.IsSelected));
			}
		}

		// ====================================================================================================================================
		// REMOVE BELOW THIS LINE
		// ====================================================================================================================================

		//private void InitDefaultUIValues()
		//{
		//	AssignHalfOff = true;
		//	TakePreferencesIntoAccount = true;
		//	NumberOnDishes = "4";
		//	NumberOnCampfire = "4";
		//	NumberOnQuietCabin = "2";
		//	StaffTypeOnEveningDishes = "P-Staff";
		//	ProgressText = "Not Started";
		//}

		//private void InitDelegateCommands()
		//{


		//	GetTotals = new DelegateCommand(ExecuteGetTotals);
		//}

		//#region Select staff members and cabins

		//#region Edit existing staff

		//private DelegateCommand staffEditExisting;
		//public DelegateCommand StaffEditExisting
		//{
		//	get
		//	{
		//		return staffEditExisting;
		//	}
		//	set
		//	{
		//		staffEditExisting = value;
		//		RaisePropertyChanged();
		//	}
		//}

		////private void EditSelectedStaff(object obj)
		////{
		////	AddEditStaff aes = new AddEditStaff(obj as StaffMemberViewModel);
		////	aes.ShowDialog();
		////	if (aes.SaveStaff)
		////	{
		////		DataHandler.UpdateStaffMember(aes.Staff);
		////		SelectedStaffMember.Update();
		////	}


		////}

		////private bool EditSelectedStaffEnabled(object obj)
		////{
		////	return obj as StaffMemberViewModel != null;
		////}

		//#endregion Edit existing staff

		//#region Create new staff



		////private DelegateCommand staffCreateNew;

		////public DelegateCommand StaffCreateNew
		////{
		////    get
		////    {
		////        return staffCreateNew;
		////    }
		////    set
		////    {
		////        staffCreateNew = value;
		////        RaisePropertyChanged();
		////    }
		////}

		//#endregion Create new staff

		//#region Delete staff

		////     private void DeleteSelected(object obj)
		////     {
		////         StaffMembers.Remove((obj as StaffMemberViewModel));
		////DataHandler.DeleteStaff(obj as StaffMemberViewModel);
		////     }

		////     private bool DeleteSelectedEnabled(object obj)
		////     {
		////         //return EditSelectedStaffEnabled(obj);
		////         return false;
		////     }

		////     private DelegateCommand staffDeleteSelected;

		////     public DelegateCommand StaffDeleteSelected
		////     {
		////         get
		////         {
		////             return staffDeleteSelected;
		////         }
		////         set
		////         {
		////             staffDeleteSelected = value;
		////             RaisePropertyChanged();
		////         }
		////     }

		//#endregion Delete staff

		//#region Select all staff

		////private DelegateCommand staffSelectAll;

		////public DelegateCommand StaffSelectAll
		////{
		////	get
		////	{
		////		return staffSelectAll;
		////	}
		////	set
		////	{
		////		staffSelectAll = value;
		////		RaisePropertyChanged();
		////	}
		////}

		////private void ExecuteStaffSelectAll(object obj)
		////{
		////	foreach(var member in StaffMembers)
		////	{
		////		member.IsSelected = true;
		////	}
		////}

		//#endregion Select all staff

		//#region Select no staff

		////private DelegateCommand staffSelectNone;

		////public DelegateCommand StaffSelectNone
		////{
		////	get
		////	{
		////		return staffSelectNone;
		////	}
		////	set
		////	{
		////		staffSelectNone = value;
		////	}
		////}
		////private void ExecuteStaffSelectNone(object obj)
		////{
		////	foreach(var member in StaffMembers)
		////	{
		////		member.IsSelected = false;
		////	}
		////}

		//#endregion Staff no staff

		//#region Select first staff

		////private DelegateCommand staffGoToFirst;

		////public DelegateCommand StaffGoToFirst
		////{
		////	get
		////	{
		////		return staffGoToFirst;
		////	}
		////	set
		////	{
		////		staffGoToFirst = value;
		////		RaisePropertyChanged();
		////	}
		////}

		////private void ExecuteStaffGoToFirst(object obj)
		////{
		////	SelectedStaffMember = StaffMembers.First();
		////}

		//#endregion Select first staff

		//#region select last staff

		////private DelegateCommand staffGoToLast;

		////public DelegateCommand StaffGoToLast
		////{
		////	get
		////	{
		////		return staffGoToLast;
		////	}
		////	set
		////	{
		////		staffGoToLast = value;
		////		RaisePropertyChanged();
		////	}
		////}

		////private void ExecuteStaffGoToLast(object obj)
		////{
		////	SelectedStaffMember = StaffMembers.Last();
		////}

		//#endregion select last staff

		//#region Search staff

		////private string staffSearchText;

		////      public string StaffSearchText
		////      {
		////          get
		////          {
		////              return staffSearchText;
		////          }
		////          set
		////          {
		////              staffSearchText = value;
		////		RaisePropertyChanged();
		////          }
		////      }

		//#endregion Search staff

		////private ObservableCollection<StaffMemberViewModel> _staffMembers;

		////      public ObservableCollection<StaffMemberViewModel> StaffMembers
		////      {
		////          get
		////          {
		////              return _staffMembers;
		////          }
		////          set
		////          {
		////              _staffMembers = value;
		////              RaisePropertyChanged();
		////		RaisePropertyChanged(nameof(ActiveStaffMembers));
		////          }
		////      }

		//#region Selected staff

		////private StaffMemberViewModel selectedStaffMember;

		////public StaffMemberViewModel SelectedStaffMember
		////{
		////    get
		////    {
		////        return selectedStaffMember;
		////    }
		////    set
		////    {
		////        selectedStaffMember = value;
		////        RaisePropertyChanged();
		////        StaffEditExisting.RaiseCanExecuteChanged();

		////    }
		////}
		//#endregion Selected staff

		//#endregion Select staff members and cabins

		//#region Set cabins and program directors



		//#endregion Set cabns and program directors

		//#region Advance stage

		//private void AdvanceToSetCabinsAndPStaff(object obj)
		//{
		//	AdvanceStage = new DelegateCommand(AdvanceToProgramAreaSettings);
		//	RaisePropertyChanged(nameof(ActiveStaffMembers));
		//	RaisePropertyChanged(nameof(ActiveCabins));
		//	CurrentTab = 1;
		//}

		//private void AdvanceToProgramAreaSettings(object obj)
		//{
		//	SetUpOvernightAssignments();
		//	foreach (var member in ActiveStaffMembers)
		//	{
		//		foreach (var location in ProgramAreas)
		//		{
		//			// TODO: Update this to not rely on text.
		//			if (member.AssignedProgramAreaText == location.Name)
		//			{
		//				location.PStaffMembers.Add(member.WrappedStaffMember);
		//			}
		//		}
		//	}
		//	AdvanceStage = new DelegateCommand(AdvanceToEveningJobAssignment);
		//	CurrentTab = 2;
		//}

		//private void SetUpOvernightAssignments()
		//{
		//	foreach (var staff in ActiveStaffMembers)
		//	{
		//		if (!staff.WrappedStaffMember.HasCabin() || !staff.AssignedCabin.HasOvernight())
		//			break;

		//		int overnightNight = staff.AssignedCabin.Schedule.Overnight;
		//		StaffMember member = staff.WrappedStaffMember;
		//		member.AfternoonAssignment[overnightNight, 0] = EveningJob.Overnight.ToString();
		//		member.AfternoonAssignment[overnightNight, 1] = EveningJob.Overnight.ToString();

		//		member.EveningActivities[overnightNight] = EveningJob.Overnight;
		//	}
		//}

		//private void AdvanceToEveningJobAssignment(object obj)
		//{
		//	AdvanceStage = new DelegateCommand(AdvanceToGenerationScreen);
		//	CurrentTab = 3;
		//}
		//private void AdvanceToGenerationScreen(object obj)
		//{
		//	AdvanceStage = new DelegateCommand(AdvanceToGenerationScreen, AdvanceEnabled);
		//	CurrentTab = 4;
		//}

		//private bool AdvanceEnabled(object obj)
		//{
		//	return false;
		//}

		//#endregion Advance stage

		//#region Program Area And Generation Settings

		//private DelegateCommand getTotals;
		//public DelegateCommand GetTotals
		//{
		//	get
		//	{
		//		return getTotals;
		//	}
		//	set
		//	{
		//		getTotals = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//private void ExecuteGetTotals(object obj)
		//{
		//	RaisePropertyChanged(nameof(AssignedPStaffCount));
		//	RaisePropertyChanged(nameof(NonPStaffCount));
		//	RaisePropertyChanged(nameof(TotalMinimum));
		//	RaisePropertyChanged(nameof(TotalMaximum));
		//	RaisePropertyChanged(nameof(TotalTarget));
		//}

		//public string AssignedPStaffCount
		//{
		//	get
		//	{
		//		return GetAssignedPStaffCount().ToString();
		//	}
		//}
		//private int GetAssignedPStaffCount()
		//{
		//	int val = 0;
		//	foreach (var location in ProgramAreas)
		//	{
		//		val += location.PStaffMembers.Count();
		//	}
		//	return val;
		//}
		//public string NonPStaffCount
		//{
		//	get
		//	{
		//		return (ActiveStaffMembers.Count() - GetAssignedPStaffCount()).ToString();
		//	}
		//}

		//public string TotalMinimum
		//{
		//	get
		//	{
		//		return GetTotalMinimum().ToString();
		//	}
		//}

		//public string TotalMaximum
		//{
		//	get
		//	{
		//		return GetTotalMaximum().ToString();
		//	}
		//}

		//public string TotalTarget
		//{
		//	get
		//	{
		//		return GetTotalTarget().ToString();
		//	}
		//}

		//private int GetTotalMinimum()
		//{
		//	int val = 0;
		//	foreach (var location in ProgramAreas)
		//	{
		//		val += Convert.ToInt32(location.MinimumStaff);
		//	}
		//	return val;
		//}

		//private int GetTotalMaximum()
		//{
		//	int val = 0;
		//	foreach (var location in ProgramAreas)
		//	{
		//		val += Convert.ToInt32(location.MaximumStaff);
		//	}
		//	return val;
		//}

		//private int GetTotalTarget()
		//{
		//	int val = 0;
		//	foreach (var location in ProgramAreas)
		//	{
		//		val += Convert.ToInt32(location.TargetStaff);
		//	}
		//	return val;
		//}

		//private int numberOnDishes;
		//public string NumberOnDishes
		//{
		//	get
		//	{
		//		return numberOnDishes.ToString();
		//	}
		//	set
		//	{
		//		int val = numberOnDishes;
		//		Int32.TryParse(value, out val);
		//		numberOnDishes = val;
		//		RaisePropertyChanged();
		//	}
		//}

		//private int numberOnCampfire;
		//public string NumberOnCampfire
		//{
		//	get
		//	{
		//		return numberOnCampfire.ToString();
		//	}
		//	set
		//	{
		//		int val = numberOnCampfire;
		//		Int32.TryParse(value, out val);
		//		numberOnCampfire = val;
		//		RaisePropertyChanged();
		//	}
		//}

		//private int numberOnQuietCabin;
		//public string NumberOnQuietCabin
		//{
		//	get
		//	{
		//		return numberOnQuietCabin.ToString();
		//	}
		//	set
		//	{
		//		int val = numberOnQuietCabin;
		//		Int32.TryParse(value, out val);
		//		numberOnQuietCabin = val;
		//		RaisePropertyChanged();
		//	}
		//}

		//public List<string> StaffTypes
		//{
		//	get
		//	{
		//		List<string> returnValue = new List<string> { "P-Staff", "Counselors", "Both" };
		//		return returnValue;
		//	}
		//}

		//private string staffTypeOnEveningDishes;
		//public string StaffTypeOnEveningDishes
		//{
		//	get
		//	{
		//		return staffTypeOnEveningDishes;
		//	}
		//	set
		//	{
		//		staffTypeOnEveningDishes = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//private bool assignHalfOff;
		//public bool AssignHalfOff
		//{
		//	get
		//	{
		//		return assignHalfOff;
		//	}
		//	set
		//	{
		//		assignHalfOff = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//private bool takePreferencesIntoAccount;
		//public bool TakePreferencesIntoAccount
		//{
		//	get
		//	{
		//		return takePreferencesIntoAccount;
		//	}
		//	set
		//	{
		//		takePreferencesIntoAccount = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//#endregion Program Area And Generation Settings

		//#region Generation

		//private DelegateCommand generateOutput;

		//public DelegateCommand GenerateOutput
		//{
		//	get
		//	{
		//		return generateOutput;
		//	}
		//	set
		//	{
		//		generateOutput = value;
		//		RaisePropertyChanged();
		//	}
		//}
		//private void ExecuteGenerateOutput(object obj)
		//{
		//	ProgressText = "Starting Generation";
		//	//SpreadSheetMaker.SpreadSheetMaker output = new SpreadSheetMaker.SpreadSheetMaker();

		//}

		//#endregion Generation

		//public ObservableCollection<Cabin> ActiveCabins
		//{
		//	get
		//	{
		//		var collection = new ObservableCollection<Cabin>
		//		{
		//			Cabin.NoCabin,
		//		};
		//		foreach (var item in Cabins.Where(c => c.IsSelected).Select(x => x.WrappedCabin))
		//		{
		//			collection.Add(item);
		//		}
		//		return collection;
		//	}
		//}

		//private ObservableCollection<string> workAreaTexts;

		//public ObservableCollection<string> WorkAreaTexts
		//{
		//	get
		//	{
		//		return workAreaTexts;
		//	}
		//	set
		//	{
		//		workAreaTexts = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//private ObservableCollection<LocationViewModel> programAreas;

		//public ObservableCollection<LocationViewModel> ProgramAreas
		//{
		//	get
		//	{
		//		return programAreas;
		//	}
		//	set
		//	{
		//		programAreas = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//public IEnumerable<CabinSchedule> CabinSchedules
		//{
		//	get
		//	{
		//		if (_cabinSchedules == null)
		//		{
		//			_cabinSchedules = DataHandler.GetCabinSchedules();
		//		}
		//		return _cabinSchedules;
		//	}
		//}

		//private IEnumerable<CabinSchedule> _cabinSchedules = null;

		//private int progress = 0;
		//public int Progress
		//{
		//	get
		//	{
		//		return progress;
		//	}
		//	set
		//	{
		//		progress = value;
		//		RaisePropertyChanged();
		//	}
		//}

		//private string progressText;
		//public string ProgressText
		//{
		//	get
		//	{
		//		return progressText;
		//	}
		//	set
		//	{
		//		progressText = value;
		//		RaisePropertyChanged();
		//	}
		//}
	}
}
