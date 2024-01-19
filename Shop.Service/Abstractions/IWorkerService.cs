
using Shop.Repo.Models;

namespace Shop.Service.Abstractions
{
    public interface IWorkerService
    {
        Task AddWorker(WorkerModel workerModel);

        Task<dynamic> SelectWorkers();

        Task EditWorker(int workerId, WorkerModel workerModel);

        Task DeleteWorker(int workerId);
    }
}
