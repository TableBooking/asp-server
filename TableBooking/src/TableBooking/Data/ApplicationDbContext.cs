using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TableBooking.Models.RestaurantModels;
using TableBooking.Models.User;

namespace TableBooking.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) 
		{

		}

		public DbSet<Restaurant> Restaurants { get; set; }
		public DbSet<Table>	Tables { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<BookingPeriod> BookingPeriods { get; set; }

		public DbSet<Client> Clients { get; set; }
		public DbSet<RestaurantAdministrator> Administrators { get; set; }
	
	}
}