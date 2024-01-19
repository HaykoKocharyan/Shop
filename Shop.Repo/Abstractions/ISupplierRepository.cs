using Shop.Repo.Entities;
using Shop.Repo.Models;

namespace Shop.Repo.Abstractions
{
    public interface ISupplierRepository
    {
        Task AddSupplier(SupplierModel supplierModel);

        List<Supplier> SelectSuppliers();

        Task EditSupplier(int supplierId, SupplierModel supplierModel);

        Task DeleteSupplier(int supplierId);
    }
}
