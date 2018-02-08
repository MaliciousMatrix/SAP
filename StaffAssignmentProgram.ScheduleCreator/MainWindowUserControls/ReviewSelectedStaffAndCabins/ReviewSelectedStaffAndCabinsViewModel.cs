using SAP.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.ReviewSelectedStaffAndCabins
{
	public class ReviewSelectedStaffAndCabinsViewModel : ScreenViewModelBase
	{
		private static ReviewSelectedStaffAndCabinsViewModel _instance;
		public static ReviewSelectedStaffAndCabinsViewModel Instance
		{
			get
			{
				if (_instance == null)
					_instance = new ReviewSelectedStaffAndCabinsViewModel();
				return _instance;
			}
		}
		private ReviewSelectedStaffAndCabinsViewModel()
		{
			ActiveStaffMembers = new ObservableCollection<StaffMemberViewModel>();
			name = "Review Selected Staff and Cabins";
			Init();
		}

		public override void Initialize(ScheduleCreationInfo scheduleCreationInfo)
		{
			ActiveStaffMembers =
				scheduleCreationInfo.ActiveStaffMembers.OrderBy(x => x.Name).ToStaffMemberViewModel();

			ActiveCabins =
				scheduleCreationInfo.ActiveCabins.OrderBy(x => x.Name).ToCabinViewModel();

			RaisePropertyChanged(nameof(ActiveStaffCount));
			RaisePropertyChanged(nameof(ActiveCabinCount));
		}

		public override void Resolve()
		{

		}

		private ObservableCollection<StaffMemberViewModel> _activeStaffMembers;
		public ObservableCollection<StaffMemberViewModel> ActiveStaffMembers
		{
			get => _activeStaffMembers;
			set
			{
				_activeStaffMembers = value;
				RaisePropertyChanged();
			}
		}

		private ObservableCollection<CabinViewModel> _activeCabins;
		public ObservableCollection<CabinViewModel> ActiveCabins
		{
			get => _activeCabins;
			set
			{
				_activeCabins = value;
				RaisePropertyChanged();
			}
		}

		public int ActiveStaffCount
		{
			get
			{
				if (ActiveStaffMembers == null)
					return 0;
				return ActiveStaffMembers.Count();
			}
		}

		public int ActiveCabinCount
		{
			get
			{
				if (ActiveCabins == null)
					return 0;
				return ActiveCabins.Count();
			}
		}
	}
}
