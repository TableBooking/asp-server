using System.ComponentModel.DataAnnotations;

namespace TableBooking.Models.ViewModels.AccountViewModels
{
	public class RegisterRestaurantViewModel : RegisterViewModel
	{
		[Required]
		[Display(Name = "Restaurant Name")]
		public string RestaurantName { get; set; }
	}
}