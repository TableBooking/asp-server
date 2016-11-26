using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TableBooking.Features
{
	public static class ControllerExtension
	{

		private static bool IsMobileRequest(HttpRequest request)
		{
			return request.Headers["User-Agent"].ToString().Contains("Mobile");
		}

		public static IActionResult AdaptiveResult(this Controller controller, object model)
		{
			if (!IsMobileRequest(controller.Request))
			{
				return controller.View(model);
			}

			return new JsonResult(model);
		}
	}
}