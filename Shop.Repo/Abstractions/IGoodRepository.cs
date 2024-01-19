using Shop.Repo.Entities;
using Shop.Repo.Models;

namespace Shop.Repo.Abstractions
{
    public interface IGoodRepository
    {
        Task AddGoods(GoodsModel goodsModel);

        List<Good> SelectGoods();

        Task EditProduct(int productId, GoodsModel goodsModel);

        Task DeleteProduct(int productId);
    }
}
