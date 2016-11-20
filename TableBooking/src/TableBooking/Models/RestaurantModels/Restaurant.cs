using System.Collections.Generic;
using TableBooking.Models.User;

namespace TableBooking.Models.RestaurantModels
{

    public class Restaurant
    {
	    public int RestaurantId { get; set; }
	    public string Name { get; set; }
		public string Location { get; set; }
	    public string Description { get; set; }
		public float Rating { get; set; }
	    public string Cuisine { get; set; }
		public string PhoneNumber { get; set; }

		public string ImagePath { get; set; }

		public virtual ICollection<Table> Tables { get; set; }

		public virtual ICollection<Review> Reviews { get; set; }

		public virtual ICollection<Booking> Bookings { get; set; }

	    public int RestaurantAdministratorId { get; set; }
	    public virtual RestaurantAdministrator RestaurantAdministrator { get; set; }
	}
}
