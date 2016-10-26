using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TableBooking.Data
{
    public class DbIntializer
    {
	    public static void Initialize(UserDbContext context)
		{
			context.Database.EnsureCreated();

			if (context.Roles.Any()) return;

			context.Roles.Add(new IdentityRole("Administator"));
			context.Roles.Add(new IdentityRole("Client"));

			context.SaveChanges();
		}
	}
}
