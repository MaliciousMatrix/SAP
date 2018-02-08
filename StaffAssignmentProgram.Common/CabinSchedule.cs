using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class CabinSchedule
	{
		public CabinSchedule(int id, string name, string[,] morningSchedule, int overNight = -1)
		{
			Id = id;
			MorningSchedule = morningSchedule;
			Overnight = overNight;
			Name = name;
		}
		public int Id { get; private set; }
		public string Name { get; set; }
		public string[,] MorningSchedule { get; set; }
		public int Overnight { get; set; }

		public string OvernightString
		{
			get
			{
				if (Overnight > 0 && Overnight < 4)
					return ((DayOfWeek)Overnight).ToString();
				return "None";
			}
		}
	}
}
