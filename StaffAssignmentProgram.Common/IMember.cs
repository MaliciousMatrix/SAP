using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public interface IMember
	{
		string Name { get; }
		int IdNumber { get; }
		bool IsRealMember();
	}
}
