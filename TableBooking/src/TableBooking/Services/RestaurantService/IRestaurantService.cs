using System.Threading.Tasks;
using TableBooking.Models;

namespace TableBooking.Services.RestaurantService
{
    public interface IRestaurantService
    {
	    Task<bool> RegisterAsync(Restaurant restaurant);
    }
}
