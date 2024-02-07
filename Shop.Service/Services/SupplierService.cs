using Shop.Repo.Abstractions;
using Shop.Repo.Models;
using Shop.Service.Abstractions;

namespace Shop.Service.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public async Task AddSupplier(SupplierModel supplierModel)
        {
            await supplierRepository.AddSupplier(supplierModel);
        }

        public async Task DeleteSupplier(int supplierId)
        {
            await supplierRepository.DeleteSupplier(supplierId);
        }

        public async Task EditSupplier(int supplierId, SupplierModel supplierModel)
        {
            await supplierRepository.EditSupplier(supplierId, supplierModel);
        }

        public async Task<dynamic> SelectSuppliers()
        {
            return supplierRepository.SelectSuppliers();
        }
    }
}
