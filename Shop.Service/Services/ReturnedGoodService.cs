using Shop.Repo.Abstractions;
using Shop.Repo.Models;
using Shop.Service.Abstractions;

namespace Shop.Service.Services
{
    public class ReturnedGoodService : IReturnedGoodService
    {
        private readonly IReturnedGoodRepository returnedGoodRepository;
        public ReturnedGoodService(IReturnedGoodRepository returnedGoodRepository)
        {
            this.returnedGoodRepository = returnedGoodRepository;
        }
        public async Task ReturnGood(ReturnGoodModel returnGoodModel)
        {
            await returnedGoodRepository.ReturnGood(returnGoodModel);
        }
    }
}
