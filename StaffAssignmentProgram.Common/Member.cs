using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public abstract class Member : IMember
	{
		protected static readonly int noneMemberId = -1;
		protected static readonly int randomMemberId = -2;

		public int IdNumber { get; protected set; }

		public abstract string Name { get; }

		private List<Activity> _activities;
		public IEnumerable<Activity> Activities
		{
			get => _activities;
		}

		public bool IsRealMember()
		{
			return IdNumber >= 0;
		}

		/// <summary>
		/// Adds an activity to the assigned activities in this member. If the member already contains that exact activity then
		/// The activity is not added and false is returned. True otherwise. 
		/// </summary>
		public bool AssignActivity(Activity activity)
		{
			if(_activities == null)
			{
				_activities = new List<Activity>();
			}

			if (_activities.Contains(activity))
				return false;

			_activities.Add(activity);
			return true;
		}
	}
}
