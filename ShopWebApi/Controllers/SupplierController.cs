using Microsoft.AspNetCore.Mvc;
using Shop.Repo.Models;
using Shop.Service;
using Shop.Service.Abstractions;

namespace ShopWebApi.Controllers
{
    [Route("Supplier")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierService supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier(SupplierModel supplierModel)
        {
            if (supplierModel != null)
            {
                try
                {
                    await supplierService.AddSupplier(supplierModel);
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

        [HttpGet("GetAllSuplliers")]
        public async Task<dynamic> SelectSuppliers()
        {
            return await supplierService.SelectSuppliers();
        }

        [HttpPut("EditSupplier")]
        public async Task<IActionResult> EditSupplier(int supplierId,SupplierModel supplierModel)
        {
            try
            {
                await supplierService.EditSupplier(supplierId, supplierModel);
                return Ok("Supplier updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update supplier: {ex.Message}");
            }
        }

        [HttpDelete("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier(int supplierId)
        {
            try
            {
                await supplierService.DeleteSupplier(supplierId);
                return Ok($"Supplier with Id {supplierId} deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete product: {ex.Message}");
            }
        }

    }
}
