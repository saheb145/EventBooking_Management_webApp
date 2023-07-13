using CoreLogic.Model;
using CoreLogic.Services;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
	public class Booked_EventsModel : PageModel
	{
		BookEventService service;
		public List<BookEvent> bookEvents { get; set; }

		public IActionResult OnGet()
		{
			UserService userService = new UserService();
			// string username = userService.name;

			var loggedInUserName = HttpContext.Session.GetString("LoggedInUserName");
			 var userId = userService.GetUserId(loggedInUserName);

			if (userId == null) return NotFound();

			BookEventService bookEventService = new BookEventService();
			bookEvents = bookEventService.GetEventByUid(userId);



			return Page();
		}


	}

}