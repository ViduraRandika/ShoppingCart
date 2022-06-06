using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using LogicLayer.GenaralLogics;
using LogicLayer.UserLogic;
using LogicLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using PresentationLayer.Models.ReqModels;

namespace PresentationLayer.API
{
    [Route("api/user/")]
    [ApiController]
    public class UserAPI_Controller : ControllerBase
    {
        private readonly UserLogic userLogic = new UserLogic();
        private readonly SendEmailLogic sendEmailLogic = new SendEmailLogic();


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


        [Route("sendContactUsMsg")]
        [HttpPost]
        public IActionResult sendMail([FromBody] RContact contact)
        {
            if (ModelState.IsValid)
            {
                if (sendEmailLogic.sendEmail(contact.email,"Message from contact form",contact.body,contact.name))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest();
        }


        [Route("addProductToCart")]
        [HttpPost]
        public IActionResult addToCart(int produtctId, long userID, int qty)
        {
            var res = userLogic.AddProductToCart(produtctId, userID, qty);

            if (res.Result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Route("getCartItems")]
        [HttpGet]
        // [Authorize(Roles = "admin")]
        public async Task<List<CartItemsViewModel>> GetCartItems()
        {
            var cartItems= await userLogic.GetCartItems(12);
            return cartItems;
        }

        [Route("updateCartItems")]
        [HttpPost]
        public IActionResult updateCartItemQty(long id, int qty)
        {
            var res = userLogic.UpdateCarteItemQty(id, qty);

            if (res.Result)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
