using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TableBooking.Models.RestaurantModels;
using TableBooking.Models.ViewModels.AccountViewModels;
using TableBooking.Services.RestaurantService;
using TableBooking.Services.UserService;

namespace TableBooking.Controllers
{
	public class AccountController : Controller
	{
		private IUserAccountService userAccountService;
		private IRestaurantService restaurantService;
		private ILogger logger;

		public AccountController(IRestaurantService restaurantService, IUserAccountService userAccountService, ILoggerFactory loggerFactory)
		{
			this.restaurantService = restaurantService;
			this.userAccountService = userAccountService;
			this.logger = loggerFactory.CreateLogger<AccountController>();
		}

		// GET: /Account/Register
		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register()
		{
			return View();
		}

		// GET: /Account/RegisterRestaurant
		[HttpGet]
		[AllowAnonymous]
		public IActionResult RegisterRestaurant()
		{
			return View();
		}

		// GET: /Account/Login
		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login()
		{
			return View();
		}

		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await userAccountService.RegisterUserAsync(model);

				if (result)
				{
					logger.LogInformation($"User <{model.Login}> has been successfully registered.");
					return RedirectToAction(nameof(HomeController.Index), "Home");
				}
				logger.LogError($"Something bad has occured during registration of user <{model.Login}>.");
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		// POST: /Account/Register
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> RegisterRestaurant(RegisterRestaurantViewModel model)
		{
			if (ModelState.IsValid)
			{
				var restaurant = new Restaurant {Name = model.RestaurantName};

				var userRegistration = userAccountService.RegisterAdminAsync(model);
				var restaurantRegistration = restaurantService.RegisterAsync(restaurant);

				if (await userRegistration && await restaurantRegistration)
				{
					logger.LogInformation($"Restaurant {model.RestaurantName} has been successfully registered.");
					return RedirectToAction(nameof(HomeController.Index), "Home");
				}
				logger.LogError($"Something bad has occured during registration of restaurant <{model.RestaurantName}>.");
			}

			return View(model);
		}

		// POST: /Account/Login
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await userAccountService.SignInAsync(model);
				if (result)
				{
					logger.LogInformation($"User {model.Login} has successfully signed in.");
					return RedirectToAction(nameof(HomeController.Index), "Home");
				}
				logger.LogError($"Something bad has occured during signing up of user <{model.Login}>.");
			}
			
			return View(model);
		}
	}
}