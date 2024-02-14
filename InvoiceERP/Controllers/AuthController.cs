using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using InvoiceERP.IRepositories;
using InvoiceERP.Models;
using System.Security.Claims;
using InvoiceERP.IServices;
using System.Text;

namespace InvoiceERP.Controllers
{ 
    
    public class AuthController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IJwtService _jwtService;

        public AuthController(ILoginService loginService, IJwtService jwtService)
        {
            _loginService = loginService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    // Invalid input, return to login page with error message
                    ViewBag.ErrorMessage = "Username and password are required.";
                    return View();
                }

                // Validate user credentials
                if (await _loginService.ValidateUser(username, password))
                {
                    // Fetch the user from the database
                    var user = await _loginService.GetUserByUsername(username);

                    if (user != null)
                    {
                        // Generate JWT token claims
                        var claims = _jwtService.GenerateTokenClaims(user);

                        // Set claims to session
                        foreach (var claim in claims)
                        {
                            HttpContext.Session.Set(claim.Type, Encoding.UTF8.GetBytes(claim.Value));
                        }

                        return RedirectToAction("Index", "Home"); // Change this to your actual dashboard/home page
                    }
                    else
                    {
                        // User not found, return to login page with error message
                        ViewBag.UserNotFoundMessage = "User not found.";
                        return View();
                    }
                }
                else
                {
                    // Authentication failed, return to login page with error message
                    ViewBag.InvalidCredentialsMessage = "Invalid username or password.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                // You can also redirect to an error page and display a generic error message
                ViewBag.GErrorMessage = ex + "An error occurred while processing your request.";
                return View();
            }
        }
    }
}
