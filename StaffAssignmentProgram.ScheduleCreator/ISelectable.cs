using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.ScheduleCreator
{
	public interface ISelectable
	{
		string Name { get; }
		int IdNumber { get; }
		bool IsSelected { get; set; }
		void UpdateExposedISelectableMembers();
	}
}
