using TableBooking.Models.User;

namespace TableBooking.Models
{

    public class Restaurant
    {
	    public int RestaurantId { get; set; }
	    public string Name { get; set; }
		public string Location { get; set; }
	    public string Description { get; set; }
	    public string Cuisine { get; set; }

	    public int RestaurantAdministratorId { get; set; }
	    public RestaurantAdministrator RestaurantAdministrator { get; set; }
	}
}
