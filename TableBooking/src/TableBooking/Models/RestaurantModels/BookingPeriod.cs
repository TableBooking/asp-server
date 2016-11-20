using System;

namespace TableBooking.Models.RestaurantModels
{
    public class BookingPeriod
    {
	    public int BookingPeriodId { get; set; }

	    public DateTime Start { get; set; }
	    public DateTime End { get; set; }

		public int? TableId { get; set; }
		public virtual Table Table { get; set; }
	}
}
