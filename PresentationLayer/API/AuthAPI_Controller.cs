using Microsoft.AspNetCore.Mvc;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using PresentationLayer.Models.ReqModels;

namespace PresentationLayer.API
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPI_Controller : ControllerBase
    {
        private readonly IAuthLogic authLogic;

        public AuthAPI_Controller(IAuthLogic authLogic)
        {
            this.authLogic = authLogic;
        }
        

        [HttpPost("login"),AllowAnonymous]

        public IActionResult Authenticate([FromBody] RCredentials credentials)
        {

            if (ModelState.IsValid)
            {
                var token = authLogic.AuthenticateUser(credentials.Email, credentials.Password);

                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(token);
            }

            return BadRequest();
        }
    }
}
