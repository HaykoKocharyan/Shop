using Shop.Repo.Abstractions;
using Shop.Repo.Entities;
using Shop.Repo.Models;

namespace Shop.Repo.Repositories
{
    public class ReturnedGoodRepository : IReturnedGoodRepository
    {
        private readonly ShopDBContext dbContext;
        public ReturnedGoodRepository(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task ReturnGood(ReturnGoodModel returnGoodModel)
        {
            var existSoldGood = dbContext.SoldGoods.FirstOrDefault(x => x.Id == returnGoodModel.SoldGood_Id);

            if (existSoldGood != null)
            {
                if (returnGoodModel.Quantity != 0 && returnGoodModel.Quantity <= existSoldGood.Quantity)
                {
                    existSoldGood.Quantity -= returnGoodModel.Quantity;
                }
                else if (returnGoodModel.Weight_Kg != 0 && returnGoodModel.Weight_Kg <= existSoldGood.Weight_KG)
                {
                    existSoldGood.Weight_KG -= returnGoodModel.Weight_Kg;
                }
                else
                    throw new InvalidOperationException("Incorrect Quantity or Weight");
                if (returnGoodModel.Refound_Amount <= existSoldGood.Total_Price)
                {
                    existSoldGood.Total_Price -= returnGoodModel.Refound_Amount;
                }
                else
                    throw new InvalidCastException("Refound Amount is more than Sold Amount");

                var product = dbContext.Goods.FirstOrDefault(y => y.Id == existSoldGood.Goods_Id);

                if (product != null)
                {
                    if (returnGoodModel.Weight_Kg != 0)
                    {
                        product.Weight_KG += returnGoodModel.Weight_Kg;
                    }
                    else if (returnGoodModel.Quantity != 0)
                    {
                        product.Quantity += returnGoodModel.Quantity;
                    }
                    ReturnedGood newReturnedGood = new ReturnedGood
                    {
                        Reason = returnGoodModel.Reason,
                        Quantity = returnGoodModel.Quantity,
                        Weight_Kg = returnGoodModel.Weight_Kg,
                        Refund_Amount = returnGoodModel.Refound_Amount,
                        SoldGood_Id = returnGoodModel.SoldGood_Id
                    };
                    dbContext.ReturnedGoods.Add(newReturnedGood);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}

