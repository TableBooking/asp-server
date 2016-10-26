using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TableBooking.Models;
using TableBooking.Models.AccountViewModels;
using TableBooking.Services.RestaurantService;
using TableBooking.Services.UserService;

namespace TableBooking.Controllers
{
	public class AccountController : Controller
	{
		private IUserAccountService _userAccountService;
		private IRestaurantService _restaurantService;

		public AccountController(IRestaurantService restaurantService, IUserAccountService userAccountService)
		{
			_restaurantService = restaurantService;
			_userAccountService = userAccountService;
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
				var result = await _userAccountService.RegisterUserAsync(model);

				if (result)
				{
					return RedirectToAction(nameof(HomeController.Index), "Home");
				}
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

				var userRegistration = _userAccountService.RegisterAdminAsync(model);
				var restaurantRegistration = _restaurantService.RegisterAsync(restaurant);

				if (await userRegistration && await restaurantRegistration)
				{
					return RedirectToAction(nameof(HomeController.Index), "Home");
				}
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
				var result = await _userAccountService.SignInAsync(model);
				if (result)
				{
					return RedirectToAction(nameof(HomeController.Index), "Home");
				}
			}
			
			return View(model);
		}
	}
}