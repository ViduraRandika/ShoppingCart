using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using LogicLayer.UserLogic;
using Microsoft.AspNetCore.Authorization;
using PresentationLayer.Models.ReqModels;

namespace PresentationLayer.API
{
    [Route("api/user/")]
    [ApiController]
    public class UserAPI_Controller : ControllerBase
    {
        private readonly UserLogic userLogic = new UserLogic();


        [AllowAnonymous]
        [Route("add")]
        [HttpPost]

        public async Task<IActionResult> CreateNewCustomer([FromBody] RCreateCustomer customer)
        {
            if (ModelState.IsValid)
            {
                var result = await userLogic.CreateNewUser(customer.CustomerName, customer.CustomerAddress,
                    customer.CustomerPhoneNumber, customer.Email, customer.Password);

                switch (result)
                {
                    case 200:
                        return Ok("Account created successfully. Please login.");
                    case 409:
                        return StatusCode(409, "An account is already registered with your email address. Please log in");
                }
            }

            return BadRequest();
        }
        

        [Route("all")]
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = await userLogic.GetAllUsers();
            return users;
        }
    }
}
