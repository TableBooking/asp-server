using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TableBooking.Models.AccountViewModels;

namespace TableBooking.Services.UserService
{
    public interface IUserAccountService
    {
	    Task<bool> RegisterUserAsync(RegisterViewModel model);
		Task<bool> RegisterAdminAsync(RegisterRestaurantViewModel model);
	    Task<bool> SignInAsync(LoginViewModel model);
    }
}
