using SAP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator.MainWindowUserControls.ProgramAreaSettings
{
	public class LocationViewModel : ViewModelBase
	{
		public LocationViewModel(Location wrappedLocation)
		{
			WrappedLocation = wrappedLocation;
		}

		private Location wrappedLocation;
		public Location WrappedLocation
		{
			get
			{
				return wrappedLocation;
			}
			set
			{
				wrappedLocation = value;
				RaisePropertyChanged();
			}
		}

		public int IdNumber
		{
			get
			{
				return WrappedLocation.IdNumber;
			}
		}

		public string Name
		{
			get
			{
				return WrappedLocation.Name;
			}
			set
			{
				WrappedLocation.Name = value;
				RaisePropertyChanged();
			}
		}

		public string MinimumStaff
		{
			get
			{
				return WrappedLocation.MinimumStaff.ToString(); ;
			}
			set
			{
				int val = WrappedLocation.MinimumStaff;
				Int32.TryParse(value, out val);
				WrappedLocation.MinimumStaff = val;
				RaisePropertyChanged();
			}
		}

		public string MaximumStaff
		{
			get
			{
				return WrappedLocation.MaximumStaff.ToString(); ;
			}
			set
			{
				int val = WrappedLocation.MaximumStaff;
				Int32.TryParse(value, out val);
				WrappedLocation.MaximumStaff = val;
				RaisePropertyChanged();
				RaisePropertyChanged(nameof(GetAssignedStaffAsString));
			}
		}

		public string TargetStaffPercent
		{
			get
			{
				return WrappedLocation.TargetStaffPercent.ToString(); ;
			}
			set
			{
				int val = WrappedLocation.TargetStaffPercent;
				Int32.TryParse(value, out val);
				WrappedLocation.TargetStaffPercent = val;
				RaisePropertyChanged();
				Advance?.RaiseCanExecuteChanged();
			}
		}

		private List<string> _assignedStaffNames;
		public List<string> AssignedStaffnames
		{
			get => _assignedStaffNames;
			set
			{
				_assignedStaffNames = value;
				RaisePropertyChanged();
			}
		}

		public string GetAssignedStaffAsString
		{
			get
			{
				if (AssignedStaffnames == null)
					return String.Empty;
				StringBuilder sb = new StringBuilder();
				foreach(var name in AssignedStaffnames)
				{
					sb.Append(name);
					if (name != AssignedStaffnames.Last())
						sb.Append(", ");
				}
				return sb.ToString();
			}
		}

		public static DelegateCommand Advance { get; set; }
	}
}
