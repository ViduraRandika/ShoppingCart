using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using LogicLayer.GenaralLogics;
using LogicLayer.Interfaces;
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
        private readonly IAuthLogic authLogic;
        private readonly SendEmailLogic sendEmailLogic = new SendEmailLogic();

        public UserAPI_Controller(IAuthLogic authLogic)
        {
            this.authLogic = authLogic;
        }

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

        [AllowAnonymous]
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
        [Authorize(Roles = "customer")]
        public IActionResult addToCart(int produtctId, int qty)
        {
            var context = HttpContext;
            var res_u = authLogic.GetUserDataFromToken(context);
            long userID = res_u.UserId;
            var res = userLogic.AddProductToCart(produtctId, userID, qty);

            if (res.Result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Route("removeProductFromCart")]
        [HttpDelete]
        [Authorize(Roles = "customer")]
        public IActionResult removeFromCart(int productId)
        {
            var context = HttpContext;
            var res_u = authLogic.GetUserDataFromToken(context);
            long userId = res_u.UserId;

            var res = userLogic.RemoveProductFromCart(productId, userId);

            if (res.Result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Route("getCartItems")]
        [HttpGet]
        [Authorize(Roles = "customer")]
        public async Task<List<CartItemsViewModel>> GetCartItems()
        {
            var context = HttpContext;
            var res_u = authLogic.GetUserDataFromToken(context);
            long userID = res_u.UserId;
            var cartItems= await userLogic.GetCartItems(userID);
            return cartItems;
        }

        [Route("updateCartItems")]
        [HttpPost]
        [Authorize(Roles = "customer")]
        public IActionResult updateCartItemQty(long id, int qty)
        {
            var res = userLogic.UpdateCarteItemQty(id, qty);

            if (res.Result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Route("placeOrder")]
        [HttpPost]
        [Authorize(Roles = "customer")]
        public IActionResult placeOrder(long total)
        {
            var context = HttpContext;
            var res_u = authLogic.GetUserDataFromToken(context);
            int userID = Convert.ToInt32(res_u.UserId);

            var res = userLogic.PlaceOrder(userID,total);

            if (res.Result)
            {
                return Ok();
            }

            return BadRequest();
        }

        [Route("my-orders")]
        [HttpGet]
        [Authorize(Roles = "customer")]

        public async Task<List<OrderListViewModel>> GetOrders()
        {
            var context = HttpContext;
            var res_u = authLogic.GetUserDataFromToken(context);
            long userID = res_u.UserId;
            var orders = await userLogic.GetOrderList(userID);
            return orders;
        }
    }
}
