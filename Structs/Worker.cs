using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoSystem.Structs;
using Newtonsoft.Json;

namespace InfoSystem.Structs
{
	public class Worker
	{
		#region Fields/Props
		[JsonProperty]
		public string FirstName { get; private set; }
		[JsonProperty]
		public string SecondName { get; private set; }
		[JsonProperty]
		public byte Age { get; private set; }
		[JsonProperty]
		public string Department { get; private set; }
		[JsonProperty]
		public uint ID { get; private set; }
		[JsonProperty]
		public uint Salary { get; private set; }
		[JsonProperty]
		public byte ProjectCount { get; private set; }

		#endregion

		#region Constructors

		public Worker()
		{

		}

		public Worker(string firstName, string secondName, byte age, uint salary, byte projectCount, string department = "N/A", uint ID = 0)
		{
			FirstName = firstName;
			SecondName = secondName;
			Age = age;
			Salary = salary;
			ProjectCount = projectCount;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Shows worker data.
		/// </summary>
		/// <returns>String contains worker data</returns>
		public string Print()
		{
			StringBuilder printData = new StringBuilder();
			string firstLine =
				$" {"First name",15} {"Second name",15} {"Age",5} {"Department",15} {"ID",4} {"Projects",10}";
			string data = $"{FirstName,15} {SecondName,15} {Age,6} {Department,15} {ID,4} {ProjectCount,10}";
			printData.AppendLine(firstLine);
			printData.AppendLine(data);
			return printData.ToString();
		}
		/// <summary>
		/// Canges workers department.
		/// </summary>
		/// <param name="newDepartment"></param>
		public void ChangeDepartment(string newDepartment)
		{
			Department = newDepartment;
		}
		/// <summary>
		/// Change workers first name.
		/// </summary>
		/// <param name="newFName"></param>
		public void ChangeFirstName(string newFName)
		{
			FirstName = newFName;
		}
		/// <summary>
		/// Change workers second name.
		/// </summary>
		/// <param name="newSName"></param>
		public void ChangeSecondName(string newSName)
		{
			SecondName = newSName;
		}
		/// <summary>
		/// Change workers age.
		/// </summary>
		/// <param name="newAge"></param>
		public void ChangeAge(byte newAge)
		{
			Age = newAge;
		}
		/// <summary>
		/// Change workers ID.
		/// </summary>
		/// <param name="newID"></param>
		public void ChangeID(uint newID)
		{
			ID = newID;
		}
		/// <summary>
		/// Changes workers salary.
		/// </summary>
		/// <param name="newSalary"></param>
		public void ChangeSalary(uint newSalary)
		{
			Salary = newSalary;
		}
		/// <summary>
		/// Changes workers project count.
		/// </summary>
		/// <param name="newPCount"></param>
		public void ChangeProjectCount(byte newPCount)
		{
			ProjectCount = newPCount;
		}
	}

	#endregion
}