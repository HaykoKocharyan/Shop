using Shop.Repo.Models;

namespace Shop.Service.Abstractions
{
    public interface ISoldGoodService
    {
        Task SellProduct(SoldGoodsModel soldGoodsModel);

    }
}
