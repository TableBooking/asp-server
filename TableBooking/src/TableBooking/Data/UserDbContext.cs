using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TableBooking.Data
{
	public class UserDbContext : IdentityDbContext<IdentityUser>
	{
		public UserDbContext(DbContextOptions<UserDbContext> options)
			: base(options) 
		{

		}
	}
}