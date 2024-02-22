using System;
using System.Threading.Tasks;
using InvoiceERP.IRepositories;
using InvoiceERP.Models;
using InvoiceERP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace InvoiceERP.Controllers
{
    
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return View(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving users.");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving details for user with ID {UserId}.", id);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewData["UserTypeId"] = _userService.GetUserTypesSelectList();
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTypeId,FullName,Email,ContactNo,UserName,Password,IsActive")] TblUser user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool created = await _userService.CreateUserAsync(user);
                    if (created)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError(string.Empty, "Email, Phone number, or username is already in use.");
                }
                ViewData["UserTypeId"] = _userService.GetUserTypesSelectList();
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the user.");
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                ViewData["UserTypeId"] = _userService.GetUserTypesSelectList();
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving details for user with ID {UserId}.", id);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserTypeId,FullName,Email,ContactNo,UserName,Password,IsActive")] TblUser user)
        {
            try
            {
                if (id != user.UserId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    bool updated = await _userService.UpdateUserAsync(id, user);
                    if (updated)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    return NotFound();
                }
                ViewData["UserTypeId"] = _userService.GetUserTypesSelectList();
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating user with ID {UserId}.", id);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving details for user with ID {UserId}.", id);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost("Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                bool deleted = await _userService.DeleteUserAsync(id);
                if (deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting user with ID {UserId}.", id);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
