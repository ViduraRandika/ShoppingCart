using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using LogicLayer.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace LogicLayer.AuthLogic
{
    public class AuthLogic : IAuthLogic
    {
        private readonly IJwtAuthenticationManager _auth = new JwtAuthenticationManager();

        private readonly string key;

        public AuthLogic(string key)
        {
            this.key = key;
        }

        public string AuthenticateUser(string email, string password)
        {
            var user = _auth.Authenticate(email);

            

            var passwordHash = new PasswordHash();
            var isVerifiedPassword = passwordHash.VerifyPassword(user.Password, password);


            // return user.Password;
            
            if (user == null || !isVerifiedPassword)
            {
                return null;
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            
            var ftoken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(ftoken);
        }
    }
}