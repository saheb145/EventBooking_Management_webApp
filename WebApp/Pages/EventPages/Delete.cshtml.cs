using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.EventPages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public BookEvent bookEvent { set; get; }


        public IActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();

            BookEventService bookEventService = new BookEventService();
            bookEvent = bookEventService.GetBookEvent(id.Value);

            return Page();
        }
        public IActionResult OnPost(int? id)
        {
            if (id == null) return NotFound();

            BookEventService bookEventService = new BookEventService();
            bookEventService.DeleteBookEvent(bookEvent);

            return Redirect("../Booked_Events");
        }
    }
}