using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TableBooking.Models.AccountViewModels;

namespace TableBooking.Services.UserService
{
	public class DefaultUserAccountService : IUserAccountService
	{
		private UserManager<IdentityUser> userManager;
		private SignInManager<IdentityUser> signInManager;

		public DefaultUserAccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		public async Task<bool> RegisterUserAsync(RegisterViewModel model)
		{
			var user = new IdentityUser { UserName = model.Login, Email = model.Email };
			var result = await userManager.CreateAsync(user, model.Password);

			return result.Succeeded;
		}

		public async Task<bool> RegisterAdminAsync(RegisterRestaurantViewModel model)
		{

			var admin = new IdentityUser {UserName = model.Login, Email = model.Email };
			var registered = await userManager.CreateAsync(admin, model.Password);
			var promoted = await userManager.AddToRoleAsync(admin, model.Password);

			return registered.Succeeded && promoted.Succeeded;
		}

		public async Task<bool> SignInAsync(LoginViewModel model)
		{
			var result =
				await signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, lockoutOnFailure: false);

			return result.Succeeded;
		}
	}
}