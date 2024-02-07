using InvoiceERP.iDbContext;
using InvoiceERP.IRepositories;
using InvoiceERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceERP.IServices
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IDataContext _context;

        public UserTypeService(IDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TblUserType>> GetAllUserTypes()
        {
            return await _context.TblUserTypes.ToListAsync();
        }

        public async Task<TblUserType> GetUserTypeById(int id)
        {
            return await _context.TblUserTypes.FindAsync(id)
                ?? throw new Exception("User type not found.");
        }

        public async Task CreateUserType(TblUserType userType)
        {
            if (userType == null)
            {
                throw new ArgumentNullException(nameof(userType));
            }
            _context.TblUserTypes.Add(userType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserType(TblUserType userType)
        {
            if (userType == null)
            {
                throw new ArgumentNullException(nameof(userType));
            }
            _context.Entry(userType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserType(int id)
        {
            var userType = await _context.TblUserTypes.FindAsync(id);
            if (userType != null)
            {
                _context.TblUserTypes.Remove(userType);
                await _context.SaveChangesAsync();
            }
        }
    }
}