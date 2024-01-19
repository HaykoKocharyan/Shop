using Shop.Repo.Entities;
using Shop.Repo.Models;

namespace Shop.Repo.Abstractions
{
    public interface IWorkerRepository
    {
        Task AddWorker(WorkerModel workerModel);

        List<Worker> SelectWorkers();

        Task EditWorker(int workerId, WorkerModel workerModel);

        Task DeleteWorker(int workerId);
    }
}
