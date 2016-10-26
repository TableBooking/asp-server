using System.Threading.Tasks;
using TableBooking.Data;
using TableBooking.Models;

namespace TableBooking.Services.RestaurantService
{
    public class DefaultRestaurantService : IRestaurantService
    {
	    private RestaurantDbContext _context;

	    public DefaultRestaurantService(RestaurantDbContext context)
	    {
		    _context = context;
	    }

	    public async Task<bool> RegisterAsync(Restaurant restaurant)
	    {
		    _context.Add(restaurant);
		    await _context.SaveChangesAsync();

		    return true;
	    }
    }
}
