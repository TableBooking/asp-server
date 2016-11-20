using TableBooking.Models.User;

namespace TableBooking.Models.RestaurantModels
{
    public class Booking
    {
	    public int BookingId { get; set; }

	    public string Code { get; set; }
		public int PeopleCount { get; set; }
		public bool Activated { get; set; }

		public int? ClientId { get; set; }
		public virtual Client Client { get; set; }

		public int? TableId { get; set; }
		public virtual Table Table { get; set; }

	    public int? RestaurantId { get; set; }
	    public virtual Restaurant Restaurant { get; set; }
    }
}
