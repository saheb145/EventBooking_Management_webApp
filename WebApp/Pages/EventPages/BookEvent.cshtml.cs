using CoreLogic.Model;
using CoreLogic.Services;
using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Pages.Event;

namespace WebApp.Pages.EventPages;

public class BookEventModel : PageModel
{
    [BindProperty]
   public BookEvent BookEvent { get; set; }

	[BindProperty]
	public string EventType { get; set; }

	[BindProperty]
	public string Vanue { get; set; }

    [BindProperty]
    public int NoOfGuest { get; set; }

    [BindProperty]
    public DateTime Booking_date { get; set; }

    //public List<SelectListItem> CityOptions { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

  
    public IActionResult OnPost()
    {
        if ((!ModelState.IsValid || BookEvent == null) && User.Identity.IsAuthenticated)
        {
            UserService userService = new UserService();
           // string username = userService.name;
            var loggedInUserName = HttpContext.Session.GetString("LoggedInUserName");
         
            int userId = userService.GetUserId(loggedInUserName);

            BookEvent bookevent = new BookEvent
            {
                EventType = EventType,
                Venue = Vanue,
                NoofGuest = NoOfGuest,
                BookingDate = Booking_date,
                UserId = userId
               
              
            };
            BookEventService bookEventService = new BookEventService();
            bookEventService.AddBookEvent(bookevent);

            // BookEventService bookEventService = new BookEventService();
            // bookEventService.AddBookEvent(BookEvent);
        }
        /*else
        {
            return RedirectToPage("/Index");
        }*/

        return RedirectToPage("../Booked_Events");
    }

 
  /*  private void PopulateCitiesDropDown()
    {
       

        var BookEventService = new BookEventService();
        var cities = BookEventService.getCities();

        CityOptions = cities.Select(Vanue =>
                                  new SelectListItem
                                  {
                                      Value = Vanue.Id.ToString(),
                                      Text = Vanue.Venue
                                  }).ToList();
    }*/

    private IActionResult Pages(ModelStateDictionary modelState)
    {
        throw new NotImplementedException();
    }
}
