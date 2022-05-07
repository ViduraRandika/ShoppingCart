using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogicLayer.AdminLogic;
using LogicLayer.ViewModels;
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

        [Route("view-categories")]
        [HttpGet]
        public async Task<List<CategoryViewModel>> ViewCategories()
        {

            var categories= await _adminLogic.ViewCategories();

            return categories;
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
