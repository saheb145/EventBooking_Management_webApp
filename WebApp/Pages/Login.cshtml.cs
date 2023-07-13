using CoreLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WebApp.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string UserName { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Here you can validate the user credentials against your database
        // Retrieve the user from your database.
        UserService userService = new UserService();
        var user = userService.Get(UserName);

        if (user == null)
        {
            // User with the given username doesn't exist.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        if (Password != user.Password)
        {
            // Passwords don't match.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        // User has provided valid credentials. Proceed with your login process...
        await SignInUser();

        // Store the username in session
        HttpContext.Session.SetString("LoggedInUserName", user.UserName);

        // Retrieve the stored username from the session
        var loggedInUserName = HttpContext.Session.GetString("LoggedInUserName");
       

        return RedirectToPage("Index");
    }



	private async Task SignInUser()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, UserName)
        };

        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

        var authProperties = new AuthenticationProperties();

        await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

    }
}

