using Shop.Repo.Abstractions;
using Shop.Repo.Models;
using Shop.Service.Abstractions;

namespace Shop.Service.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository workerRepository;
        public WorkerService(IWorkerRepository workerRepository)
        {
            this.workerRepository = workerRepository;
        }
        public async Task AddWorker(WorkerModel workerModel)
        {
            await workerRepository.AddWorker(workerModel);
        }

        public async Task DeleteWorker(int workerId)
        {
            await workerRepository.DeleteWorker(workerId);
        }

        public async Task EditWorker(int workerId, WorkerModel workerModel)
        {
            await workerRepository.EditWorker(workerId, workerModel);
        }

        public async Task<dynamic> SelectWorkers()
        {
            return workerRepository.SelectWorkers();
        }
    }
}
