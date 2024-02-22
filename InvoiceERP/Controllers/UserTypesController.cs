using Microsoft.AspNetCore.Mvc;
using InvoiceERP.IRepositories;
using InvoiceERP.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;

using InvoiceERP.IFilters;
using Microsoft.AspNetCore.Authorization;

namespace InvoiceERP.Controllers
{
    
    [Route("UserTypes")]
    public class UserTypesController : Controller
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypesController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        // GET: UserType
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var userTypes = await _userTypeService.GetAllUserTypes();
                return View(userTypes);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error retrieving user types");
            }
        }

        // GET: UserTypes/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tblUserType = await _userTypeService.GetUserTypeById(id.Value);
                if (tblUserType == null)
                {
                    return NotFound();
                }

                return View(tblUserType);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error retrieving user type details");
            }
        }

        // GET: UserTypes/Creat
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTypes/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTypeId,UserType")] TblUserType tblUserType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userTypeService.CreateUserType(tblUserType);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return Problem(detail: ex.Message, statusCode: 500, title: "Error creating user type");
                }
            }
            return View(tblUserType);
        }

        // GET: UserTypes/Edit/
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tblUserType = await _userTypeService.GetUserTypeById(id.Value);
                if (tblUserType == null)
                {
                    return NotFound();
                }

                return View(tblUserType);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error retrieving user type for editing");
            }
        }

        // POST: UserTypes/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserTypeId,UserType")] TblUserType tblUserType)
        {
            if (id != tblUserType.UserTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _userTypeService.UpdateUserType(tblUserType);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return Problem(detail: ex.Message, statusCode: 500, title: "Error updating user type");
                }
            }
            return View(tblUserType);
        }

        // GET: UserTypes/Delete/
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var tblUserType = await _userTypeService.GetUserTypeById(id.Value);
                if (tblUserType == null)
                {
                    return NotFound();
                }

                return View(tblUserType);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error retrieving user type for deletion");
            }
        }

        // POST: UserTypes/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete"),]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _userTypeService.DeleteUserType(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: 500, title: "Error deleting user type");
            }
        }
    }
}
