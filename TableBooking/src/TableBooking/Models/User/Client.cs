using System.Collections.Generic;
using TableBooking.Models.RestaurantModels;

namespace TableBooking.Models.User
{
    public class Client : ApplicationUser
    {
	    public virtual ICollection<Booking> Bookings { get; set; }
    }
}
