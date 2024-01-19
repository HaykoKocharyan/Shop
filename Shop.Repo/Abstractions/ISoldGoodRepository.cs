using Shop.Repo.Models;

namespace Shop.Repo.Abstractions
{
    public interface ISoldGoodRepository
    {
        Task SellProduct(SoldGoodsModel soldGoodsModel);
    }
}
