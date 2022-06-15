using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        User Authenticate(string email);
    }
}