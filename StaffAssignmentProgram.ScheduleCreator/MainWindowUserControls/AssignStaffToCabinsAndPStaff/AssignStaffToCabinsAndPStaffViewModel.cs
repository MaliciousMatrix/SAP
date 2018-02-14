using SAP.Common;
using SAP.DataBaseHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.AssignStaffToCabinsAndPStaff
{
	public class AssignStaffToCabinsAndPStaffViewModel : ScreenViewModelBase
	{
		private static AssignStaffToCabinsAndPStaffViewModel instance;
		public static AssignStaffToCabinsAndPStaffViewModel Instance
		{
			get
			{
				if (instance == null)
					instance = new AssignStaffToCabinsAndPStaffViewModel();
				return instance;
			}
		}

		private AssignStaffToCabinsAndPStaffViewModel()
		{
			name = "Assign Staff to Cabins and P-Staff";
			Init();
		}

		public override void Initialize(ScheduleCreationInfo scheduleCreationInfo)
		{
            base.Initialize(scheduleCreationInfo);
			_activeStaffMembers = scheduleCreationInfo.ActiveStaffMembers.ToObservableCollection();
			_activeCabins = scheduleCreationInfo.ActiveCabins.ToObservableCollection();

			_activeCabins.Insert(0, Cabin.NoCabin);

			_activeWorkAreas = DataBaseAccess.GetWorkAreas().ToObservableCollection();
			_activeWorkAreas.Insert(0, Location.None);

			RaisePropertyChanged(nameof(ActiveStaffMembers));
			RaisePropertyChanged(nameof(ActiveCabins));
			RaisePropertyChanged(nameof(ActiveWorkAreas));
		}

		public override void Resolve()
		{
			scheduleCreationInfo.ActiveWorkAreas = ActiveWorkAreas;
		}

		private ObservableCollection<StaffMember> _activeStaffMembers;
		public ObservableCollection<StaffMember> ActiveStaffMembers
		{
			get => _activeStaffMembers;
		}

		private ObservableCollection<Cabin> _activeCabins;
		public ObservableCollection<Cabin> ActiveCabins
		{
			get => _activeCabins;
		}

		private ObservableCollection<Location> _activeWorkAreas;
		public ObservableCollection<Location> ActiveWorkAreas
		{
			get => _activeWorkAreas;
		}
	}
}
