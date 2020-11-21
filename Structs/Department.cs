using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using InfoSystem.Structs;


namespace InfoSystem.Structs
{
	public class Department
	{
		#region Fields/Props

		public List<Worker> WorkerList { get; private set; }

		public string DepartmentName { get; private set; }

		public int DepartmentCount
		{
			get { return WorkerList.Count; }
		}

		private DateTime CreationDate { get; }

		#endregion

		#region Constructors

		public Department(string departmentName)
		{
			DepartmentName = departmentName;
			WorkerList = new List<Worker>(1_000_000);
			CreationDate = DateTime.Now;
		}

		public Department()
		{
			DepartmentName = "N/A";
			WorkerList = new List<Worker>(1_000_000);
			CreationDate = DateTime.Now;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Append worker to department and set his "department" field with current deparment name.
		/// </summary>
		/// <param name="worker"></param>
		public void AppendWorker(Worker worker)
		{
			worker.ChangeDepartment(DepartmentName);
			if (WorkerList.Count < 1)
			{
				worker.ChangeID(1);
			}
			else
			{
				worker.ChangeID(WorkerList[WorkerList.Count - 1].ID + 1);
			}
			WorkerList.Add(worker);
		}

		/// <summary>
		/// Append worker to department and set thier "department" field with current deparment name.
		/// </summary>
		/// <param name="workers"></param>
		public void AppendWorkers(List<Worker> workers)
		{
			
			for (int i = 0; i < workers.Count; i++)
			{
				if (WorkerList.Count < 1)
				{
					workers[i].ChangeDepartment(DepartmentName);
					workers[i].ChangeID(0);
					WorkerList.Add(workers[i]);
				}
				else
				{
					workers[i].ChangeDepartment(DepartmentName);
					workers[i].ChangeID(WorkerList[WorkerList.Count - 1].ID + 1);
					WorkerList.Add(workers[i]);
				}
			}
		}

		/// <summary>
		/// Changes department name.
		/// </summary>
		/// <param name="newName">New department name.</param>
		public void ChangeDepartmentName(string newName)
		{
			DepartmentName = newName;
		}

		/// <summary>
		/// Rewrites current worker list with specified list.
		/// </summary>
		/// <param name="workers">Worker list.</param>
		public void RewriteWorkerList(List<Worker> workers)
		{
			WorkerList = workers;
		}

		/// <summary>
		/// Print department info.
		/// </summary>
		/// <returns>String contains department info.</returns>
		public string PrintDepartment()
		{
			if (WorkerList.Count < 1)
			{
				return "В департаменте нет сотрудников.";
			}
			else
			{
				StringBuilder printData = new StringBuilder();
				printData.AppendLine("Название: " + DepartmentName);
				printData.AppendLine($"{"First name",15} {"Second name",15} {"Age",5} {"Department",15} {"ID",4} {"Projects",10} {"Salary",10}");
				foreach (var worker in WorkerList)
				{
					printData.AppendLine($"{worker.FirstName,15} {worker.SecondName,15} {worker.Age,6} {worker.Department,15} {worker.ID,4} {worker.ProjectCount,10} {worker.Salary,10}");
				}

				printData.AppendLine($"Creation date: {CreationDate}");

				return printData.ToString();
			}
		}

		#endregion
	}
}