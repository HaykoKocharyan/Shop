using Shop.Repo.Models;

namespace Shop.Service.Abstractions
{
    public interface IGoodService
    {
        Task AddGoods(GoodsModel goodsModel);

        Task<dynamic> SelectGoods();

        Task EditProduct(int productId, GoodsModel goodsModel);

        Task DeleteProduct(int productId);
    }
}
