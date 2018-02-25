using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Common.Test
{
	[TestFixture]
	public class StaffMemberTests
	{
		[Test]
		public void TestCreation()
		{
			string fullName = "Jacintha";
			int id = 10;
			DateTime birthday = new DateTime(1995, 7, 12);
			string phoneNumber = "1234567890";
			string email = "email@email.com";
			string nickName = "Jaci";

			StaffMember staff = new StaffMember(fullName, id, birthday, phoneNumber, email, null, nickName);

			Assert.AreEqual(nickName, staff.NickName);
			Assert.AreEqual(fullName, staff.FullName);
			Assert.AreEqual(id, staff.IdNumber);
			Assert.AreEqual(birthday, staff.Birthday);
			Assert.AreEqual(phoneNumber, staff.PhoneNumber);
			Assert.AreEqual(email, staff.Email);
		}

		[Test]
		public void TestName()
		{
			string fullName = "Jacintha";
			string nickName = "Jaci";

			StaffMember staffWithNick = new StaffMember(fullName, 0, DateTime.Now, null, null, null, nickName);
			StaffMember staffWithoutNickName = new StaffMember(fullName, 0, DateTime.Now, null, null, null);

			Assert.AreEqual(nickName, staffWithNick.Name);
			Assert.AreEqual(fullName, staffWithoutNickName.Name);
		}

		[Test]
		public void TestInvalidIdNumber()
		{
			try
			{
				StaffMember s = new StaffMember("Jacintha", -1, DateTime.Now, null, null, null);
			}
			catch(ArgumentOutOfRangeException)
			{
				Assert.Pass();
			}
			Assert.Fail();
		}

		[Test]
		[TestCaseSource(nameof(GetInvalidNameList))]
		public void TestInvalidName(string name)
		{
			try
			{
				StaffMember s = new StaffMember(name, 0, DateTime.Now, null, null, null);
			}
			catch (ArgumentOutOfRangeException)
			{
				Assert.Pass();
			}
			Assert.Fail();
		}

		private List<string> GetInvalidNameList()
		{
			return new List<string>()
			{
				"  ",
				null,
				String.Empty,
				"\n",
				"                        ",
				" "
			};
		}

		[Test]
		public void TestEquals()
		{
			StaffMember s1 = new StaffMember("Jacintha", 0, DateTime.Now, null, null, null, "Jaci");
			StaffMember s2 = new StaffMember("Jacintha", 1, DateTime.Now, null, null, null, "Jaci");
			StaffMember s3 = new StaffMember("Jacintha", 0, DateTime.Now, null, null, null);
			StaffMember s4 = new StaffMember("Jacintha", 1, DateTime.Now, null, null, null);
			StaffMember s5 = new StaffMember("Jacinth", 0, DateTime.Now, null, null, null, "Jaci");
			StaffMember s6 = new StaffMember("Jacinth", 1, DateTime.Now, null, null, null, "Jaci");

			Assert.AreEqual(s1, s1);
			Assert.AreEqual(s2, s2);
			Assert.AreEqual(s3, s3);
			Assert.AreEqual(s4, s4);
			Assert.AreEqual(s5, s5);
			Assert.AreEqual(s6, s6);

			Assert.AreNotEqual(s1, s2);
			Assert.AreNotEqual(s1, s3);
			Assert.AreNotEqual(s1, s4);
			Assert.AreNotEqual(s1, s5);
			Assert.AreNotEqual(s1, s6);


		}
	}
}
