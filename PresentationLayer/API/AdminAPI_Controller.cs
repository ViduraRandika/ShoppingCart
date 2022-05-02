using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using LogicLayer.AdminLogic;
using LogicLayer.UserLogic;
using Microsoft.AspNetCore.Authorization;
using PresentationLayer.Models.ReqModels;

namespace PresentationLayer.API
{
    [Route("api/admin")]
    [ApiController]
    public class AdminAPI_Controller : ControllerBase
    {
        private readonly AdminLogic _adminLogic = new AdminLogic();

        [Route("create-category")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateNewCategory([FromBody] RCreateCategory category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _adminLogic.CreateNewCategory(category.CategoryName);

            return result switch
            {
                200 => Ok("Category added successfully"),
                400 => StatusCode(400, "Something went wrong"),
                _ => BadRequest()
            };
        }


        [Route("add-product")]
        [HttpPost]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> AddNewProduct([FromBody] RCreateProduct product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _adminLogic.CreateNewProduct(product.ProductName, product.Description, product.Price, product.ProductImage, product.CategoryId);

            return result switch
            {
                200 => Ok("Product added successfully"),
                400 => StatusCode(400, "Something went wrong"),
                _ => BadRequest()
            };
            
        }
    }
}
