using Shop.Repo.Abstractions;
using Shop.Repo.Models;
using Shop.Service.Abstractions;


namespace Shop.Service.Services
{
    public class GoodService : IGoodService
    {
        private readonly IGoodRepository goodRepository;
        public GoodService(IGoodRepository goodRepository)
        {
            this.goodRepository = goodRepository;
        }

        public async Task AddGoods(AddGoodsModel addGoodsModel)
        {
            await goodRepository.AddGoods(addGoodsModel);
        }

        public async Task DeleteProduct(int productId)
        {
            await goodRepository.DeleteProduct(productId);
        }

        public async Task EditProduct(int productId, EditGoodsModel editGoodsModel)
        {
            await goodRepository.EditProduct(productId, editGoodsModel);
        }

        public async Task<dynamic> SelectGoods()
        {
            return goodRepository.SelectGoods();
        }
    }
}
