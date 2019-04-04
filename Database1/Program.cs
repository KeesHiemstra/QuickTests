using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database1
{
	class Program
	{
		public static string JsonPath;
		public static ITAMInventory Inventory;
		public static List<Win32_Product_SQL> Product = new List<Win32_Product_SQL>();

		static void Main(string[] args)
		{
			GetJsonPath();
			GetJsonFiles();

			Console.Write("\nPress any key...");
			Console.ReadKey();
		}

		private static void ImportJson()
		{
			Console.WriteLine(Inventory.ComputerName);

			using (var db = new ITAMDbContext())
			{
				using (Win32_Product_SQL product_SQL = new Win32_Product_SQL())
				{
					foreach (var item in Inventory.win32_Product.Items)
					{
						product_SQL.ComputerName = Inventory.ComputerName;
						product_SQL.Name = item.Name.Replace("<null>", "");
						product_SQL.Vendor = item.Vendor.Replace("<null>", "");
						product_SQL.Version = item.Version.Replace("<null>", "");
						product_SQL.IdentifyingNumber = item.IdentifyingNumber;
						product_SQL.InstallDate = item.InstallDate.Replace("<null>", "");
						product_SQL.InstallLocation = item.InstallLocation.Replace("<null>", "");
						product_SQL.InstallSource = item.InstallSource.Replace("<null>", "");
						product_SQL.LocalPackage = item.LocalPackage.Replace("<null>", "");
						product_SQL.PackageCache = item.PackageCache.Replace("<null>", "");
						product_SQL.PackageCode = item.PackageCode.Replace("<null>", "");
						product_SQL.PackageName = item.PackageName.Replace("<null>", "");
						product_SQL.URLInfoAbout = item.URLInfoAbout.Replace("<null>", "");
						product_SQL.URLUpdateInfo = item.URLUpdateInfo.Replace("<null>", "");

						db.Product.Add(product_SQL);
						db.SaveChanges();
					}

				}
			}
		}

		private static void GetJsonFiles()
		{
			IEnumerable<string> jsonFiles = Directory.EnumerateFiles(JsonPath, "Inventory-*.json");
			foreach (string jsonFile in jsonFiles)
			{
				Inventory = new ITAMInventory();

				using (StreamReader stream = File.OpenText(jsonFile))
				{
					string json = stream.ReadToEnd();
					Inventory = JsonConvert.DeserializeObject<ITAMInventory>(json);

					ImportJson();
				}
			}
		}

		private static void GetJsonPath()
		{
			if (File.Exists("\\\\NASServer\\Data\\Kees\\Inventory.exe"))
			{
				JsonPath = "\\\\NASServer\\Data\\Kees\\Inventory";
			}
			else if (Directory.Exists("C:\\Users\\Kees\\OneDrive\\Etc\\ITAM\\Inventory"))
			{
				JsonPath = "C:\\Users\\Kees\\OneDrive\\Etc\\ITAM\\Inventory";
			}
			else if (Directory.Exists("C:\\Etc\\ITAM\\Inventory"))
			{
				JsonPath = "C:\\Etc\\ITAM\\Inventory";
			}
		}
	}


}
