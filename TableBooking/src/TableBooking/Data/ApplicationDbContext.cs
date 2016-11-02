using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TableBooking.Models;
using TableBooking.Models.User;

namespace TableBooking.Data
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) 
		{

		}

		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<Table>	Tables { get; set; }
		public DbSet<RestaurantAdministrator> RestaurantAdministrators { get; set; }
	
	}
}