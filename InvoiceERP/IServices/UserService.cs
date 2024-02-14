using InvoiceERP.Models;
using InvoiceERP.iDbContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using InvoiceERP.IRepositories;

namespace InvoiceERP.Services
{
    public class UserService : IUserService
    {
        private readonly IDataContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(IDataContext context, ILogger<UserService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<TblUser>> GetAllUsersAsync()
        {
            return await _context.TblUsers.Include(u => u.UserType).ToListAsync();
        }

        public async Task<TblUser> GetUserByIdAsync(int id)
        {
            var user = await _context.TblUsers.Include(u => u.UserType).FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            return user;
        }

        public async Task<bool> CreateUserAsync(TblUser user)
        {
            try
            {
                bool isUnique = !_context.TblUsers.Any(u =>
                u.Email == user.Email ||
                u.ContactNo == user.ContactNo ||
                u.UserName == user.UserName);
                if (!isUnique)
                {
                    return false;
                }

                user.Password = HashPassword(user.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the user.");
                return false;
            }
        }

        public async Task<bool> UpdateUserAsync(int id, TblUser user)
        {
            if (id != user.UserId)
            {
                return false;
            }

            try
            {    // Encrypt the password before updating the user
                user.Password = HashPassword(user.Password);
                _context.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user.");
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                var user = await _context.TblUsers.FindAsync(id);
                if (user == null)
                {
                    return false;
                }

                _context.TblUsers.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the user.");
                return false;
            }
        }

        public SelectList GetUserTypesSelectList()
        {
            return new SelectList(_context.TblUserTypes, "UserTypeId", "UserType");
        }

        private static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}
