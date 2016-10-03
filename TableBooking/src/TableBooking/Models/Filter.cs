using System;

namespace TableBooking.Models
{
	public class Filter
	{
		public string Address { private get; set; }
		public string Name { private get; set; }
		public string Cuisine { private get; set; }

		public int? NumPerson { private get; set; }
		public DateTime? DateTime { private get; set; }

		public bool RestaurantPredicate(Restaurant restaurant)
		{
			var result = true;
			result &= restaurant.Location.Contains(Address ?? "");
			result &= restaurant.Name.Contains(Name ?? "");
			result &= restaurant.Cuisine.Contains(Cuisine ?? "");
			return result;
		}

		public bool TablePredicate(Table table)
		{
			var result = true;
			if (NumPerson != null)
			{
				result &= NumPerson <= table.MaxPeson;
			}
			if (DateTime != null)
			{
				// Date for table booking check
			}
			return result;
		}
	}
}