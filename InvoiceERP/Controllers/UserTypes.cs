using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InvoiceERP.Models;
using InvoiceERP.iDbContext;

namespace InvoiceERP.Controllers
{
    public class UserTypes : Controller
    {
        private readonly IDataContext _context;

        public UserTypes(IDataContext context)
        {
            _context = context;
        }

        // GET: UserTypes
        public async Task<IActionResult> Index()
        {
              return _context.TblUserTypes != null ? 
                          View(await _context.TblUserTypes.ToListAsync()) :
                          Problem("Entity set 'IDataContext.TblUserTypes'  is null.");
        }

        // GET: UserTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblUserTypes == null)
            {
                return NotFound();
            }

            var tblUserType = await _context.TblUserTypes
                .FirstOrDefaultAsync(m => m.UserTypeId == id);
            if (tblUserType == null)
            {
                return NotFound();
            }

            return View(tblUserType);
        }

        // GET: UserTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTypeId,UserType")] TblUserType tblUserType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblUserType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblUserType);
        }

        // GET: UserTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblUserTypes == null)
            {
                return NotFound();
            }

            var tblUserType = await _context.TblUserTypes.FindAsync(id);
            if (tblUserType == null)
            {
                return NotFound();
            }
            return View(tblUserType);
        }

        // POST: UserTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
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
                    _context.Update(tblUserType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblUserTypeExists(tblUserType.UserTypeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblUserType);
        }

        // GET: UserTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblUserTypes == null)
            {
                return NotFound();
            }

            var tblUserType = await _context.TblUserTypes
                .FirstOrDefaultAsync(m => m.UserTypeId == id);
            if (tblUserType == null)
            {
                return NotFound();
            }

            return View(tblUserType);
        }

        // POST: UserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblUserTypes == null)
            {
                return Problem("Entity set 'IDataContext.TblUserTypes'  is null.");
            }
            var tblUserType = await _context.TblUserTypes.FindAsync(id);
            if (tblUserType != null)
            {
                _context.TblUserTypes.Remove(tblUserType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblUserTypeExists(int id)
        {
          return (_context.TblUserTypes?.Any(e => e.UserTypeId == id)).GetValueOrDefault();
        }
    }
}
