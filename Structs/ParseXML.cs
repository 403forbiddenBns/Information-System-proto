using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InfoSystem.Structs
{
	public class ParseXML
	{
		#region Methods

		#region Worker

		//DONE!
		/// <summary>
		/// Serialize worker to xml file.
		/// </summary>
		/// <param name="worker">Concrete worker.</param>
		/// <param name="path">Path to file.</param>
		public void SerializeWorker(Worker worker, string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Worker));
			FileStream FStream = new FileStream(path, FileMode.Create, FileAccess.Write);
			serializer.Serialize(FStream, worker);
			FStream.Close();
		}

		//DONE!
		/// <summary>
		/// Deserialize xml file to Worker struct.
		/// </summary>
		/// <param name="path">Path to file.</param>
		/// <returns></returns>
		public Worker DeserializeWorker(string path)
		{
			Worker tempWorker = new Worker();
			XmlSerializer serializer = new XmlSerializer(typeof(Worker));
			//Stream FStream = new FileStream(path, FileMode.Open, FileAccess.Read);
			StreamReader sr = new StreamReader(path, Encoding.UTF8);
			tempWorker = serializer.Deserialize(sr) as Worker;
			sr.Close();
			return tempWorker;
		}

		#endregion

		#region ListOfWorkers

		//DONE!
		/// <summary>
		/// Serialize list of workers to xml file.
		/// </summary>
		/// <param name="department">Department class instance.</param>
		/// <param name="path">Path to file.</param>
		public void SerializeWorkers(Department department, string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Worker>));

			FileStream FStream = new FileStream(path, FileMode.Create, FileAccess.Write);

			serializer.Serialize(FStream, department.WorkerList);
		}

		//DONE!
		/// <summary>
		/// Serialize list of workers to xml file.
		/// </summary>
		/// <param name="path">Path to file.</param>
		/// <returns></returns>
		public List<Worker> DeserializeWorkers(string path)
		{
			List<Worker> tempWorkers = new List<Worker>(1_000_000);
			XmlSerializer xml = new XmlSerializer(typeof(List<Worker>));
			FileStream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);

			tempWorkers = xml.Deserialize(fStream) as List<Worker>;

			return tempWorkers;
		}

		#endregion

		#region Department

		//DONE!
		/// <summary>
		/// Serialize entire department to xml file.
		/// </summary>
		/// <param name="dep">Concrete department.</param>
		/// <param name="path">Path to file.</param>
		public void SerializeDepartment(Department dep, string path)
		{
			XmlSerializer xml = new XmlSerializer(typeof(Department));

			var fStream = new FileStream(path, FileMode.Create, FileAccess.Write);

			xml.Serialize(fStream, dep);
		}

		//DONE!
		/// <summary>
		/// Deserialize entire department from xml file.
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public Department DeserializeDepartment(string path)
		{
			Department tempDep;

			XmlSerializer xml = new XmlSerializer(typeof(Department));

			var fStream = new FileStream(path, FileMode.Open, FileAccess.Read);

			tempDep = xml.Deserialize(fStream) as Department;

			return tempDep;
		}

		#endregion

		#endregion
	}
}