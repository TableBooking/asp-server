using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TableBooking.Models.User;
using TableBooking.Models.ViewModels.AccountViewModels;

namespace TableBooking.Services.UserService
{
    public interface IUserAccountService
    {
	    Task<bool> RegisterUserAsync(RegisterViewModel model);
		Task<bool> RegisterAdminAsync(RegisterRestaurantViewModel model);
	    Task<bool> SignInAsync(LoginViewModel model);
	    Task<ApplicationUser> GetUserAsync(HttpContext context);
    }
}
