﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Models
{
	public class Win32_Account_List
	{
		public List<Win32_Account> Items = new List<Win32_Account>();

		public Win32_Account_List() { }

		public Win32_Account_List(string WMIClass, string members)
		{
			CollectWmiClass(WMIClass, members);
		}

		private async void CollectWmiClass(string wmiClass, string members)
		{
			Items.Clear();

			try
			{
				foreach (ManagementObject managementObject in WMIList.GetCollection(wmiClass, members))
				{
					WMIRecord record = new WMIRecord(members);
					foreach (PropertyData propertyData in managementObject.Properties)
					{
						record.ProcessProperty(propertyData);
					}
					Items.Add(new Win32_Account(record));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Querying the WMI Win32_Account has an exception:\n{ex.Message}", "Exception", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			}
		}
	}
}
