using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfoSystem.Structs;

namespace InfoSystem
{
	public class Organize
	{
		//todo: make id logic.
		static void Main(string[] args)
		{
			string path = String.Empty; //Path to file.

			//Load or make new department that app will work with.
			Department mainDepartment = Menu.Loading(ref path);
			int exit = 1;
			//Cycle that will relaunch app till exit != 0.
			while (exit != 0)
			{
				Menu.MainMenu(mainDepartment);
				Console.Clear();
				Console.WriteLine("0 - Завершить работу.");
				Console.WriteLine("1 - Продолжить работу.");
				int.TryParse(Console.ReadLine(), out exit);
			}
		}

		#region Debug tools

		/// <summary>
		/// Fill the worker list with specified count.
		/// </summary>
		/// <param name="count">Count of workers.</param>
		/// <returns></returns>
		public static List<Worker> DebugList(int count)
		{
			List<Worker> tempList = new List<Worker>(1_000_000);
			for (int i = 1; i < count + 1; i++)
			{
				tempList.Add(new Worker($"fName_{i}", $"sName_{i}", (byte)(i * 10), (uint)(i * 10), (byte)(i * 2)));
			}

			return tempList;
		}


		#endregion
	}
}