using System.ComponentModel.DataAnnotations;

namespace TableBooking.Models.AccountViewModels
{
	public class RegisterRestaurantViewModel : RegisterViewModel
	{
		[Required]
		[Display(Name = "Restaurant Name")]
		public string RestaurantName { get; set; }
	}
}