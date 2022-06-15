using System.Linq;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Functions
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        public User Authenticate(string email)
        {
            using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
            var user = context.Users.Single(u => u.Email == email);
            return user;
        }
    }
}