using System.Threading.Tasks;
using TableBooking.Models.RestaurantModels;
using TableBooking.Models.User;
using TableBooking.Models.ViewModels;

namespace TableBooking.Services.RestaurantService
{
    public interface IRestaurantService
    {
	    Task<bool> RegisterAsync(Restaurant restaurant);
	    Task<Restaurant> GetRestaurantAsync(ApplicationUser user);
	    Task<Restaurant> GetRestaurantAsync(int id);
	    Task CreateRestaurant(RestaurantAdministrator admin, RestaurantViewModel model);
		Task<bool> EditRestaurantAsync(RestaurantAdministrator admin, RestaurantViewModel viewModel );
    }
}
