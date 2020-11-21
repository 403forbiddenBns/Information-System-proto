using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InfoSystem.Structs
{
	class Debug
	{
		public static void DebMain()
		{
			Department dep = new Department();
			ParseJson json = new ParseJson();
			dep = json.DeserializeDepartment("_jsonExample.json");
			Console.WriteLine(dep.PrintDepartment());
		}

	}
}
