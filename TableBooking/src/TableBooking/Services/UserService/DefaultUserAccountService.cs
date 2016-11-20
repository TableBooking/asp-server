using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TableBooking.Models.User;
using TableBooking.Models.ViewModels.AccountViewModels;

namespace TableBooking.Services.UserService
{
	public class DefaultUserAccountService : IUserAccountService
	{
		private UserManager<ApplicationUser> userManager;
		private SignInManager<ApplicationUser> signInManager;

		public DefaultUserAccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		public async Task<bool> RegisterUserAsync(RegisterViewModel model)
		{
			var user = new ApplicationUser { UserName = model.Login, Email = model.Email };
			var result = await userManager.CreateAsync(user, model.Password);

			return result.Succeeded;
		}

		public async Task<bool> RegisterAdminAsync(RegisterRestaurantViewModel model)
		{

			var admin = new ApplicationUser {UserName = model.Login, Email = model.Email };
			var registered = await userManager.CreateAsync(admin, model.Password);
			var promoted = await userManager.AddToRoleAsync(admin, "Administrator");

			return registered.Succeeded && promoted.Succeeded;
		}

		public async Task<bool> SignInAsync(LoginViewModel model)
		{
			var result =
				await signInManager.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, lockoutOnFailure: false);

			return result.Succeeded;
		}

		public async Task<ApplicationUser> GetUserAsync(HttpContext httpContext)
		{
			return await userManager.GetUserAsync(httpContext.User);
		}
	}
}