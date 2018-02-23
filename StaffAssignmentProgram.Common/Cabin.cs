using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class Cabin : Member
	{
		public Cabin(int idNumber, string name, string loop, int cabinScheduleId, bool defaultSelected)
		{
			IdNumber = idNumber;
			_name = name;
			CabinScheduleId = cabinScheduleId;
			Loop = loop;
			DefaultSelected = defaultSelected;
		}

		private Cabin(string name, int id)
		{
			IdNumber = id;
			_name = name;
			
		}

		private string _name;
		public override string Name
		{
			get => _name;
		}

		public bool SetName(string name)
		{
			if (String.IsNullOrWhiteSpace(name))
				return false;

			_name = name;
			return true;
		}

		public string Loop { get; set; }
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

		public static Cabin None = new Cabin("None", noneMemberId);
		public static Cabin Random = new Cabin("Random", randomMemberId);

		
	}
}
