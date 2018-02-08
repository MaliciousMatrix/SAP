using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class Preference
	{
		public Preference(string programAreaName, int programAreaId, int value = 2)
		{
			ProgramAreaName = programAreaName;
			PreferenceValue = value;
			ProgramAreaId = programAreaId;
		}
		public string ProgramAreaName { get; set; }
		public int PreferenceValue { get; set; }
		public int ProgramAreaId { get; set; }
	}
}
