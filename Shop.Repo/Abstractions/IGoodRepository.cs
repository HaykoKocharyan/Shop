using Shop.Repo.Entities;
using Shop.Repo.Models;

namespace Shop.Repo.Abstractions
{
    public interface IGoodRepository
    {
        Task AddGoods(AddGoodsModel addGoodsModel);

        List<Good> SelectGoods();

        Task EditProduct(int productId, EditGoodsModel editgoodsModel);

        Task DeleteProduct(int productId);
    }
}
