using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;

namespace InfoSystem.Structs
{
	public class Menu
	{
		#region Methods

		/// <summary>
		/// Loads exist department or creates new.
		/// </summary>
		public static Department Loading(ref string path)
		{
			int depMode = -1;
			//Check for proper values.
			while (depMode < 0 || depMode > 2)
			{
				Console.WriteLine("1 - Импортировать департамент.");
				Console.WriteLine("2 - Создать новый департамент.");
				Console.WriteLine("0 - Выход.");
				Int32.TryParse(Console.ReadLine(), out depMode);
			}
			if (depMode == 1)
			{
				Console.WriteLine("Введите путь к xml или json файлу с информацией о департаменте.");
				path = Console.ReadLine();
				return Menu.DeserializeDepartmentJX(path);
			}
			else
			{
				return Menu.makeNewDepartment();
			}

		}

		/// <summary>
		/// Main menu.
		/// </summary>
		/// <returns>Mode value.</returns>
		public static void MainMenu(Department dep)
		{
			Console.Clear();
			int mode = -1;
			Console.WriteLine("1 - Операции с сотрудниками департамента.");
			Console.WriteLine("2 - Операции с департаментом.");
			Console.WriteLine("3 - Сериализация.");
			Console.WriteLine("4 - Выбрать другой департамент.");
			Console.WriteLine("0 - Выход.");

			mode = Int32.Parse(Console.ReadLine());

			switch (mode)
			{
				case 1:
					WorkersMenu(dep);
					break;
				case 2:
					DepartmentMenu(dep);
					break;
				case 3:
					SerializeMenu(dep);
					break;
				case 4:
					//Restart application and choose other dep
					Application.Restart();
					Process.GetCurrentProcess().Kill();
					break;
				case 0:
					break;
				default:
					break;
			}
		}

		#region Worker menu.

		/// <summary>
		/// Workers menu.
		/// </summary>
		/// <param name="dep">Department instance.</param>
		public static void WorkersMenu(Department dep)
		{
			Console.Clear();
			int mode = -1;
			Console.WriteLine("1 - Создать сотрудника.");
			Console.WriteLine("2 - Редактировать сотрудника.");
			Console.WriteLine("3 - Удалить сотрудника из департамента.");
			Console.WriteLine("0 - Выход.");
			mode = Int32.Parse(Console.ReadLine());
			switch (mode)
			{
				case 1:
				{
					Worker newWorker = MakeNewWorker();
					dep.AppendWorker(newWorker); //appends worker to department
					Console.WriteLine("Сотрудник создан и добавлен в департамент. Нажмите любую клавишу.");
					Console.ReadKey();
					break;
				}
				case 2:
				{
					Console.Clear();
					Console.WriteLine(dep.PrintDepartment());
					//check department for contains workers
					if (dep.PrintDepartment() == "В департаменте нет сотрудников.")
					{
						Console.WriteLine("Нажмите любую клавишу...");
						Console.ReadKey();
						break;
					}
					else
					{
						int searchID = -1;
						while (searchID == -1)
						{
							Console.WriteLine("Введите ID работника, информацию о котором хотите редактировать.");
							Int32.TryParse(Console.ReadLine(), out searchID);
						}
						int workerIndex = GetWorkerIndex(dep, searchID); //finds worker index by ID.
						if (workerIndex == -1)
						{
							Console.WriteLine("Работника с указанным ID не существует.");
							break;
						}

						RewriteWorker(dep.WorkerList[workerIndex]);
						Console.WriteLine("Готово!");
						break;
					}
				}
				case 3:
				{
					Console.Clear();
					if (dep.WorkerList.Count < 1)
					{
						Console.WriteLine("В департаменте нет работников!");
						break;
					}
					else
					{
						int wID = -1;
						Console.WriteLine(dep.PrintDepartment());
						int wIndex = -1;
						do
						{
							Console.WriteLine("Введите ID работника которого хотите удалить: ");
							int.TryParse(Console.ReadLine(), out wID);
							wIndex = GetWorkerIndex(dep, wID);
						} while (wIndex < 0 || wIndex > dep.WorkerList.Count);
						dep.WorkerList.RemoveAt(wIndex);
						Console.WriteLine("Готово!");
						Console.WriteLine("Нажмите любую клавишу...");
						Console.ReadKey();
					}
					break;
				}
				case 0:
					break;
			}
		}

		/// <summary>
		/// Change specified parameters of Worker instance.
		/// </summary>
		/// <param name="worker">Worker instance</param>
		public static void RewriteWorker(Worker worker)
		{
			int mode = -1;
			while (mode < 0 || mode > 7)
			{
				Console.WriteLine("Значение какого параметра вы хотите редактировать?");
				Console.WriteLine("1 - Имя.");
				Console.WriteLine("2 - Фамилия.");
				Console.WriteLine("3 - ID");
				Console.WriteLine("4 - Заработная плата");
				Console.WriteLine("5 - Возраст");
				Console.WriteLine("6 - Департамент.");
				Console.WriteLine("7 - Количество закрепленных проэктов.");
				Console.WriteLine("0 - Выход.");
				Int32.TryParse(Console.ReadLine(), out mode);
			}

			switch (mode)
			{
				case 1:
				{
					Console.WriteLine("Введите новое имя: ");
					worker.ChangeFirstName(Console.ReadLine());
					Console.WriteLine("Готово!");
					break;
				}

				case 2:
				{
					Console.WriteLine("Введите новую фамилию: ");
					worker.ChangeSecondName(Console.ReadLine());
					Console.WriteLine("Готово!");
					break;
				}
				case 3:
				{
					uint ID = 0;
					while (ID == 0)
					{
						Console.WriteLine("Введите новый ID (больше 0): ");
						uint.TryParse(Console.ReadLine(), out ID);
					}
					worker.ChangeID(ID);
					Console.WriteLine("Готово!");
					break;
				}
				case 4:
				{
					uint salary = 0;
					while (salary == 0)
					{
						Console.WriteLine("Введите новое значение заработной платы: ");
						uint.TryParse(Console.ReadLine(), out salary);
					}
					worker.ChangeSalary(salary);
					Console.WriteLine("Готово!");
					break;
				}
				case 5:
				{
					byte age = 0;
					while (age == 0)
					{
						Console.WriteLine("Введите количество полных лет: ");
						Byte.TryParse(Console.ReadLine(), out age);
					}
					worker.ChangeAge(age);
					Console.WriteLine("Готово!");
					break;
				}
				case 6:
				{
					Console.WriteLine("Введите новое название департамента для работника: ");
					worker.ChangeDepartment(Console.ReadLine());
					Console.WriteLine("Готово!");
					break;
				}
				case 7:
				{
					int prCount = -1;
					while (prCount == -1)
					{
						Console.WriteLine("Введите новое количество закрепленных проэктов за работником: ");
						Int32.TryParse(Console.ReadLine(), out prCount);
					}
					worker.ChangeProjectCount((byte)prCount);
					Console.WriteLine("Готово!");
					break;
				}
				case 0:
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Search worker by speacified ID. If worker doesn't exist, method return -1.
		/// </summary>
		/// <param name="searchID">ID</param>
		/// <returns>Index of worker.</returns>
		public static int GetWorkerIndex(Department dep, int searchID)
		{
			foreach (var worker in dep.WorkerList)
			{
				if (worker.ID == searchID)
				{
					return dep.WorkerList.IndexOf(worker);
				}

			}
			return -1;
		}

		/// <summary>
		/// Creates new worker with the specified params.
		/// </summary>
		/// <returns>New worker instance.</returns>
		public static Worker MakeNewWorker()
		{
			Console.WriteLine("Введите имя: ");
			string fName = Console.ReadLine();
			Console.WriteLine("Введите фамилию.");
			string sName = Console.ReadLine();
			Console.WriteLine("Введите количество полных лет.");
			byte age = Byte.Parse(Console.ReadLine());
			Console.WriteLine("Введите количество закрепленных проэков.");
			byte pCount = Byte.Parse(Console.ReadLine());
			Console.WriteLine("Введите заработную плату.");
			uint salary = uint.Parse(Console.ReadLine());
			return new Worker(fName, sName, age, salary, pCount);
		}

		#endregion

		#region Department Menu

		//todo: check

		/// <summary>
		/// Department menu.
		/// </summary>
		public static void DepartmentMenu(Department dep)
		{
			Console.Clear();
			Console.WriteLine("1 - Редактировать название департамента.");
			Console.WriteLine("2 - Удалить департамент.");
			Console.WriteLine("3 - Отобразить информацию о департаменте.");
			Console.WriteLine("4 - Импортировать сотрудника из json/xml файла.");
			Console.WriteLine("0 - Выход.");

			int depMode = -1;

			//check for proper values.
			while (depMode < 0 || depMode > 4)
			{
				Console.WriteLine("Введите число: ");
				Int32.TryParse(Console.ReadLine(), out depMode);
			}

			switch (depMode)
			{
				case 1:
				{
					Console.Clear();
					Console.WriteLine("Введите новое название департамента: ");
					string newDName = String.Empty;
					do
					{
						newDName = Console.ReadLine();
					} while (newDName == String.Empty);

					RewriteDepartmentName(dep, newDName);
					Console.WriteLine("Готово!");
					break;
				}
				case 2:
				{
					dep = null;
					Console.Clear();
					Console.WriteLine("Желаете удалить файл сериализации?");
					Console.WriteLine("1 - Да.");
					Console.WriteLine("2 - Нет.");
					int rMode = 0;
					while (rMode < 1 || rMode > 2)
					{
						Int32.TryParse(Console.ReadLine(), out rMode);
					}
					if (rMode == 1)
					{
						Console.WriteLine("Введите путь к файлу: ");
						string path = String.Empty;
						string result = String.Empty;
						//check for proper values
						do
						{
							path = Console.ReadLine();
							result = File.Exists(path) ? "Готово!" : "Файл не существует";
							Console.WriteLine(result);
						} while (result == "Файл не существует");
						File.Delete(path);
					}
					else if (rMode == 2)
						break;
					break;
				}
				case 3:
				{
					Console.Clear();
					Console.WriteLine(dep.PrintDepartment());
					Console.WriteLine("Желаете отсортировать информацию?");
					Console.WriteLine("1 - Да.");
					Console.WriteLine("2 - Нет.");
					int sortMode = -1;
					while (sortMode < 1 || sortMode > 2)
					{
						Console.WriteLine("Выберите режим: ");
						int.TryParse(Console.ReadLine(), out sortMode);
					}

					if (sortMode == 1)
					{
						SortDepartmentMenu(dep);
						break;
					}

					break;
				}

				case 4:
				{
					Console.Clear();
					Console.WriteLine("Введите путь к файлу: ");
					string path = Console.ReadLine();
					if (File.Exists(path))
					{
						dep.AppendWorker(DeserializeWokerJX(path));
						break;
					}

					do
					{
						Console.Clear();
						Console.WriteLine("Файла не существует!");
						Console.WriteLine("Введите путь к файлу: ");
						path = Console.ReadLine();

					} while (File.Exists(path));

					dep.AppendWorker(DeserializeWokerJX(path));
					break;
				}
				case 0:
					break;
			}
		}

		public static void SortDepartmentMenu(Department dep)
		{
			Console.Clear();
			dSort sort = new dSort();
			Console.WriteLine("По одному(1) или двум(2) полям?");
			int sortMode = -1;
			//Check for proper values
			while (sortMode < 1 || sortMode > 2)
			{
				Console.WriteLine("Введите значение: ");
				int.TryParse(Console.ReadLine(), out sortMode);
			}

			#region Single Sort.

			if (sortMode == 1)
			{
				Console.Clear();
				Console.WriteLine("Выберите поле: ");
				Console.WriteLine("1 - Имя.");
				Console.WriteLine("2 - Фамилия.");
				Console.WriteLine("3 - Возраст.");
				Console.WriteLine("4 - ID.");
				Console.WriteLine("5 - Зарплата.");
				Console.WriteLine("6 - Количество закрепленных проэктов.");
				int fieldMode = -1;
				while (fieldMode < 1 || fieldMode > 6)
				{
					Console.WriteLine("Введите значение.");
					int.TryParse(Console.ReadLine(), out fieldMode);
					switch (fieldMode)
					{
						case 1:
							dep.RewriteWorkerList(sort.fName(dep));
							Console.WriteLine(dep.PrintDepartment());
							break;
						case 2:
							dep.RewriteWorkerList(sort.sName(dep));
							Console.WriteLine(dep.PrintDepartment());
							break;
						case 3:
							dep.RewriteWorkerList(sort.Age(dep));
							Console.WriteLine(dep.PrintDepartment());
							break;
						case 4:
							dep.RewriteWorkerList(sort.ID(dep));
							Console.WriteLine(dep.PrintDepartment());
							break;
						case 5:
							dep.RewriteWorkerList(sort.Salary(dep));
							Console.WriteLine(dep.PrintDepartment());
							break;
						case 6:
							dep.RewriteWorkerList(sort.PCount(dep));
							Console.WriteLine(dep.PrintDepartment());
							break;
					}

					Console.ReadKey();
				}

			}

			#endregion

			#region Double sort.

			else
			{
				Console.WriteLine("Выберите поля: ");
				Console.WriteLine("1 - Имя.");
				Console.WriteLine("2 - Фамилия.");
				Console.WriteLine("3 - Возраст.");
				Console.WriteLine("4 - ID.");
				Console.WriteLine("5 - Зарплата.");
				Console.WriteLine("6 - Количество закрепленных проэктов.");
				int fieldMode = -1;

				#region Check for proper values

				//List that contains all avaliable values
				int[] avaliableValues =
				{
					12, 13, 14, 15, 16,
					21, 31, 41, 51, 61,
					
					23, 24, 25, 26,
					32, 42, 52, 62,
					
					34, 35, 36,
					43, 53, 64,

					45, 46,
					54, 64,
					
					56,
					65
				};

				#endregion

				//check for proper values.
				while (!avaliableValues.Contains(fieldMode))
				{
					Console.WriteLine("Введите два значения БЕЗ ПРОБЕЛА.");
					int.TryParse(Console.ReadLine(), out fieldMode);
				}
				dep.RewriteWorkerList(GetDoubleSortedList(dep, fieldMode));
				Console.WriteLine(dep.PrintDepartment());
				Console.ReadKey();
			}

			#endregion
		}

		/// <summary>
		/// Rewrite specified department name for Department struct and each worker in department.
		/// </summary>
		/// <param name="dep">Department instance.</param>
		/// <param name="name">New department name.</param>
		public static void RewriteDepartmentName(Department dep, string name)
		{
			dep.ChangeDepartmentName(name);
			for (int i = 0; i < dep.WorkerList.Count; i++)
			{
				dep.WorkerList[i].ChangeDepartment(name);
			}
		}

		/// <summary>
		/// Creates new Department instance with specified name.
		/// </summary>
		/// <returns></returns>
		public static Department makeNewDepartment()
		{
			Console.Clear();
			Console.WriteLine("Введите название департамента.");
			string depName = Console.ReadLine();
			return new Department(depName);
		}

		/// <summary>
		/// Sort worker list by two fields.
		/// </summary>
		/// <param name="dep">Department instance.</param>
		/// <param name="value">First digit in value is first field, Second digit is second.</param>
		/// <returns></returns>
		public static List<Worker> GetDoubleSortedList(Department dep, int value)
		{
			dSort sort = new dSort();
			Dictionary<int, List<Worker>> Sorting = new Dictionary<int, List<Worker>>();

			//First name + Second name.
			Sorting.Add(12, sort.fNameSName(dep));
			Sorting.Add(21, sort.fNameSName(dep));
			//First name + age.
			Sorting.Add(13, sort.fNameAge(dep));
			Sorting.Add(31, sort.fNameAge(dep));
			//First name + ID.
			Sorting.Add(14, sort.fNameID(dep));
			Sorting.Add(41, sort.fNameID(dep));
			//First name + salary.
			Sorting.Add(15, sort.fNameSalary(dep));
			Sorting.Add(51, sort.fNameSalary(dep));
			//First name + project count.
			Sorting.Add(16, sort.FNamePCount(dep));
			Sorting.Add(61, sort.FNamePCount(dep));

			//Second name + age.
			Sorting.Add(23, sort.sNameAge(dep));
			Sorting.Add(32, sort.sNameAge(dep));
			//Second name + ID.
			Sorting.Add(24, sort.sNameID(dep));
			Sorting.Add(42, sort.sNameID(dep));
			//Second name + salary.
			Sorting.Add(25, sort.sNameSalary(dep));
			Sorting.Add(52, sort.sNameSalary(dep));
			//Second name + project count.
			Sorting.Add(26, sort.SNamePCount(dep));
			Sorting.Add(62, sort.SNamePCount(dep));

			//Age + ID.
			Sorting.Add(34, sort.AgeId(dep));
			Sorting.Add(43, sort.AgeId(dep));
			//Age + Salary.
			Sorting.Add(35, sort.AgeSalary(dep));
			Sorting.Add(53, sort.AgeSalary(dep));
			//Age + project count.
			Sorting.Add(36, sort.AgePCount(dep));
			Sorting.Add(63, sort.AgePCount(dep));

			//ID + salary.
			Sorting.Add(45, sort.IDSalary(dep));
			Sorting.Add(54, sort.IDSalary(dep));
			//ID + project count.
			Sorting.Add(46, sort.IDPCount(dep));
			Sorting.Add(64, sort.IDPCount(dep));

			//Salary + project count.
			Sorting.Add(56, sort.SalaryPCount(dep));
			Sorting.Add(65, sort.SalaryPCount(dep));

			return Sorting[value];
		}

		#endregion

		#region Serialize Menu

		/// <summary>
		/// Serialize menu.
		/// </summary>
		public static void SerializeMenu(Department dep)
		{
			Console.Clear();
			Console.WriteLine("1 - Работник.");
			Console.WriteLine("2 - Департамент.");
			Console.WriteLine("0 - Выход.");

			int sMode = -1;

			while (sMode < 0 || sMode > 2)
			{
				Int32.TryParse(Console.ReadLine(), out sMode);
			}

			switch (sMode)
			{
				case 1:
					SerizalizeWorkerMenu(dep);
					break;
				case 2:
					SerializeDepartmentMenu(dep);
					break;
			}
		}

		/// <summary>
		/// Serealize worker console menu.
		/// </summary>
		/// <param name="dep"></param>
		public static void SerizalizeWorkerMenu(Department dep)
		{
			Console.Clear();
			int wID = -1;
			Console.WriteLine(dep.PrintDepartment());

			while (wID < 0)
			{
				Console.WriteLine("Введите ID работника для сериализации: ");
				int.TryParse(Console.ReadLine(), out wID);
			}
			int wIndex = GetWorkerIndex(dep, wID);

			if (wIndex == -1)
			{
				Console.WriteLine("Указанного работника не существует!");
			}
			else
			{
				int sMode = 0;
				while (sMode < 1 || sMode > 2)
				{
					Console.WriteLine("1 - Json.");
					Console.WriteLine("2 - XML.");
					Int32.TryParse(Console.ReadLine(), out sMode);
				}

				if (sMode == 1)
				{
					Console.WriteLine("Введите путь: ");
					string path = Console.ReadLine();
					ParseJson json = new ParseJson();
					json.SerializeWorker(path, dep.WorkerList[wIndex]);
					Console.WriteLine("Готово!");
				}

				else if (sMode == 2)
				{
					Console.WriteLine("Введите путь: ");
					string path = Console.ReadLine();
					ParseXML xml = new ParseXML();
					xml.SerializeWorker(dep.WorkerList[wIndex], path);
					Console.WriteLine("Готово!");
				}
			}
		}

		/// <summary>
		/// Serialize department menu.
		/// </summary>
		/// <param name="dep">Department instance.</param>
		public static void SerializeDepartmentMenu(Department dep)
		{
			int sMode = 0;
			while (sMode < 1 || sMode > 2)
			{
				Console.WriteLine("1 - Json.");
				Console.WriteLine("2 - XML.");
				Int32.TryParse(Console.ReadLine(), out sMode);
			}

			if (sMode == 1)
			{
				Console.WriteLine("Введите путь: ");
				string path = Console.ReadLine();
				ParseJson json = new ParseJson();
				json.SerializeDepartment(dep, path);
				Console.WriteLine("Готово!");
			}

			else if (sMode == 2)
			{
				Console.WriteLine("Введите путь: ");
				string path = Console.ReadLine();
				ParseXML xml = new ParseXML();
				xml.SerializeDepartment(dep, path);
				Console.WriteLine("Готово!");
			}
		}

		/// <summary>
		/// Deserialize worker from Json/Xml file to Worker instance.
		/// </summary>
		/// <param name="path">Path to file.</param>
		/// <returns></returns>
		public static Worker DeserializeWokerJX(string path)
		{
			if (path.Contains(".xml"))
			{
				ParseXML xml = new ParseXML();
				Worker newWorker = xml.DeserializeWorker(path);
				return newWorker;
			}
			else if (path.Contains(".json"))
			{
				ParseJson json = new ParseJson();
				Worker newWorker = json.DeserializeWorker(path);
				return newWorker;
			}
			return null;
		}

		/// <summary>
		/// Deserialize department from Json/Xml file to Department instance.
		/// </summary>
		/// <param name="path">Path to file.</param>
		/// <returns></returns>
		public static Department DeserializeDepartmentJX(string path)
		{
			//todo: check
			Department tempDep = new Department();
			if (path.Contains(".xml"))
			{
				ParseXML xml = new ParseXML();
				tempDep = xml.DeserializeDepartment(path);
				return tempDep;
			}
			if (path.Contains(".json")) 
			{
				ParseJson json = new ParseJson();
				tempDep = json.DeserializeDepartment(path);
				return tempDep;
			}

			return null;
		}

		#endregion

		#endregion
	}
}
