using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TableBooking.Models.AccountViewModels;

namespace TableBooking.Services.UserService
{
	public class DefaultUserAccountService : IUserAccountService
	{
		private UserManager<IdentityUser> _userManager;
		private SignInManager<IdentityUser> _signInManager;

		public DefaultUserAccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public async Task<bool> RegisterUserAsync(RegisterViewModel model)
		{
			var user = new IdentityUser { UserName = model.Login, Email = model.Email };
			var result = await _userManager.CreateAsync(user, model.Password);

			return result.Succeeded;
		}

		public async Task<bool> RegisterAdminAsync(RegisterRestaurantViewModel model)
		{

			var admin = new IdentityUser {UserName = model.Login, Email = model.Email };
			var registered = await _userManager.CreateAsync(admin, model.Password);
			var promoted = await _userManager.AddToRoleAsync(admin, model.Password);

			return registered.Succeeded && promoted.Succeeded;
		}

		public async Task<bool> SignInAsync(LoginViewModel model)
		{
			var result =
				await _signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, lockoutOnFailure: false);

			return result.Succeeded;
		}
	}
}