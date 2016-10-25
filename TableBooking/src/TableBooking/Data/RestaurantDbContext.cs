using Microsoft.EntityFrameworkCore;
using TableBooking.Models;

namespace TableBooking.Data
{
	public class RestaurantDbContext : DbContext
	{
		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<Table> Tables { get; set; }
	}
}