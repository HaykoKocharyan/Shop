using Microsoft.AspNetCore.Mvc;
using Shop.Repo.Models;
using Shop.Service.Abstractions;

namespace ShopWebApi.Controllers
{
    [Route("Good")]
    [ApiController]
    public class GoodController : Controller
    {
        private readonly IGoodService goodService;
        public GoodController(IGoodService goodService)
        {
            this.goodService = goodService;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddGoods(AddGoodsModel addgoodsModel)
        {
            if (addgoodsModel != null)
            {
                await goodService.AddGoods(addgoodsModel);
                return Ok("Product added successfully");
            }
            else
                return BadRequest("Please Fill Data");
        }

        [HttpGet("GetAllGoods")]
        public async Task<dynamic> SelectGoods()
        {
            return await goodService.SelectGoods();
        }

        [HttpPut("EditProduct")]
        public async Task<IActionResult> EditProduct(int productId,EditGoodsModel editGoodsModel)
        {
            try
            {
                await goodService.EditProduct(productId, editGoodsModel);
                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update product: {ex.Message}");
            }
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] int productId)
        {
            try
            {
                await goodService.DeleteProduct(productId);
                return Ok($"Product with id {productId} deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete product: {ex.Message}");
            }
        }
    }
}
