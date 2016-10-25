using System;
using System.Collections.Generic;

namespace TableBooking.Models
{
	public class Table
	{
		public int TableId { get; set; }
		public int MaxPeson { get; set; }
		public ICollection<DateTime> Schedule { get; set; }

		public int RestaurantId { get; set; }
		public Restaurant Restaurant { get; set; }
	}
}