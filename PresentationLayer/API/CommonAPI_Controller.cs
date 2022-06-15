using System.Collections.Generic;
using System.Threading.Tasks;
using LogicLayer.GenaralLogics;
using LogicLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.API
{
    [Route("api")]
    [ApiController]
    public class CommonAPI_Controller : ControllerBase
    {
        private readonly GeneralLogic _generalLogic = new GeneralLogic();

        [Route("view-categories")]
        [HttpGet]
        public async Task<List<CategoryViewModel>> ViewCategories()
        {

            var categories = await _generalLogic.ViewCategories();

            return categories;
        }

        [Route("view-products")]
        [HttpGet]
        public async Task<List<ProductViewModel>> ViewProducts()
        {

            var produts = await _generalLogic.ViewProducts();

            return produts;
        }


        //FILTER PRODUCTS BY CATEGORY
        [Route("view-products/{id}")]
        [HttpGet]
        public async Task<List<ProductViewModel>> ViewProducts(int id)
        {
            var products = await _generalLogic.ViewProducts(id);
            return products;
        }


        //PRODUCT DETAILS
        [Route("product-details/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var productDetails = _generalLogic.ProductDetails(id);

            if (productDetails == null)
            {
                return NotFound();
            }

            return Ok(productDetails);
        }
    }
}