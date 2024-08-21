using EmployeeAdminPortal3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal3.Data
{
	public class CustomerAppDbContext : DbContext
	{
		//the below constructor is written manually
		//public CustomerAppDbContext(DbContextOptions<CustomerAppDbContext> options) : base(options)  
		//{

		//}

		//This constructer is generated from intelligence
		public CustomerAppDbContext(DbContextOptions options) : base(options)
		{
			
		}
		public DbSet<CustomerInfo> CustomerInfos { get; set; }
	}
}
