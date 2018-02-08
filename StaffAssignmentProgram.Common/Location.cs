using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class Location
	{
		public Location(int id, string name, int minimumStaff, int targetStaffPercent, int maximumStaff, 
            bool isProgramArea, bool isCabinActivity, bool isWorkArea, bool isTradingPost)
		{
			IdNumber = id;
			Name = name;
			MinimumStaff = minimumStaff;
			TargetStaffPercent = targetStaffPercent;
			MaximumStaff = maximumStaff;

            IsProgramArea = isProgramArea;
            IsCabinActivity = isCabinActivity;
            IsWorkArea = isWorkArea;
            IsTradingPost = isTradingPost;
		}

		public int IdNumber { get; private set; }
		public string Name { get; set; }
		public int MinimumStaff { get; set; }
		public int TargetStaffPercent { get; set; }
		public int MaximumStaff { get; set; }

        /// <summary>
        /// If true it means that this area needs staff to be randomly assigned to it in the afternoon. If it is 
        /// a program area it should be a work area. 
        /// </summary>
        public bool IsProgramArea { get; set; }

        /// <summary>
        /// If true it means that this location is visited by cabins in the morning and is therefore a part of 
        /// a cabin schedule. 
        /// </summary>
        public bool IsCabinActivity { get; set; }

        /// <summary>
        /// If true it means that this place needs PStaff to be active. It does not necessarily mean that it needs 
        /// staff to be randomly assigned to it in the afternoon. 
        /// </summary>
        public bool IsWorkArea { get; set; }

		public bool IsTradingPost { get; set; }

		public static Location None = new Location(-1, "None", 0, 0, 0, false, false, false, false);

		public bool Equals(Location location)
		{
			// Eh. Good enough. 
			return this.IdNumber == location.IdNumber;
		}
	}
}
