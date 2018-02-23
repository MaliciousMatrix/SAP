using SAP.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.SQLite;


namespace SAP.DataBaseHandler
{
	public static class DataBaseAccess
	{
		private static SQLiteConnection dbConnection;
		private static string dbLocation = @"C:\CampProgram\CampDatabase.db";
		public static int myInt = 3;
		private static string connectionString = $"Data Source={dbLocation}; Version=3";
		private static void Open()
		{
			if (!File.Exists(dbLocation))
			{
				throw new Exception("Could not finde CampDataBase.db");
			}
			dbConnection = new SQLiteConnection(connectionString);
			if (dbConnection.State == System.Data.ConnectionState.Open)
			{
				return;
			}
			dbConnection.Open();
		}

		private static void Close()
		{
			dbConnection.Close();
		}

		public static SQLiteDataReader ExecuteQuery(string query)
		{
			try
			{
				Open();
				SQLiteCommand information = new SQLiteCommand(query, dbConnection);
				return information.ExecuteReader();
			}
			finally
			{
				//Close();
			}
		}

		public static void ExecuteNonQuery(string commandText, bool OpenClose = true)
		{
			using (SQLiteConnection c = new SQLiteConnection(connectionString))
			{
				c.Open();
				using (SQLiteCommand cmd = new SQLiteCommand(commandText, c))
				{
					cmd.ExecuteNonQuery();
				}
			}
		}

		public static IEnumerable<StaffMember> GetStaffMembers(string where = "")
		{
			//return new List<StaffMember>();
			string getString = "";
			if (String.IsNullOrEmpty(where))
			{
				getString = "SELECT * FROM StaffMembers ORDER BY id";
			}
			else
			{
				getString = $"SELECT * FROM StaffMembers WHERE name LIKE '%{where}%' ORDER BY id";
			}
			var reader = ExecuteQuery(getString);
			List<StaffMember> returnList = new List<StaffMember>();
			while (reader.Read())
			{
				string fullName = reader["FullName"].ToString();
				int idNumber = Convert.ToInt32(reader["id"]);
				DateTime birthday = Convert.ToDateTime(reader["Birthday"]);
				string phoneNumber = reader["PhoneNumber"].ToString();
				string email = reader["Email"].ToString();
				string nickname = reader["NickName"].ToString();
				List<Preference> preferences = GetStaffPreferences(idNumber);
				returnList.Add(new StaffMember(fullName, idNumber, birthday, phoneNumber, email, preferences, nickname));
			}
			Close();
			return returnList;

		}

		public static void AddNewStaff(StaffMember staffMember)
		{
			string insert = $"INSERT INTO StaffMembers(FullName,NickName,Email,PhoneNumber,Birthday) VALUES('{staffMember.FullName}','{staffMember.NickName}','{staffMember.Email}','{staffMember.PhoneNumber}','{staffMember.Birthday.Date.ToString()}')";
			ExecuteNonQuery(insert);
			string getNewId = $"SELECT MAX(id) FROM StaffMembers";
			var reader = ExecuteQuery(getNewId);
			// There has to be a better way than doing that...
			staffMember.SetIdNumber(Convert.ToInt32(reader.GetValues().GetValues(0).GetValue(0)));
			reader.Close();
			Close();

			// Save preferences
			foreach (var preference in staffMember.Preferences)
			{
				insert = $"INSERT INTO Preferences(StaffMember, ProgramArea, Preference) VALUES " +
						$"('{staffMember.IdNumber}','{preference.ProgramAreaId}','{preference.PreferenceValue}')";
				ExecuteNonQuery(insert);
			}
		}

		public static void DeleteStaff(StaffMember staffMember)
		{
			string delete = $"DELETE FROM StaffMembers WHERE id = '{staffMember.IdNumber}'";
			// TODO: delete preferences
			ExecuteNonQuery(delete);
		}

		public static void UpdateStaffMember(StaffMember staffMember)
		{
			string update = $"UPDATE StaffMembers SET " +
				$"FullName = '{staffMember.FullName}', NickName = '{staffMember.NickName}', Email = '{staffMember.Email}', PhoneNumber = '{staffMember.PhoneNumber}', Birthday = '{staffMember.Birthday}'" +
				$"WHERE id = '{staffMember.IdNumber}'";
			ExecuteNonQuery(update);
			foreach (var preference in staffMember.Preferences)
			{
				update = $"SELECT * FROM Preferences WHERE '{staffMember.IdNumber}' = StaffMember AND '{preference.ProgramAreaId}' = ProgramArea";

				bool hasRows;
				using (SQLiteConnection c = new SQLiteConnection(connectionString))
				{
					c.Open();
					using (SQLiteCommand cmd = new SQLiteCommand(update, c))
					{
						using (SQLiteDataReader rdr = cmd.ExecuteReader())
						{
							hasRows = rdr.HasRows;
						}
					}
				}
				if (hasRows)
				{
					update = $"UPDATE Preferences SET Preference = '{preference.PreferenceValue}' WHERE StaffMember = '{staffMember.IdNumber}' AND ProgramArea = '{preference.ProgramAreaId}'";
				}
				else
				{
					update = $"INSERT INTO Preferences(StaffMember, ProgramArea, Preference) VALUES " +
						$"('{staffMember.IdNumber}','{preference.ProgramAreaId}','{preference.PreferenceValue}')";
				}
				ExecuteNonQuery(update);
			}
		}

		public static List<Preference> GetStaffPreferences(int staffMemberId)
		{
			var preferences = new List<Preference>();
			// Add all existing program areas that are included in autoassign to the staff member. This is to make sure that if a new one is added that it will be included. 
			string getProgramAreas = $"SELECT * FROM Locations WHERE IsProgramArea = '1' AND IsWorkArea = '1'";
			var reader = ExecuteQuery(getProgramAreas);
			while (reader.Read())
			{
				preferences.Add(new Preference(reader["Name"].ToString(), Convert.ToInt32(reader["id"])));
			}
			// Next we need to check to see if this staff member has previous entrys. If so we update them to include what they perfer. 
			getProgramAreas = $"SELECT ProgramArea, Preference FROM Preferences WHERE StaffMember = '{staffMemberId}'";
			reader = ExecuteQuery(getProgramAreas);
			while (reader.Read())
			{
				Preference p = preferences.Where(x => x.ProgramAreaId == Convert.ToInt32(reader["ProgramArea"])).FirstOrDefault();
				if (p != null)
				{
					p.PreferenceValue = Convert.ToInt32(reader["Preference"]);
				}
			}
			return preferences;
		}

		//public static IEnumerable<Cabin> GetCabins(IEnumerable<CabinSchedule> cabinSchedules)
		//{
		//	var returnList = new List<Cabin>();
		//	string getString = $"SELECT * FROM Cabins ORDER BY id";
		//	var reader = ExecuteQuery(getString);
		//	while (reader.Read())
		//	{
		//		int id = Convert.ToInt32(reader["id"]);
		//		string name = reader["Name"].ToString();
		//		string loop = reader["Loop"] == null ? "" : reader["Loop"].ToString();
		//		int schedule = Convert.ToInt32(reader["Schedule"]);
		//		Cabin cabin = new Cabin(id, name, loop, schedule);
		//		cabin.Schedule = cabinSchedules.Where(x => x.Id == schedule).FirstOrDefault();
		//		returnList.Add(cabin);
		//	}
		//	Close();
		//	return returnList;
		//}

		public static IEnumerable<Cabin> GetCabins()
		{
			var returnList = new List<Cabin>();
			string getString = $"SELECT * FROM Cabins ORDER BY id";
			var reader = ExecuteQuery(getString);
			while (reader.Read())
			{
				int Id = Convert.ToInt32(reader[nameof(Id)]);
				string Name = reader[nameof(Name)].ToString();
				string Loop = reader[nameof(Loop)] == null ? "" : reader[nameof(Loop)].ToString();
				int ScheduleId = Convert.ToInt32(reader[nameof(ScheduleId)]);
				bool DefaultSelected = Convert.ToBoolean(reader[nameof(DefaultSelected)]);
				Cabin cabin = new Cabin(Id, Name, Loop, ScheduleId, DefaultSelected);
				returnList.Add(cabin);
			}
			Close();
			return returnList;
		}

		public static List<CabinSchedule> GetCabinSchedules()
		{
			Dictionary<int, string> ProgramAreas = new Dictionary<int, string>();
			string getString = $"SELECT * FROM Locations WHERE IsCabinActivity = '1' ORDER BY id";
			var reader = ExecuteQuery(getString);
			while (reader.Read())
			{
				ProgramAreas.Add(Convert.ToInt32(reader["id"]), reader["Name"].ToString());
			}
			reader.Close();
			Close();
			var returnList = new List<CabinSchedule>();
			getString = $"SELECT * FROM CabinSchedules ORDER BY id";
			reader = ExecuteQuery(getString);
			while (reader.Read())
			{
				int overnightNight = -1;
				bool hasOvernightNight = Int32.TryParse(reader["Overnight"].ToString(), out overnightNight);
				returnList.Add(new CabinSchedule(Convert.ToInt32(reader["id"]), reader["Name"].ToString(), null, overnightNight));

			}
			return returnList;
		}

		public static List<Location> GetWorkAreas()
		{
			string getString = $"SELECT * FROM Locations WHERE IsWorkArea = '1'";
			return GetLocation(getString);
		}

		public static List<Location> GetCabinActivities()
		{
			string getString = $"SELECT * FROM Locations WHERE IsCabinActivity = '1'";
			return GetLocation(getString);
		}

		public static List<Location> GetProgramAreas()
		{
			string getString = $"SELECT * FROM Locations WHERE IsProgramArea = '1'";
			return GetLocation(getString);
		}

		public static List<Location> GetAllLocations()
		{
			string getString = $"SELECT * FROM Locations";
			return GetLocation(getString);
		}


		private static List<Location> GetLocation(string query)
		{
			List<Location> workAreas = new List<Location>();
			var reader = ExecuteQuery(query);
			while (reader.Read())
			{
				int id = Convert.ToInt32(reader["id"]);
				string name = reader["Name"].ToString();
				int minimumStaff = -1, maximumStaff = -1, targetStaff = -1;
				Int32.TryParse(reader["Minimum Staff"].ToString(), out minimumStaff);
				Int32.TryParse(reader["TargetStaffPercent"].ToString(), out targetStaff);
				Int32.TryParse(reader["Maximum Staff"].ToString(), out maximumStaff);

				bool isProgramArea = Convert.ToBoolean(reader["IsProgramArea"]);
				bool isCabinActivity = Convert.ToBoolean(reader["IsCabinActivity"]);
				bool isWorkArea = Convert.ToBoolean(reader["IsWorkArea"]);
				bool isTradingPost = Convert.ToBoolean(reader["IsTradingPost"]);

				workAreas.Add(new Location(id, name, minimumStaff, targetStaff, maximumStaff,
					isProgramArea, isCabinActivity, isWorkArea, isTradingPost));
			}
			return workAreas;
		}
	}
}
