using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineEnds
{
	class Program
	{
		static void Main(string[] args)
		{
			Test test = new Test { Voornaam = "Kees", Telefoon = 215 };

			Console.WriteLine(test);
			Console.WriteLine(test.GetType().GetProperties());
			System.Reflection.PropertyInfo[] infos = test.GetType().GetProperties();

			foreach (var item in infos)
			{
				Console.WriteLine($"{item.Name}: {item.GetValue(test).ToString()}");
			}

			Console.Write("\nPress any key...");
			Console.ReadKey();
		}
	}

	public class Test
	{
		public string Voornaam { get; set; }
		public int Telefoon { get; set; }
	}
}
