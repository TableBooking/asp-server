using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableBooking.Data;
using TableBooking.Models;
using TableBooking.Models.User;


namespace TableBooking.Controllers
{
    public class SearchController : Controller
    {

	    private ApplicationDbContext context;

	    public SearchController(ApplicationDbContext context)
	    {
		    this.context = context;
	    }

	    public IActionResult Index()
        {
            return View();
        }

	    public IActionResult SearchRestaurant(Filter filter)
	    {
		    var restaurants = context.Restaurants.Where(r => filter.Apply(r))
												.Include(r => r.Tables)
												.AsNoTracking()
												.Where(r => r.Tables.Any(filter.Apply));
			if(!restaurants.Any())
				return NotFound();

		    return View(restaurants);
	    }
    }
}
