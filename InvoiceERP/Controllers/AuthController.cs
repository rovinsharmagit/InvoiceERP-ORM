using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using InvoiceERP.IRepositories;
using InvoiceERP.IServices;
using InvoiceERP.Models;

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
                            HttpContext.Session.SetString(claim.Type, claim.Value);
                        }
                        
                        // Generate token
                        var token = _jwtService.GenerateToken(user);

                        // Set token to session
                        HttpContext.Session.SetString("Token", token);

                        //Get token creation time
                        DateTime? IssuedAt = null;
                        //Get token creation time
                        if (!string.IsNullOrEmpty(token))
                        {
                            IssuedAt = _jwtService.GetTokenIssueTime(token);
                            if (IssuedAt.HasValue)
                            {
                                HttpContext.Session.SetString("SessionCreatedAt", IssuedAt.Value.ToString());
                            }
                        }

                        // Get token expiration time
                        DateTime? expiresAt = null;
                        // Get token expiration time
                        if (!string.IsNullOrEmpty(token))
                        {
                            expiresAt = _jwtService.GetTokenExpirationTime(token);
                            if (expiresAt.HasValue)
                            {
                                HttpContext.Session.SetString("SessionExpiresAt", expiresAt.Value.ToString());
                            }
                        }

                        return RedirectToAction("TokenInfo");
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

        [AcceptVerbs("GET", "POST")]
        public IActionResult TokenInfo()
        {
            // Get token from session
            var token = HttpContext.Session.GetString("Token");

            // Generate token claims from session
            var claims = new List<Claim>();
            foreach (var key in HttpContext.Session.Keys)
            {
                var value = HttpContext.Session.GetString(key);
                if (!string.IsNullOrEmpty(value))
                {
                    claims.Add(new Claim(key, value));
                }
            }

            // Get token expiration time
            DateTime? expiresAt = null;
            // Get token expiration time
            if (!string.IsNullOrEmpty(token))
            {
                expiresAt = _jwtService.GetTokenExpirationTime(token);
                if (expiresAt.HasValue)
                {
                    HttpContext.Session.SetString("SessionExpiresAt", expiresAt.Value.ToString());
                }
            }

            //Get token creation time
            DateTime? IssuedAt = null;
            //Get token creation time
            if (!string.IsNullOrEmpty(token))
            {
                IssuedAt = _jwtService.GetTokenIssueTime(token);
                if (IssuedAt.HasValue)
                {
                    HttpContext.Session.SetString("SessionCreatedAt", IssuedAt.Value.ToString());
                }
            }
            // Set token IIssuueedd time to session
            if (IssuedAt.HasValue)
            {
                HttpContext.Session.SetString("SessionCreatedAt", IssuedAt.Value.ToString());

                // Set token information to ViewBag for display
                
                ViewBag.IssuedAt = IssuedAt.Value; // Issued at time is the current time
            }

            // Set token expiration time to session
            if (expiresAt.HasValue)
            {
                HttpContext.Session.SetString("SessionExpiration", expiresAt.Value.ToString());

                // Set token information to ViewBag for display
                ViewBag.Token = token;
                ViewBag.Claims = claims;
                ViewBag.ExpiresAt = expiresAt.Value;
            }

            return View("~/Views/Token/TokenInfo.cshtml");
        }

        [HttpPost("AcceptSession")]
        [ValidateAntiForgeryToken]
        public IActionResult AcceptSession()
        {
            
            // Perform any actions needed when the session is accepted
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("RejectSession")]
        public IActionResult RejectSession()
        {
            // Perform any actions needed when the session is rejected
            return RedirectToAction("Login");
        }
    }
}
