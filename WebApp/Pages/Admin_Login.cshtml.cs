using CoreLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApp.Pages;

public class Admin_LoginModel : PageModel
{
    [BindProperty]
    public string UserName { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Here you can validate the user credentials against your database
        // Retrieve the user from your database.
        AdminService adminService = new AdminService();
        var admin = adminService.Get(UserName);

        if (admin == null)
        {
            // User with the given username doesn't exist.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        if (Password != admin.Password)
        {
            // Passwords don't match.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        // User has provided valid credentials. Proceed with your login process...
       await SignInAdmin();

        return RedirectToPage("EventPages/Index");
    }

    private async Task SignInAdmin()
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

