using Microsoft.EntityFrameworkCore;
using Shop.Repo.Abstractions;
using Shop.Repo.Entities;
using Shop.Repo.Models;

namespace Shop.Repo.Repositories
{
    public class SoldGoodRepository : ISoldGoodRepository
    {
        private readonly ShopDBContext dbContext;
        public SoldGoodRepository(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SellProduct(SoldGoodsModel soldGoodsModel)
        {
            var existingProduct = await dbContext.Goods.FirstOrDefaultAsync(s => s.Name == soldGoodsModel.Product_Name);

            var existingSupplier = await dbContext.Goods.FirstOrDefaultAsync(s => s.Supplier.Name == soldGoodsModel.Supplier_Name);

            if (existingProduct != null && existingSupplier != null)
            {
                if (existingProduct.Quantity != 0 && soldGoodsModel.Quantity != 0)
                {
                    if (existingProduct.Quantity >= soldGoodsModel.Quantity)
                    {
                        existingProduct.Quantity -= soldGoodsModel.Quantity.Value;
                    }
                    else
                    {
                        throw new InvalidOperationException("Insufficient quantity available for sale.");
                    }
                }

                else if (existingProduct.Weight_KG != 0 && soldGoodsModel.Weight_KG != 0)
                {
                    if (existingProduct.Weight_KG >= soldGoodsModel.Weight_KG)
                    {
                        existingProduct.Weight_KG -= soldGoodsModel.Weight_KG.Value;
                    }
                    else
                    {
                        throw new InvalidOperationException("Insufficient weight available for sale.");
                    }
                }

                SoldGood newSoldGoods = new SoldGood
                {
                    Goods_Id = existingProduct.Id,
                    Price = soldGoodsModel.Sale_Price,
                    Quantity = soldGoodsModel.Quantity,
                    Weight_KG = soldGoodsModel.Weight_KG,
                    Total_Price = soldGoodsModel.Total_Price,
                };

                dbContext.SoldGoods.Add(newSoldGoods);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No product with name {soldGoodsModel.Product_Name} and Supplier Name {soldGoodsModel.Supplier_Name} found");
            }
        }
    }
}
