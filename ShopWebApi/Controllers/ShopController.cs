using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Repo.Models;
using Shop.Repo.Repositories;
using Shop.Service;

namespace ShopWebApi.Controllers
{
    [Route("Shop")]
    [ApiController]
    public class ShopController : Controller
    {
        private readonly ShopService shopService;
        private readonly ShopDBContext dbContext;

        public ShopController(ShopService shopService)
        {
            this.shopService = shopService;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddGoods([FromQuery] GoodsModel goodsModel)
        {
            if (goodsModel != null)
            {
                    await shopService.AddGoods(goodsModel);
                    return Ok("Goods added successfully");
            }
            else
                return BadRequest("Please Fill Data");
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier([FromQuery] SupplierModel supplierModel)
        {
            if (supplierModel != null)
            {
                try
                {
                    await shopService.AddSupplier(supplierModel);
                    return Ok("Supplier Added successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to Add Supplier: {ex.Message}");
                }

            }
            else
                return BadRequest("Please Fill Data");
        }

        [HttpPost("AddWorker")]
        public async Task<IActionResult> AddWorker([FromQuery] WorkerModel workerModel)
        {
            if (workerModel != null)
            {
                try
                {
                    await shopService.AddWorker(workerModel);
                    return Ok("Worker Added successfully");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to Add Worker: {ex.Message}");
                }

            }
            else
                return BadRequest("Please Fill Data");
        }

        [HttpPost("SellProduct")]
        public async Task<IActionResult> SellProduct([FromQuery] SoldGoodsModel soldGoodsModel)
        {
            if (soldGoodsModel != null)
            {
                try
                {
                    await shopService.SellProduct(soldGoodsModel);
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

        [HttpGet("GetAllGoods")]
        public async Task<dynamic> SelectProduct()
        {
            return await shopService.SelectProduct();

        }

        [HttpGet("GetAllWorkers")]
        public async Task<dynamic> SelectWorkers()
        {
            return await shopService.SelectWorkers();

        }

        [HttpGet("GetAllSuplliers")]
        public async Task<dynamic> SelectSuppliers()
        {
            return await shopService.SelectSuppliers();
        }

        [HttpPut("EditWorker")]
        public async Task<IActionResult> EditWorker(int workerId, [FromQuery] WorkerModel workerModel)
        {
            try
            {
                await shopService.EditWorker(workerId, workerModel);
                return Ok("Worker updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update worker: {ex.Message}");
            }
        }

        [HttpPut("EditSupplier")]
        public async Task<IActionResult> EditSupplier(int supplierId, [FromQuery] SupplierModel supplierModel)
        {
            try
            {
                await shopService.EditSupplier(supplierId, supplierModel);
                return Ok("Supplier updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update supplier: {ex.Message}");
            }
        }

        [HttpPut("EditProduct")]
        public async Task<IActionResult> EditProduct(int productId, [FromQuery] GoodsModel goodsModel)
        {
            try
            {
                await shopService.EditProduct(productId, goodsModel);
                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update product: {ex.Message}");
            }
        }
    }
}
