using InvoiceERP.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvoiceERP.IRepositories
{
    public interface IUserService
    {
        Task<IEnumerable<TblUser>> GetAllUsersAsync();
        Task<TblUser> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(TblUser user);
        Task<bool> UpdateUserAsync(int id, TblUser user);
        Task<bool> DeleteUserAsync(int id);
        SelectList GetUserTypesSelectList();
    }
}
