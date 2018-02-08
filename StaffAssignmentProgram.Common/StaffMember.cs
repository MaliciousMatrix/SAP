using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class StaffMember
	{
		public StaffMember(string fullName, int idNumber, DateTime birthday, string phoneNumber, string email, List<Preference> preferences, string nickName = "")
		{
			FullName = fullName;
			IdNumber = idNumber;
			Birthday = birthday;
			NickName = nickName;
			PhoneNumber = phoneNumber;
			Email = email;
			InitAfternoonAssignment();
			Preferences = preferences;
		}

        private StaffMember(string name)
        {
            FullName = name;
            name = null;
            IdNumber = -1;
        }

		public string Name
		{
			get
			{
				return String.IsNullOrWhiteSpace(NickName) ? FullName : NickName;
			}
		}

		public int IdNumber { get; set; }

		public string FullName { get; set; }
		public string NickName { get; set; }

		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime Birthday { get; set; }
		public string[,] AfternoonAssignment { get; set; }
		public Cabin AssignedCabin { get; set; } = Cabin.NoCabin;
		public Location PStaffAssignment { get; set; } = Location.None;
		public List<Preference> Preferences { get; set; }
		public List<Activity> Activities { get; set; }

		public bool IsEighteen
		{
			get
			{
				return CurrentAge >= 18;
			}
		}

		private void InitAfternoonAssignment()
		{
			AfternoonAssignment = new string[5, 2];
			SetAllAfternoonAssignments(String.Empty);
		}

		public void SetAllAfternoonAssignments(string value)
		{
			for (int i = 0; i < 5; i++)
			{
				AfternoonAssignment[i, 0] = value;
				AfternoonAssignment[i, 1] = value;
			}
		}

		public int CurrentAge
		{
			get
			{
				DateTime today = DateTime.Today;
				int age = today.Year - Birthday.Year;

				if (Birthday > today.AddYears(-age))
					age--;
				return age;
			}
		}

		public bool HasCabin()
		{
			return AssignedCabin != null && !AssignedCabin.Equals(Cabin.NoCabin);
		}
        
        public static StaffMember None = new StaffMember("None");
        public static StaffMember Random = new StaffMember("Random");
	}
}
