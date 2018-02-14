using SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.SelectActiveMembers;
using SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins.AddEditStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.Common;
using System.Collections.ObjectModel;
using SAP.DataBaseHandler;

namespace SAP.ScheduleCreator.MainWindowUserControls.SelectActiveStaffMembersAndCabins
{
	public class SelectActiveStaffMembersAndCabinsViewModel : ScreenViewModelBase
	{
		private static SelectActiveStaffMembersAndCabinsViewModel instance;
		public static SelectActiveStaffMembersAndCabinsViewModel Instance
		{
			get
			{
				if (instance == null)
					instance = new SelectActiveStaffMembersAndCabinsViewModel();
				return instance;
			}
		}
		private SelectActiveStaffMembersAndCabinsViewModel()
		{
			name = "Select Active Staff and Cabins";
			Init();
		}

		public override void Initialize(ScheduleCreationInfo scheduleCreationInfo)
		{
			base.Initialize(scheduleCreationInfo);

			StaffMembers = new ObservableCollection<StaffMemberViewModel>();
			var members = DataBaseAccess.GetStaffMembers();
			foreach (var staff in members)
			{
				StaffMembers.Add(new StaffMemberViewModel(staff));
			}

			Cabins = new ObservableCollection<CabinViewModel>();
			foreach (var cabin in DataBaseAccess.GetCabins())
			{
				Cabins.Add(new CabinViewModel(cabin));
			}

			SelectActiveStaffMembers =
				new SelectActiveMembersViewModel<StaffMemberViewModel>(
					"Staff Members",
					StaffMembers,
					DeleteStaffMember,
					CreateNewStaffMember,
					EditStaffMember
					);

			SelectActiveCabins =
				new SelectActiveMembersViewModel<CabinViewModel>(
					"Cabins",
					Cabins,
					DeleteCabin,
					CreateNewCabin,
					EditCabin
					);
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

		public override void Resolve()
		{
			scheduleCreationInfo.ActiveStaffMembers = StaffMembers.Where(x => x.IsSelected).Select(x => x.WrappedStaffMember);
			scheduleCreationInfo.ActiveCabins = Cabins.Where(x => x.IsSelected).Select(x => x.WrappedCabin);
		}

		private SelectActiveMembersViewModel<StaffMemberViewModel> _selectActiveStaffMembers;
		public SelectActiveMembersViewModel<StaffMemberViewModel> SelectActiveStaffMembers
		{
			get => _selectActiveStaffMembers;
			set
			{
				_selectActiveStaffMembers = value;
				RaisePropertyChanged();
			}
		}

		private SelectActiveMembersViewModel<CabinViewModel> _selectActiveCabins;
		public SelectActiveMembersViewModel<CabinViewModel> SelectActiveCabins
		{
			get => _selectActiveCabins;
			set
			{
				_selectActiveCabins = value;
				RaisePropertyChanged();
			}
		}


		#region Staff CUD Methods

		private StaffMemberViewModel CreateNewStaffMember()
		{
			AddEditStaff.AddEditStaff aes = new AddEditStaff.AddEditStaff(DataBaseAccess.GetStaffPreferences(-1));
			aes.ShowDialog();
			if (aes.SaveStaff)
			{
				DataBaseAccess.AddNewStaff(aes.Staff.WrappedStaffMember);
				return aes.Staff;
			}

			return null;
		}

		private StaffMemberViewModel EditStaffMember(StaffMemberViewModel staffMember)
		{
			AddEditStaff.AddEditStaff aes = new AddEditStaff.AddEditStaff(staffMember);
			aes.ShowDialog();
			if (aes.SaveStaff)
			{
				DataBaseAccess.UpdateStaffMember(aes.Staff.WrappedStaffMember);
				return aes.Staff;
			}
			return null;
		}

		private void DeleteStaffMember(StaffMemberViewModel staffMember)
		{
			DataBaseAccess.DeleteStaff(staffMember.WrappedStaffMember);
		}

		#endregion Staff CUD Methods

		#region Cabin CUD Methods

		private void DeleteCabin(CabinViewModel cabin)
		{

		}

		private CabinViewModel CreateNewCabin()
		{
			return null;
		}

		private CabinViewModel EditCabin(CabinViewModel cabin)
		{
			return null;
		}

		#endregion Cabin CUD Methods

		protected override bool CanExecuteRetreat(object obj)
		{
			// This is the first screen. It should never ever 'go back'
			return false;
		}

	}
}
