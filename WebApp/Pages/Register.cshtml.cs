using CoreLogic.Model;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApp.Pages;

public class RegisterModel : PageModel
{
    [BindProperty]
    public string FullName { get; set; }

    [BindProperty]
    public string UserName { get; set; }

    [BindProperty]
    public string Password { get; set; }

    [BindProperty]
    public string ConfirmPassword { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Here you can validate the user credentials against your database
        // Check if the user already exists in your database.
        UserService userService = new UserService();
        var existingUser = userService.Get(UserName);

        if (existingUser != null)
        {
            // User with the given username already exists.
            ModelState.AddModelError(string.Empty, "Username already taken.");
            return Page();
        }

        if (Password != ConfirmPassword)
        {
            // Passwords don't match.
            ModelState.AddModelError(string.Empty, "Passwords do not match.");
            return Page();
        }

        // User has provided valid credentials. Proceed with your registration process...
        User newUser = new User
        {
            Name = FullName,
            UserName = UserName,
            Password = Password
        };
        userService.Register(newUser);

       await SignInUser();

        return RedirectToPage("/Login");
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

