using InvoiceERP.Models;
using System.Security.Claims;

namespace InvoiceERP.IRepositories
{
    public interface IJwtService
    {
        string GenerateToken(TblUser user);
        IEnumerable<Claim> GenerateTokenClaims(TblUser user);
    }
}
