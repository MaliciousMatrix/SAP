using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class Cabin : IMember
	{
		public Cabin(int idNumber, string name, string loop, int cabinScheduleId, bool defaultSelected)
		{
			IdNumber = idNumber;
			Name = name;
			CabinScheduleId = cabinScheduleId;
			Loop = loop;
			DefaultSelected = defaultSelected;
		}

		private Cabin(string name, int id)
		{
			IdNumber = id;
			Name = name;
		}

		public string Name { get; set; }
		public string Loop { get; set; }
		public int IdNumber { get; private set; }
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
			return c.Name == this.Name && c.Loop == this.Loop && c.IdNumber == this.IdNumber && c.CabinScheduleId == this.CabinScheduleId;
		}

		public bool IsRealMember()
		{
			return this.IdNumber >= 0;
		}


		public static Cabin None = new Cabin("None", -1);
		public static Cabin Random = new Cabin("Random", -2);
	}
}
