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

		public int[] NumberOnTradingPost { get; set; } 
		public int[] NumberOnPowerUp { get; set; } 

		public int[] NumberOnFlagLowering { get; set; } 
		public int[] NumberOnFlagRaising { get; set; }

		public int[] NumberOnGrace { get; set; }
	}
}
