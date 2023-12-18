using Microsoft.EntityFrameworkCore;
using Shop.Repo.Entities;
using Shop.Repo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Repositories
{
    public class ShopRepository
    {
        private readonly ShopDBContext dbContext;
        public ShopRepository(ShopDBContext dbContext)
        {
            this.dbContext = new ShopDBContext();
        }

        public ShopRepository()
        {

        }

        public async Task AddGoods(GoodsModel goodsModel)
        {
            var existingSupplier = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.Supplier_Name == goodsModel.Supplier_Name);

            if (existingSupplier != null)
            {
                var existingProduct = await dbContext.Goods.FirstOrDefaultAsync(g => g.Product_Name == goodsModel.Product_Name && g.Supplier_Id == existingSupplier.Id);

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
                    Goods newGoods = new Goods
                    {
                        Product_Name = goodsModel.Product_Name,
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
                //Suppliers newSupplier = new Suppliers
                //{
                //    Supplier_Name = goodsModel.Supplier_Name,
                //};
                //dbContext.Suppliers.Add(newSupplier);
                //await dbContext.SaveChangesAsync();

                //Goods newGoods = new Goods
                //{
                //    Product_Name = goodsModel.Product_Name,
                //    Import_Price = goodsModel.Import_Price,
                //    //Sale_Price = goodsModel.Sale_Price,
                //    Quantity = goodsModel.Quantity,
                //    Weight_KG = goodsModel.Weight_KG,
                //    Category = goodsModel.Category,
                //    Supplier_Id = newSupplier.Id
                //};
                //dbContext.Goods.Add(newGoods);
                //await dbContext.SaveChangesAsync();
                throw new InvalidOperationException($"Supplier with the name {goodsModel.Supplier_Name} does not exist. Please Add Supplier at first");
            }
        }

        public async Task AddSupplier(SupplierModel supplierModel)
        {
            var existingSupplier = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.Supplier_Name == supplierModel.Supplier_Name);

            if (existingSupplier == null)
            {
                Suppliers newSupplier = new Suppliers
                {
                    Supplier_Name = supplierModel.Supplier_Name,
                    Contact_Person = supplierModel.Contact_Person,
                    Supplier_Email = supplierModel.Supplier_Email,
                    Supplier_Phone = supplierModel.Supplier_Phone,
                    Supplier_Address = supplierModel.Supplier_Address
                };

                dbContext.Suppliers.Add(newSupplier);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Supplier with the same name already exists");
            }
        }

        public async Task AddWorker(WorkerModel workerModel)
        {
            { 
                Workers newWorkers = new Workers
                {
                    Worker_Name = workerModel.Worker_Name,
                    Worker_LastName = workerModel.Worker_LastName,
                    Worker_Position = workerModel.Worker_Position,
                    Worker_Salary = workerModel.Worker_Salary,
                    Worker_Email = workerModel.Worker_Email,
                    Worker_Phone = workerModel.Worker_Phone,
                    Worker_Adress = workerModel.Worker_Adress,
                    DateOfBirth = workerModel.DateOfBirth
                };

                dbContext.Workers.Add(newWorkers);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task SellProduct(SoldGoodsModel soldGoodsModel)
        {
            var existingProduct = await dbContext.Goods.FirstOrDefaultAsync(s => s.Product_Name == soldGoodsModel.Product_Name);

            var existingSupplier = await dbContext.Goods.FirstOrDefaultAsync(s => s.Supplier.Supplier_Name == soldGoodsModel.Supplier_Name);

            if (existingProduct != null && existingSupplier != null)
            {
                if (existingProduct.Quantity != null && soldGoodsModel.Quantity_Sold != null)
                {
                    if (existingProduct.Quantity >= soldGoodsModel.Quantity_Sold)
                    {
                        existingProduct.Quantity -= soldGoodsModel.Quantity_Sold.Value;
                    }
                    else
                    {
                        throw new InvalidOperationException("Insufficient quantity available for sale.");
                    }
                }

                else if (existingProduct.Weight_KG != null && soldGoodsModel.Weight_Sold_KG != null)
                {
                    if (existingProduct.Weight_KG >= soldGoodsModel.Weight_Sold_KG)
                    {
                        existingProduct.Weight_KG -= soldGoodsModel.Weight_Sold_KG.Value;
                    }
                    else
                    {
                        throw new InvalidOperationException("Insufficient weight available for sale.");
                    }
                }

                SoldGoods newSoldGoods = new SoldGoods
                {
                    Goods_Id = existingProduct.Id,
                    Sale_Price = soldGoodsModel.Sale_Price,
                    Quantity_Sold = soldGoodsModel.Quantity_Sold,
                    Weight_Sold = soldGoodsModel.Weight_Sold_KG,
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

        public List<Goods> SelectProduct()
        {
            var goods = dbContext.Goods
                .Select(g => new Goods
                {
                    Id = g.Id,
                    Product_Name = g.Product_Name,
                    Import_Price = g.Import_Price,
                    //Sale_Price = g.Sale_Price,
                    Quantity = g.Quantity,
                    Category = g.Category,
                    Weight_KG = g.Weight_KG,
                    Supplier = new Suppliers
                    {
                        Supplier_Name = g.Supplier.Supplier_Name
                    }
                })
                .ToList();

            return goods;
        }

        public List<Workers> SelectWorkers()
        {
            var worker = dbContext.Workers
                .Select(g => new Workers
                {
                    Id = g.Id,
                    Worker_Name = g.Worker_Name,
                    Worker_LastName = g.Worker_LastName,
                    Worker_Position = g.Worker_Position,
                    Worker_Salary = g.Worker_Salary,
                    Worker_Email = g.Worker_Email,
                    Worker_Phone = g.Worker_Phone,
                    Worker_Adress = g.Worker_Adress,
                    DateOfBirth = g.DateOfBirth,
                    Work_End_Date = g.Work_End_Date
                })
                .ToList();

            return worker;
        }

        public List<Suppliers> SelectSuppliers()
        {
            var suppliers = dbContext.Suppliers
                    .Select(g => new Suppliers
                    {
                        Id = g.Id,
                        Supplier_Name = g.Supplier_Name,
                        Contact_Person = g.Contact_Person,
                        Supplier_Email = g.Supplier_Email,
                        Supplier_Phone = g.Supplier_Phone,
                        Supplier_Address = g.Supplier_Address,
                        Created_Date = g.Created_Date,
                    })
                .ToList();

            return suppliers;
        }

        public async Task EditProduct(int productId, GoodsModel goodsModel)
        {
            var existingProduct = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.Id == productId);

            if (existingProduct != null)
            {
                var workerProperties = typeof(WorkerModel).GetProperties();

                foreach (var property in workerProperties)
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

        public async Task EditSupplier(int supplierId, SupplierModel supplierModel)
        {
            var existingSupplier = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);

            if (existingSupplier != null)
            {
                var workerProperties = typeof(WorkerModel).GetProperties();

                foreach (var property in workerProperties)
                {
                    var newValue = property.GetValue(supplierModel);
                    if (newValue != null)
                    {
                        var existingValue = property.GetValue(existingSupplier);
                        if (existingValue != newValue)
                        {
                            property.SetValue(existingSupplier, newValue);
                        }
                    }
                }
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No suppliers with id {supplierId} found");
            }
        }

        public async Task EditWorker(int workerId, WorkerModel workerModel)
        {
            var existingWorker = await dbContext.Workers.FirstOrDefaultAsync(w => w.Id == workerId);

            if (existingWorker != null)
            {
                var workerProperties = typeof(WorkerModel).GetProperties();

                foreach (var property in workerProperties)
                {
                    var newValue = property.GetValue(workerModel);
                    if (newValue != null)
                    {
                        var existingValue = property.GetValue(existingWorker);
                        if (existingValue != newValue)
                        {
                            property.SetValue(existingWorker, newValue);
                        }
                    }
                }

                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"No workers with id {workerId} found");
            }
        }


    }
}
