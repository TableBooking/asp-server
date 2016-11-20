using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TableBooking.Data;
using TableBooking.Models.User;
using TableBooking.Models.ViewModels;
using TableBooking.Services.RestaurantService;
using TableBooking.Services.UserService;

namespace TableBooking.Controllers
{
    public class RestaurantController : Controller
    {
		private ApplicationDbContext context;
	    private IUserAccountService accountService;
	    private IRestaurantService  restaurantService;

	    public RestaurantController(ApplicationDbContext context, IUserAccountService accountService, IRestaurantService restaurantService)
	    {
		    this.context = context;
		    this.accountService = accountService;
		    this.restaurantService = restaurantService;
	    }

		// GET: /Restaurant/Details/
		public async Task<IActionResult> Details(int? id) {
			if(id == null) return NotFound();

			var restaurant = await restaurantService.GetRestaurantAsync(id.GetValueOrDefault());

			if (restaurant == null) return NotFound();

			return View(restaurant);
		}

		// GET: /Restaurant/AdminDetails/
		[Authorize(Roles = "Administrator")]
	    public async Task<IActionResult> AdminDetails()
		{
			var user = await accountService.GetUserAsync(HttpContext);
			var restaurant = await restaurantService.GetRestaurantAsync(user);
			
			if(restaurant == null) return NotFound();

		    return View(restaurant);
	    }

		// GET: /Restaurant/Create/
		[Authorize(Roles = "Administrator")]
		public IActionResult Create()
		{
			return View();
		}

		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Create(RestaurantViewModel model)
	    {
		    var admin = await accountService.GetUserAsync(HttpContext) as RestaurantAdministrator;

		    if (admin?.RestaurantId != null) return Forbid();

		    if (ModelState.IsValid)
		    {
			    await restaurantService.CreateRestaurant(admin, model);
			    return RedirectToAction("AdminDetails");
		    }

		    return View(model);
	    }
	
		// GET: Restaurant/Edit/
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit() 
		{
			var user = await accountService.GetUserAsync(HttpContext);
			var restaurant = await restaurantService.GetRestaurantAsync(user);

			return View(restaurant);
		}

		// POST: Restaurant/Edit/{restaurant}
		[HttpPost]
		[Authorize(Roles = "Administrator")]
		public async Task<IActionResult> Edit(RestaurantViewModel model)
		{
			var user = await accountService.GetUserAsync(HttpContext);

			if (ModelState.IsValid) 
			{
				var result = await restaurantService.EditRestaurantAsync(user as RestaurantAdministrator, model);
				if (result) RedirectToAction("AdminDetails");
			}

			var restaurant = restaurantService.GetRestaurantAsync(user);
			return View(restaurant);
		}
    }
}
