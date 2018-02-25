using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common
{
	public class StaffMember : Member
	{
		public StaffMember(string fullName, int idNumber, DateTime birthday, string phoneNumber, string email, List<Preference> preferences, string nickName = null)
		{
			if (idNumber < 0)
				throw new ArgumentOutOfRangeException("StaffMember idNumber must be an integer greater than zero.");

			if (String.IsNullOrWhiteSpace(fullName))
				throw new ArgumentOutOfRangeException("fullName must have a value other than null or whitespace.");

			FullName = fullName;
			IdNumber = idNumber;
			Birthday = birthday;
			NickName = nickName ?? String.Empty;
			PhoneNumber = phoneNumber;
			Email = email;
			InitAfternoonAssignment();
			Preferences = preferences;
		}

        private StaffMember(string name, int id)
        {
            FullName = name;
            name = null;
			IdNumber = id;
        }

		// Strive to remove this. 
		public bool SetIdNumber(int number)
		{
			if (IdNumber >= 0)
				return false;

			IdNumber = number;
			return true;
		}

		public override string Name
		{
			get
			{
				return String.IsNullOrWhiteSpace(NickName) ? FullName : NickName;
			}
		}

		public string FullName { get; set; }
		public string NickName { get; set; }

		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime Birthday { get; set; }
		public string[,] AfternoonAssignment { get; set; }
		public Cabin AssignedCabin { get; set; } = Cabin.None;
		public Location PStaffAssignment { get; set; } = Location.None;
		public List<Preference> Preferences { get; set; }

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
			return AssignedCabin != null && !AssignedCabin.Equals(Cabin.None);
		}

		public bool Equals(StaffMember staff)
		{
			return this.FullName == staff.FullName && this.NickName == staff.NickName && this.IdNumber == staff.IdNumber;
		}
        
        public static  StaffMember None { get; } = new StaffMember("None", noneMemberId);
        public static  StaffMember Random { get; } = new StaffMember("Random", randomMemberId);
	}
}
