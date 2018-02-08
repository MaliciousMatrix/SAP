using SAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator
{
	public class CabinViewModel : ViewModelBase, ISelectable
	{
		public CabinViewModel(Cabin cabin)
		{
			WrappedCabin = cabin;
			IsSelected = cabin.DefaultSelected;
			RaisePropertyChanged(nameof(WrappedCabin));
			RaisePropertyChanged(nameof(SelectedSchedule));
		}

		private Cabin wrappedCabin;
		public Cabin WrappedCabin
		{
			get
			{
				return wrappedCabin;
			}
			set
			{
				wrappedCabin = value;
				RaisePropertyChanged();
			}
		}

		public string Name
		{
			get
			{
				return WrappedCabin.Name;
			}
			set
			{
				WrappedCabin.Name = value;
				RaisePropertyChanged();
			}
		}

		public int IdNumber
		{
			get
			{
				return WrappedCabin.Id;
			}
		}

		public string Loop
		{
			get
			{
				return WrappedCabin.Loop;
			}
			set
			{
				WrappedCabin.Loop = value;
				RaisePropertyChanged();
			}
		}

		public CabinSchedule SelectedSchedule
		{
			get => WrappedCabin.Schedule;
			set
			{
				WrappedCabin.Schedule = value;
				RaisePropertyChanged();
			}
		}

		private bool isSelected;
		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				isSelected = value;
				RaisePropertyChanged();
			}
		}

		public void UpdateExposedISelectableMembers()
		{
			throw new NotImplementedException();
		}
	}
}
