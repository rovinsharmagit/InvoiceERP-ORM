using InvoiceERP.Models;

namespace InvoiceERP.IRepositories
{
    public interface ILoginService
    {
      Task<bool> ValidateUser(string username, string password);
      Task<TblUser?> GetUserByUsername(string username);
    }
}
