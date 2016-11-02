using System.Threading.Tasks;
using TableBooking.Data;
using TableBooking.Models;

namespace TableBooking.Services.RestaurantService
{
    public class DefaultRestaurantService : IRestaurantService
    {
	    private ApplicationDbContext context;

	    public DefaultRestaurantService(ApplicationDbContext context)
	    {
		    this.context = context;
	    }

	    public async Task<bool> RegisterAsync(Restaurant restaurant)
	    {
		    context.Add(restaurant);
		    await context.SaveChangesAsync();

		    return true;
	    }
    }
}
