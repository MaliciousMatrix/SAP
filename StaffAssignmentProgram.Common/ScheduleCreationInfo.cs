using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class ScheduleCreationInfo
	{
		public IEnumerable<StaffMember> ActiveStaffMembers { get; set; }
		public IEnumerable<Cabin> ActiveCabins { get; set; }
		public IEnumerable<Location> ActiveWorkAreas { get; set; }

		public int[] NumberOnCampfire { get; set; }
		public int[] NumberOnQuiteCabin { get; set; }
		public int[,] NumberOnDishes { get; set; }

		public int NumberOnTradingPost { get; set; } = 2;
		public int NumberOnPowerUp { get; set; } = 2;
	}
}
