using Shop.Repo.Models;

namespace Shop.Service.Abstractions
{
    public interface IGoodService
    {
        Task AddGoods(AddGoodsModel addGoodsModel);

        Task<dynamic> SelectGoods();

        Task EditProduct(int productId, EditGoodsModel editGoodsModel);

        Task DeleteProduct(int productId);
    }
}
