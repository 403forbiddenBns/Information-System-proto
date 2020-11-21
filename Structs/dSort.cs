using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSystem.Structs
{
	public class dSort
	{
		#region Fields/Props
		public List<Worker> sortedList { get; private set; }

		#endregion

		#region Methods

		#region Single Sort

		/// <summary>
		/// Sort by first name.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> fName(Department department)
		{
			sortedList = department.WorkerList.OrderBy(x => x.FirstName).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by second name.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> sName(Department department)
		{
			sortedList = department.WorkerList.OrderBy(x => x.SecondName).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by ID.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> ID(Department department)
		{
			sortedList = department.WorkerList.OrderBy(x => x.ID).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by Age.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> Age(Department department)
		{
			sortedList = department.WorkerList.OrderBy(x => x.Age).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by Salary.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> Salary(Department department)
		{
			sortedList = department.WorkerList.OrderBy(x => x.Salary).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by project count.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> PCount(Department department)
		{
			sortedList = department.WorkerList.OrderBy(x => x.ProjectCount).ToList();
			return sortedList;
		}

		#endregion

		#region Double Sort

		/// <summary>
		/// Sort by first name and second name.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> fNameSName(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.FirstName).ThenBy(i => i.SecondName).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by first name and age.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> fNameAge(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.FirstName).ThenBy(i => i.Age).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by first name and ID.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> fNameID(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.FirstName).ThenBy(i => i.ID).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by first name and salary.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> fNameSalary(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.FirstName).ThenBy(i => i.Salary).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by first name and project count.
		/// </summary>
		/// <param name="department"></param>
		/// <returns></returns>
		public List<Worker> FNamePCount(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.FirstName).ThenBy(i => i.ProjectCount).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by second name and age.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> sNameAge(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.SecondName).ThenBy(i => i.Age).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by second name and ID.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> sNameID(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.SecondName).ThenBy(i => i.ID).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by second name and salary.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> sNameSalary(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.SecondName).ThenBy(i => i.Salary).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by second name and project count.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> SNamePCount(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.SecondName).ThenBy(i => i.ProjectCount).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by age and ID.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> AgeId(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.Age).ThenBy(i => i.ID).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by age and salary.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> AgeSalary(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.Age).ThenBy(i => i.Salary).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by age and project count.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> AgePCount(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.Age).ThenBy(i => i.ProjectCount).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by ID and Salary.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> IDSalary(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.ID).ThenBy(i => i.Salary).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by ID and project count.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> IDPCount(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.ID).ThenBy(i => i.ProjectCount).ToList();
			return sortedList;
		}

		/// <summary>
		/// Sort by salary and project count.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <returns></returns>
		public List<Worker> SalaryPCount(Department department)
		{
			sortedList = department.WorkerList.OrderBy(i => i.Salary).ThenBy(i => i.ProjectCount).ToList();
			return sortedList;
		}

		#endregion

		/// <summary>
		/// Prints sorted information.
		/// </summary>
		/// <param name="list">List of sorted workers.</param>
		/// <returns></returns>
		public string PrintSortedInfo()
		{
			if (sortedList.Count < 1)
			{
				return "В департаменте нет сотрудников.";
			}
			else
			{
				StringBuilder printData = new StringBuilder();
				string firstLine =
					$" {"First name",15} {"Second name",15} {"Age",5} {"Department",15} {"ID",4} {"Projects",10} {"Salary",10}";
				printData.AppendLine(firstLine);
				foreach (var worker in sortedList)
				{
					string data = $"{worker.FirstName,15} {worker.SecondName,15} {worker.Age,6} {worker.Department,15} {worker.ID,4} {worker.ProjectCount,10} {worker.Salary,10}";
					printData.AppendLine(data);
				}

				return printData.ToString();
			}
		}

		#endregion


	}
}
