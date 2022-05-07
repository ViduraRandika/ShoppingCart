using System;
using System.Diagnostics;
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

        private readonly string _key;

        public AuthLogic(string key)
        {
            this._key = key;
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
            var tokenKey = Encoding.ASCII.GetBytes(_key);

            var authLevel = user.AuthLevelId switch
            {
                1 => "admin",
                2 => "customer",
                _ => ""
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, user.UserFullName),
                    new Claim(ClaimTypes.StreetAddress, user.UserAddress),
                    new Claim(ClaimTypes.MobilePhone, user.UserPhoneNumber),
                    new Claim(ClaimTypes.Role, authLevel)
                },
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(tokenKey),
                    algorithm: SecurityAlgorithms.HmacSha256
                )
            );

            string ftoken = tokenHandler.WriteToken(token);
            return ftoken;
        }
    }
}