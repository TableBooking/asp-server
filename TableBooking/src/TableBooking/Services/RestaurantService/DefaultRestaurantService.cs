using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TableBooking.Data;
using TableBooking.Models.RestaurantModels;
using TableBooking.Models.User;
using TableBooking.Models.ViewModels;

namespace TableBooking.Services.RestaurantService
{
    public class DefaultRestaurantService : IRestaurantService
    {
	    private ApplicationDbContext context;
	    private IHostingEnvironment environment;

	    public DefaultRestaurantService(ApplicationDbContext context, IHostingEnvironment environment)
	    {
		    this.context = context;
		    this.environment = environment;
	    }

	    public async Task<bool> RegisterAsync(Restaurant restaurant)
	    {
		    context.Add(restaurant);
		    await context.SaveChangesAsync();

		    return true;
	    }

	    public async Task<Restaurant> GetRestaurantAsync(ApplicationUser user)
	    {
		    var admin = user as RestaurantAdministrator;
		    if (admin?.RestaurantId == null) return null;

		    return await context.Restaurants.AsNoTracking().SingleOrDefaultAsync(r => r.RestaurantId == admin.RestaurantId);
	    }

	    public async Task<Restaurant> GetRestaurantAsync(int id)
	    {
			return await context.Restaurants.AsNoTracking().SingleOrDefaultAsync(r => r.RestaurantId == id);
		}

	    public async Task CreateRestaurant(RestaurantAdministrator admin, RestaurantViewModel model)
	    {
		    var restaurant = new Restaurant
		    {
			    RestaurantAdministratorId = int.Parse(admin.Id),
			    RestaurantAdministrator = admin
		    };

			CopyRestaurantModel(restaurant, model);
		    context.Add(restaurant);
		    await context.SaveChangesAsync();
	    }

	    public async Task<bool> EditRestaurantAsync(RestaurantAdministrator admin, RestaurantViewModel viewModel)
	    {
			if (admin == null) return false;

			var restaurant = await context.Restaurants.SingleOrDefaultAsync(r => r.RestaurantId == admin.RestaurantId);

			CopyRestaurantModel(restaurant, viewModel);
			context.Update(restaurant);
			await context.SaveChangesAsync();

			CopyImage(restaurant.ImagePath, viewModel.ImageUpload);

			return true;
	    }

	    private async void CopyImage(string fileName, IFormFile image)
	    {
			var uploads = Path.Combine(environment.WebRootPath, "uploads");
			if (image != null && image.Length > 0)
			{
				using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create)) 
				{
					await image.CopyToAsync(fileStream);
				}
			}
		}

		private static void CopyRestaurantModel(Restaurant restaurant, RestaurantViewModel viewModel) {
			restaurant.Name = viewModel.Name;
			restaurant.Description = viewModel.Description;
			restaurant.Location = viewModel.Location;
			restaurant.Cuisine = viewModel.Cuisine;
			restaurant.PhoneNumber = viewModel.PhoneNumber;
		}
	}
}
