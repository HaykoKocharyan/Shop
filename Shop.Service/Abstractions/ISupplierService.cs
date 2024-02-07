using Shop.Repo.Models;

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
