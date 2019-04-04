using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database1
{
	public class ITAMDbContext : DbContext
	{
		//public ITAMDbContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ITAM;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False") { }
		public ITAMDbContext() : base(@"Trusted_Connection=True;Data Source=(Local);Database=ITAM;MultipleActiveResultSets=true") { }

		public DbSet<Win32_Product_SQL> Product { get; set; }

		internal static void SeedData(ITAMDbContext context)
		{
			context.Database.CreateIfNotExists();
		}
	}
}
