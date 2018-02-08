using SAP.Common;
using SAP.ScheduleCreator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator
{
	public static class ExtensionMethods
	{
		public static ObservableCollection<StaffMemberViewModel> ToStaffMemberViewModel(
			this IEnumerable<StaffMember> staffList)
		{
			return staffList.Select(x => new StaffMemberViewModel(x)).ToObservableCollection();
		}

		public static ObservableCollection<CabinViewModel> ToCabinViewModel( this IEnumerable<Cabin> cabinList)
		{
			return cabinList.Select(x => new CabinViewModel(x)).ToObservableCollection();
		}

		public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
		{
			return new ObservableCollection<T>(list);
		}
	}
}
