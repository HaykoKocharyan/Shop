using Microsoft.EntityFrameworkCore;
using Shop.Repo.Abstractions;
using Shop.Repo.Entities;
using Shop.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShopDBContext dbContext;
        public SupplierRepository(ShopDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddSupplier(SupplierModel supplierModel)
        {
            var existingSupplier = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.Name == supplierModel.Name);

            if (existingSupplier == null)
            {
                Supplier newSupplier = new Supplier
                {
                    Name = supplierModel.Name,
                    Contact_Person = supplierModel.Contact_Person,
                    Email = supplierModel.Email,
                    Phone = supplierModel.Phone,
                    Address = supplierModel.Address
                };

                dbContext.Suppliers.Add(newSupplier);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Supplier with the same name already exists");
            }
        }

        public async Task DeleteSupplier(int supplierId)
        {
            var deletesupplier = dbContext.Suppliers.FirstOrDefault(e => e.Id == supplierId);

            if (deletesupplier != null)
            {
                dbContext.Suppliers.Remove(deletesupplier);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Product with id {supplierId} does not exist");
            }
        }

        public async Task EditSupplier(int supplierId, SupplierModel supplierModel)
        {
            var existingSupplier = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);

            if (existingSupplier != null)
            {
                var supplierProperties = typeof(SupplierModel).GetProperties();

                foreach (var property in supplierProperties)
                {
                    var newValue = property.GetValue(supplierModel);
                    if (newValue != null)
                    {
                        var existingProperty = existingSupplier.GetType().GetProperty(property.Name);
                        if (existingProperty != null && existingProperty.CanWrite)
                        {
                            existingProperty.SetValue(existingSupplier, newValue);
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

        public List<Supplier> SelectSuppliers()
        {
            var suppliers = dbContext.Suppliers
                   .Select(g => new Supplier
                   {
                       Id = g.Id,
                       Name = g.Name,
                       Contact_Person = g.Contact_Person,
                       Email = g.Email,
                       Phone = g.Phone,
                       Address = g.Address,
                       Created_Date = g.Created_Date,
                   })
               .ToList();

            return suppliers;
        }
    }
}
