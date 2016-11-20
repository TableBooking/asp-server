using Microsoft.AspNetCore.Http;

namespace TableBooking.Models.ViewModels
{
	public class RestaurantViewModel
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public string Cuisine { get; set; }
		public string PhoneNumber { get; set; }
		public IFormFile ImageUpload { get; set; }
	}
}