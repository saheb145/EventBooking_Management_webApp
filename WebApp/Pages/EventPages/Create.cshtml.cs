using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Event;

    public class CreateModel : PageModel
    {
        [BindProperty]
        public BookEvent BookEvent{ get; set; }

       // UserService userService = new UserService();
        //public User User { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || BookEvent== null)
            {
				BookEventService bookEventService = new BookEventService();
             //   BookEvent.UserId = userService.GetUserById(BookEvent.UserId);   
				bookEventService.AddBookEvent(BookEvent);
			}
            
            return RedirectToPage("./Index");
        }

        private IActionResult Pages(ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }

