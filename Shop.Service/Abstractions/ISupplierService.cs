using Shop.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Abstractions
{
    public interface ISupplierService
    {
        Task AddSupplier(SupplierModel supplierModel);

        Task<dynamic> SelectSuppliers();

        Task EditSupplier(int supplierId, SupplierModel supplierModel);

        Task DeleteSupplier(int supplierId);
    }
}
