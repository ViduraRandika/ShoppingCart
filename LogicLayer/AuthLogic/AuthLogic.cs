using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using LogicLayer.Interfaces;
using LogicLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;

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
                    new Claim(ClaimTypes.UserData,user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, user.UserFullName),
                    new Claim(ClaimTypes.StreetAddress, user.UserAddress),
                    new Claim(ClaimTypes.MobilePhone, user.UserPhoneNumber),
                    new Claim(ClaimTypes.Role, authLevel)
                },
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(tokenKey),
                    algorithm: SecurityAlgorithms.HmacSha256
                )
            );

            string ftoken = tokenHandler.WriteToken(token);
            return ftoken;
        }

        public UserTokenDataViewModel GetUserDataFromToken(HttpContext context)
        {
            try
            {
                
                var authorization = context.Request.Headers[HeaderNames.Authorization];
                if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
                {
                    var parameter = headerValue.Parameter;
                    var handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(parameter);

                    var userData = new UserTokenDataViewModel();

                    userData.UserId = long.Parse(token.Payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata"].ToString());
                    userData.Email = token.Payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"].ToString();
                    userData.Name = token.Payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"].ToString();
                    userData.Address = token.Payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/streetaddress"].ToString();
                    userData.MobileNo = token.Payload["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone"].ToString();
                    userData.Role = token.Payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"].ToString();

                    return userData;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}