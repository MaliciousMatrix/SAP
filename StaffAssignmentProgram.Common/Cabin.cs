using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class Cabin
	{
		public Cabin(int idNumber, string name, string loop, int cabinScheduleId, bool defaultSelected)
		{
			Id = idNumber;
			Name = name;
			CabinScheduleId = cabinScheduleId;
			Loop = loop;
			DefaultSelected = defaultSelected;
		}

		public string Name { get; set; }
		public string Loop { get; set; }
		public int Id { get; private set; }
		public int CabinScheduleId { get; set; }
		public bool DefaultSelected { get; set; }

		public CabinSchedule Schedule { get; set; }

		public bool HasSchedule()
		{
			return Schedule != null;
		}

		public bool HasOvernight()
		{
			return HasSchedule() && Schedule.Overnight > -1;
		}

		public bool Equals(Cabin c)
		{
			return c.Name == this.Name && c.Loop == this.Loop && c.Id == this.Id && c.CabinScheduleId == this.CabinScheduleId;
		}


		public static Cabin NoCabin = new Cabin(-1, "None", "", -1, false);
	}
}
