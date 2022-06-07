using LogicLayer.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LogicLayer.Interfaces
{
    public interface IAuthLogic
    {
        string AuthenticateUser(string email, string password);
        UserTokenDataViewModel GetUserDataFromToken(HttpContext context);
    }
}