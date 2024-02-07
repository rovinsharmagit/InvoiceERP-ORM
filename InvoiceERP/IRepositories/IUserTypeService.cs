using InvoiceERP.Models;

namespace InvoiceERP.IRepositories
{
    public interface IUserTypeService
    {
        Task<IEnumerable<TblUserType>> GetAllUserTypes();
        Task<TblUserType> GetUserTypeById(int id);
        Task CreateUserType(TblUserType userType);
        Task UpdateUserType(TblUserType userType);
        Task DeleteUserType(int id);
    }
}
