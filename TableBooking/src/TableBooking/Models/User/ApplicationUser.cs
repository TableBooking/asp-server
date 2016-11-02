using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TableBooking.Models.User
{
    public class ApplicationUser : IdentityUser
    {
	    public string ImagePath { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
    }
}
