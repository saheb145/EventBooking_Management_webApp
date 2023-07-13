using CoreLogic;
using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.EventPages;

    /*public class IndexModel : PageModel
    {
        public void OnGet()
	{
        }*/
	[Authorize]
	public class IndexModel : PageModel
	{
		BookEventService service;
		public List<BookEvent> bookEvents { get; set; }
		public void OnGet()
		{
			service = new BookEventService();
			var userService = new UserService();
			bookEvents = service.GetAllEventDetails();

			//var username = userService.GetUserById((int)bookEvents.UserId);
		}

	public IActionResult OnPostDelete(int eventId)
	{
		service = new BookEventService();
		service.DeleteEvent(eventId);

		return RedirectToPage();
	}

}

