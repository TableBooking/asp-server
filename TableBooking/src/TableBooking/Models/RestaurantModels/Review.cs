using System;

namespace TableBooking.Models.RestaurantModels
{
    public class Review
    {
		public int ReviewId { get; set; }

	    public string Author { get; set; }
		public string Text { get; set; }
	    public DateTime PostDate { get; set; }

		public int? RestaurantId { get; set; }
		public virtual Restaurant Restaurant {get; set; }
    }
}
