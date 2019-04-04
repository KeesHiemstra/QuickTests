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
		public ITAMDbContext(string DbConnection) : base(DbConnection) { }

		public DbSet<Win32_Product_SQL> Product { get; set; }

		internal static void SeedData(ITAMDbContext context)
		{
			context.Database.CreateIfNotExists();
		}
	}
}
