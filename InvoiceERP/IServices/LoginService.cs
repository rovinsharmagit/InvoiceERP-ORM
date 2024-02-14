using InvoiceERP.iDbContext;
using InvoiceERP.IRepositories;
using InvoiceERP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace InvoiceERP.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDataContext _context;
        private readonly ILogger<LoginService> _logger;

        public LoginService(IDataContext context, ILogger<LoginService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> ValidateUser(string username, string password)
        {
            try
            {
                // Find the user by username
                var user = await _context.TblUsers.SingleOrDefaultAsync(u => u.UserName == username);

                if (user == null)
                {
                    // User not found
                    return false;
                }

                // Verify the hashed password
                if (VerifyHashedPassword(user.Password, password))
                {
                    // Password matches
                    return true;
                }
                else
                {
                    // Password does not match
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while validating the user.");
                return false; // Return false in case of an exception
            }
        }

        private static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            // Convert the hashed password from Base64 string back to byte array
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Extract the salt from the first 16 bytes of the hashBytes
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Compute the hash of the provided password using the same salt
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256))
            {
                byte[] computedHash = pbkdf2.GetBytes(20);

                // Compare the computed hash with the stored hashBytes
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != computedHash[i])
                    {
                        // Hashes do not match
                        return false;
                    }
                }
            }

            // Hashes match
            return true;
        }

        public async Task<TblUser?> GetUserByUsername(string username)
        {
            try
            {
                return await _context.TblUsers.SingleOrDefaultAsync(u => u.UserName == username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching the user by username.");
                return null;
            }
        }
    }
}
