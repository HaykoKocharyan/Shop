using Microsoft.AspNetCore.Mvc;
using Shop.Repo.Models;
using Shop.Service.Abstractions;

namespace ShopWebApi.Controllers
{
    [Route("Worker")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IWorkerService workerService;

        public WorkerController(IWorkerService workerService)
        {
            this.workerService = workerService;
        }

        [HttpPost("AddWorker")]
        public async Task<IActionResult> AddWorker(WorkerModel workerModel)
        {
            if (workerModel != null)
            {
                try
                {
                    await workerService.AddWorker(workerModel);
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

        [HttpGet("GetAllWorkers")]
        public async Task<dynamic> SelectWorkers()
        {
            return await workerService.SelectWorkers();

        }

        [HttpPut("EditWorker")]
        public async Task<IActionResult> EditWorker(int workerId, WorkerModel workerModel)
        {
            try
            {
                await workerService.EditWorker(workerId, workerModel);
                return Ok("Worker updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update worker: {ex.Message}");
            }
        }

        [HttpDelete("DeleteWorker")]
        public async Task<IActionResult> DeleteWorker(int workerId)
        {
            try
            {
                await workerService.DeleteWorker(workerId);
                return Ok($"Worker with Id {workerId} deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete product: {ex.Message}");
            }
        }
    }
}
