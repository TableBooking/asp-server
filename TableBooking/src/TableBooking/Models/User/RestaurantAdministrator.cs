using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TableBooking.Models.User
{
    public class RestaurantAdministrator : IdentityUser
    {
	    public int RestaurantId { get; set; }
	    public Restaurant Restaurant { get; set; }
    }
}
