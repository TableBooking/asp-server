using System.Collections.Generic;

namespace TableBooking.Models.RestaurantModels
{
	public class Table
	{
		public int TableId { get; set; }
		public int MaxPeson { get; set; }

		public virtual ICollection<BookingPeriod> Schedule { get; set; }

		public virtual ICollection<Booking> Bookings { get; set; }

		public int RestaurantId { get; set; }
		public virtual Restaurant Restaurant { get; set; }
	}
}