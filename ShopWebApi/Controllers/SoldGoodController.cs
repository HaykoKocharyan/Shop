using Microsoft.AspNetCore.Mvc;
using Shop.Repo.Models;
using Shop.Service;
using Shop.Service.Abstractions;

namespace ShopWebApi.Controllers
{
    [Route("SoldGood")]
    [ApiController]
    public class SoldGoodController : Controller
    {
        private readonly ISoldGoodService soldGoodService;
        public SoldGoodController(ISoldGoodService soldGoodService)
        {
                this.soldGoodService = soldGoodService;
        }

        [HttpPost("SellProduct")]
        public async Task<IActionResult> SellProduct(SoldGoodsModel soldGoodsModel)
        {
            if (soldGoodsModel != null)
            {
                try
                {
                    await soldGoodService.SellProduct(soldGoodsModel);
                    return Ok("Supplier Added successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to Update Goods: {ex.Message}");
                }

            }
            else
                return BadRequest("Please Fill Data");
        }
    }
}
