using Microsoft.EntityFrameworkCore;
using Shop.Repo.Abstractions;
using Shop.Repo.Entities;
using Shop.Repo.Models;

namespace Shop.Repo.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly ShopDBContext dbContext;
        public WorkerRepository(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddWorker(WorkerModel workerModel)
        {
            Worker newWorkers = new Worker
            {
                Name = workerModel.Name,
                Last_Name = workerModel.Last_Name,
                Position = workerModel.Position,
                Salary = workerModel.Salary,
                Email = workerModel.Email,
                Phone = workerModel.Phone,
                Adress = workerModel.Adress,
                DateOfBirth = workerModel.DateOfBirth
            };

            dbContext.Workers.Add(newWorkers);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteWorker(int workerId)
        {
            var deleteworker = dbContext.Workers.FirstOrDefault(e => e.Id == workerId);

            if (deleteworker != null)
            {
                dbContext.Workers.Remove(deleteworker);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Product with id {workerId} does not exist");
            }
        }

        public async Task EditWorker(int workerId, WorkerModel workerModel)
        {
            var existingWorker = await dbContext.Workers.FirstOrDefaultAsync(w => w.Id == workerId);

            if (existingWorker != null)
            {
                var workerProperties = typeof(WorkerModel).GetProperties();

                foreach (var property in workerProperties)
                {
                    var newValue = property.GetValue(workerModel);
                    if (newValue != null)
                    {
                        var existingValue = property.GetValue(existingWorker);
                        if (existingValue != newValue)
                        {
                            property.SetValue(existingWorker, newValue);
                        }
                    }
                }

                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No workers with id {workerId} found");
            }
        }

        public List<Worker> SelectWorkers()
        {
            var worker = dbContext.Workers
                 .Select(g => new Worker
                 {
                     Id = g.Id,
                     Name = g.Name,
                     Last_Name = g.Last_Name,
                     Position = g.Position,
                     Salary = g.Salary,
                     Email = g.Email,
                     Phone = g.Phone,
                     Adress = g.Adress,
                     DateOfBirth = g.DateOfBirth,
                     Work_End_Date = g.Work_End_Date
                 })
                 .ToList();

            return worker;
        }
    }
}
