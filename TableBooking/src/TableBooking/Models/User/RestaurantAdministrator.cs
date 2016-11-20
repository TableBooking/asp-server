using TableBooking.Models.RestaurantModels;

namespace TableBooking.Models.User
{
    public class RestaurantAdministrator : ApplicationUser
    {
	    public int? RestaurantId { get; set; }
	    public virtual Restaurant Restaurant { get; set; }
    }
}
