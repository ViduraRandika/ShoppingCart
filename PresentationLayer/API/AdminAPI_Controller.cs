using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using LogicLayer.AdminLogic;
using LogicLayer.AuthLogic;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using PresentationLayer.Models.ReqModels;

namespace PresentationLayer.API
{
    [Route("api/admin")]
    [ApiController]
    public class AdminAPI_Controller : ControllerBase
    {


        private readonly AdminLogic _adminLogic = new AdminLogic();
        private readonly IAuthLogic authLogic;

        public AdminAPI_Controller(IAuthLogic authLogic)
        {
            this.authLogic = authLogic;
        }

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
            var result = await _adminLogic.CreateNewProduct(product.ProductName, product.Description, product.Price, product.ProductImagePath, product.CategoryId);

            return result switch
            {
                200 => Ok("Product added successfully"),
                400 => StatusCode(400, "Something went wrong"),
                _ => BadRequest()
            };

        }

        [Route("uploadProductImage")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Products");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {

                    FileInfo fi = new FileInfo(file.FileName);

                    var ext = fi.Extension;
                    var uniqueFileName = $@"{DateTime.Now.Ticks}"+ext;
                    
                    var fullPath = Path.Combine(pathToSave, uniqueFileName);
                    var dbPath = Path.Combine(uniqueFileName);
                    await using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new {path = dbPath, status = 200});
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }


    }
}
