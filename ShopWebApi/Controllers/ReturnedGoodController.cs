using Microsoft.AspNetCore.Mvc;
using Shop.Repo.Models;
using Shop.Service.Abstractions;

namespace ShopWebApi.Controllers
{
    [Route("Returned Good")]
    [ApiController]
    public class ReturnedGoodController : Controller
    {
        private readonly IReturnedGoodService returnedGoodService;
        public ReturnedGoodController(IReturnedGoodService returnedGoodService)
        {
            this.returnedGoodService = returnedGoodService;
        }
        [HttpPost]
        public async Task<IActionResult> ReturnGood(ReturnGoodModel returnGoodModel)
        {
            if (ModelState.IsValid)
            {
                await returnedGoodService.ReturnGood(returnGoodModel);
                return Ok("Product Returned Successfully");
            }
            else
                return BadRequest(ModelState);
        }
    }
}
