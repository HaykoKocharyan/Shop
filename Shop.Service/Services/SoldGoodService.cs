using Shop.Repo.Abstractions;
using Shop.Repo.Models;
using Shop.Service.Abstractions;

namespace Shop.Service.Services
{
    public class SoldGoodService : ISoldGoodService
    {
        private readonly ISoldGoodRepository soldGoodRepository;
        public SoldGoodService(ISoldGoodRepository soldGoodRepository)
        {
            this.soldGoodRepository = soldGoodRepository;
        }
        public async Task SellProduct(SoldGoodsModel soldGoodsModel)
        {
            await soldGoodRepository.SellProduct(soldGoodsModel);
        }
    }
}
