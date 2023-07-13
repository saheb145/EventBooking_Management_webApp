using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Pages.EventPages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private BookEventService bookeventservice;
        [BindProperty]
        public BookEvent BookEvent { get; set; }
        public EditModel()
        {
            bookeventservice = new BookEventService();
        }
        public IActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();
            BookEvent = bookeventservice.GetBookEvent(id.Value);
            if (BookEvent == null) return NotFound();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState != null)
            {
                bookeventservice.UpdateEvent(BookEvent);
                return Redirect("../Booked_Events");

            }
            return Page();


        }

    }
}