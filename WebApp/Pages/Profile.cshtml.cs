using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreLogic.Data;
using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;


namespace WebApp.Pages
{
    public class ProfileModel : PageModel
    {
        /*public int userId;
        string loggedInUserName;
        public User users { get; set; } = default!;
        public IActionResult OnPost()
        {

            UserService userService = new UserService();
            // string username = userService.name;

            loggedInUserName = HttpContext.Session.GetString("LoggedInUserName");
            userId = userService.GetUserId(loggedInUserName);

            return RedirectToPage("./Index");
        }



        public IActionResult OnGet(int? userId)
        {

            if (userId == null) return NotFound();

            UserService userService = new UserService();
            users = userService.GetUserById(userId.Value);

            if (users == null) return NotFound();

            return Page();
        }*/

    }
}
