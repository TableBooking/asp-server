using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TableBooking.Models
{
	public class User : IdentityUser
	{
		public int Year { get; set; }
	}
}