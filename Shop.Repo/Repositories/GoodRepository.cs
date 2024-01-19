using Microsoft.EntityFrameworkCore;
using Shop.Repo.Abstractions;
using Shop.Repo.Entities;
using Shop.Repo.Models;

namespace Shop.Repo.Repositories
{
    public class GoodRepository : IGoodRepository
    {
        private readonly ShopDBContext dbContext;
        public GoodRepository(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddGoods(GoodsModel goodsModel)
        {
            var existingSupplier = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.Name == goodsModel.Supplier_Name);

            if (existingSupplier != null)
            {
                var existingProduct = await dbContext.Goods.FirstOrDefaultAsync(g => g.Name == goodsModel.Product_Name && g.Supplier_Id == existingSupplier.Id);

                if (existingProduct != null)
                {
                    if (goodsModel.Quantity != null)
                    {
                        existingProduct.Quantity += goodsModel.Quantity;
                    }
                    else if (goodsModel.Weight_KG != null)
                    {
                        existingProduct.Weight_KG += goodsModel.Weight_KG;
                    }

                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    Good newGoods = new Good
                    {
                        Name = goodsModel.Product_Name,
                        Import_Price = goodsModel.Import_Price,
                        Quantity = goodsModel.Quantity,
                        Weight_KG = goodsModel.Weight_KG,
                        Category = goodsModel.Category,
                        Supplier_Id = existingSupplier.Id
                    };
                    dbContext.Goods.Add(newGoods);
                    await dbContext.SaveChangesAsync();
                }
            }
            else
            {
                throw new InvalidOperationException($"Supplier with the name {goodsModel.Supplier_Name} does not exist. Please Add Supplier at first");
            }
        }

        public async Task DeleteProduct(int productId)
        {
            var deleteproduct = dbContext.Goods.FirstOrDefault(e => e.Id == productId);

            if (deleteproduct != null)
            {
                dbContext.Goods.Remove(deleteproduct);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Product with id {productId} does not exist");
            }
        }

        public async Task EditProduct(int productId, GoodsModel goodsModel)
        {
            var existingProduct = await dbContext.Goods.FirstOrDefaultAsync(s => s.Id == productId);

            if (existingProduct != null)
            {
                var productProperties = typeof(GoodsModel).GetProperties();

                foreach (var property in productProperties)
                {
                    var newValue = property.GetValue(goodsModel);
                    if (newValue != null)
                    {
                        var existingValue = property.GetValue(existingProduct);
                        if (existingValue != newValue)
                        {
                            property.SetValue(existingProduct, newValue);
                        }
                    }
                }
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No suppliers with id {productId} found");
            }
        }

        public List<Good> SelectGoods()
        {
            var goods = dbContext.Goods
                .Select(g => new Good
                {
                    Id = g.Id,
                    Name = g.Name,
                    Import_Price = g.Import_Price,
                    Quantity = g.Quantity,
                    Category = g.Category,
                    Weight_KG = g.Weight_KG,
                    Supplier = new Supplier
                    {
                        Name = g.Supplier.Name,
                        Contact_Person = g.Supplier.Contact_Person,
                        Email = g.Supplier.Email,
                        Phone = g.Supplier.Phone,
                        Address = g.Supplier.Address
                    }
                })
                .ToList();

            return goods;
        }
    }
}

