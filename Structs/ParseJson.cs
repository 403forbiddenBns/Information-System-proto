using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InfoSystem.Structs
{
	public class ParseJson
	{

		#region Methods

		#region Worker.

		/// <summary>
		/// Serialize Workers instance to json.
		/// </summary>
		/// <param name="path">Path to file.</param>
		/// <param name="worker">Worker instance.</param>
		public void SerializeWorker(string path, Worker worker)
		{
			string json = JsonConvert.SerializeObject(worker);
			File.WriteAllText(path, json);
		}

		/// <summary>
		/// Deserialize worker from json to Worker instance.
		/// </summary>
		/// <param name="path">Path to file.</param>
		/// <returns></returns>
		public Worker DeserializeWorker(string path)
		{
			string json = File.ReadAllText(path);
			Worker tempWorker = JsonConvert.DeserializeObject<Worker>(json);
			return tempWorker;
		}

		#endregion

		#region List of workers.

		/// <summary>
		/// Serialize list of workers to json file.
		/// </summary>
		/// <param name="department">Department instance.</param>
		/// <param name="path">Path to file.</param>
		public void SerializeWorkerList(Department department, string path)
		{
			string json = JsonConvert.SerializeObject(department.WorkerList);
			File.WriteAllText(path, json);
		}

		/// <summary>
		/// Deserialize json file to list of workers.
		/// </summary>
		/// <param name="path">Path to file.</param>
		/// <returns></returns>
		public List<Worker> DeserializeWorkerList(string path)
		{
			string json = File.ReadAllText(path);
			List<Worker> tempList = JsonConvert.DeserializeObject<List<Worker>>(json);
			return tempList;
		}

		#endregion

		#region Department
		
		//DONE!!
		/// <summary>
		/// Serialize entire department to json file.
		/// </summary>
		/// <param name="department">Concrete department.</param>
		/// <param name="path">Path to file.</param>
		public void SerializeDepartment(Department department, string path)
		{
			string json = JsonConvert.SerializeObject(department);
			File.WriteAllText(path, json);
		}

		//DONE!!
		public Department DeserializeDepartment(string path)
		{
			string json = File.ReadAllText(path);
			//Department tempDep = JsonConvert.DeserializeObject<Department>(json);
			Department tempDep = JsonConvert.DeserializeObject<Department>(json);
			return tempDep;
		}

		#endregion

		#endregion
	}
}