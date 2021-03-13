using System.Security.Claims;

namespace DocManager.Services.Contract.Interfaces
{
    public interface IUserService
    {
        ClaimsIdentity GetClaimsIdentity();
    }    
}

