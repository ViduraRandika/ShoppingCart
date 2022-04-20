using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Functions
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        // private readonly string key;
        // public JwtAuthenticationManager(string key)
        // {
        //     this.key = key;
        // }
        public User Authenticate(string email)
        {

            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {

                // try
                // {
                    var user = context.Users.Single(u => u.Email == email);
                    return user;
                // }
                // catch (Exception)
                // {
                //     return null;
                // }
            }
        }
    }
}