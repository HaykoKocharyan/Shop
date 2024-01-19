using Microsoft.EntityFrameworkCore;
using Shop.Repo.Abstractions;
using Shop.Repo.Entities;
using Shop.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (existingProduct.Quantity != null && soldGoodsModel.Quantity != null)
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

                else if (existingProduct.Weight_KG != null && soldGoodsModel.Weight_KG != null)
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
