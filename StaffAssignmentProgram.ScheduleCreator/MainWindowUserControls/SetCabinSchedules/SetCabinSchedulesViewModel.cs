using SAP.Common;
using SAP.DataBaseHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.SetCabinSchedules
{
	public class SetCabinSchedulesViewModel : ScreenViewModelBase
	{
		private static SetCabinSchedulesViewModel instance;
		public static SetCabinSchedulesViewModel Instance
		{
			get
			{
				if (instance == null)
					instance = new SetCabinSchedulesViewModel();
				return instance;
			}
		}

		private SetCabinSchedulesViewModel()
		{
			name = "Assign Cabin Schedules";
			Init();
		}

		public override void Initialize(ScheduleCreationInfo scheduleCreationInfo)
		{
			CabinSchedules = new ObservableCollection<CabinSchedule>(DataBaseAccess.GetCabinSchedules());
			ActiveCabins = new ObservableCollection<CabinViewModel>(scheduleCreationInfo.ActiveCabins.Select(x => new CabinViewModel(x)));

			foreach(CabinViewModel cabin in ActiveCabins)
			{
				cabin.SelectedSchedule = CabinSchedules.Where(x => x.Id == cabin.WrappedCabin.CabinScheduleId).FirstOrDefault();
			}
		}

		public override void Resolve()
		{

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

		private ObservableCollection<CabinSchedule> _cabinSchedules;
		public ObservableCollection<CabinSchedule> CabinSchedules
		{
			get => _cabinSchedules;
			set
			{
				_cabinSchedules = value;
				RaisePropertyChanged();
			}
		}
	}
}
