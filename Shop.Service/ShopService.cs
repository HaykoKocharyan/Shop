using Shop.Repo.Models;
using Shop.Repo.Repositories;

namespace Shop.Service
{
    public class ShopService
    {
        private readonly ShopRepository shopRepository;

        public ShopService(ShopRepository shopRepository)
        {
            this.shopRepository = shopRepository;
        }
        public ShopService()
        {

        }
        public async Task AddGoods(GoodsModel goodsModel)
        {
            await shopRepository.AddGoods(goodsModel);
        }

        public async Task AddSupplier(SupplierModel supplierModel)
        {
            try
            {
                await shopRepository.AddSupplier(supplierModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddWorker(WorkerModel workerModel)
        {
            try
            {
                await shopRepository.AddWorker(workerModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SellProduct(SoldGoodsModel soldGoodsModel)
        {
            try
            {
                await shopRepository.SellProduct(soldGoodsModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> SelectProduct()
        {
            return shopRepository.SelectProduct();
        }

        public async Task<dynamic> SelectWorkers()
        {
            return shopRepository.SelectWorkers();
        }

        public async Task<dynamic> SelectSuppliers()
        {
            return shopRepository.SelectSuppliers();
        }

        public async Task EditWorker(int workerId, WorkerModel workerModel)
        {
            await shopRepository.EditWorker(workerId, workerModel);
        }

        public async Task EditSupplier(int supplierId, SupplierModel supplierModel)
        {
            await shopRepository.EditSupplier(supplierId, supplierModel);
        }

        public async Task EditProduct(int productId, GoodsModel goodsModel)
        {
            await shopRepository.EditProduct(productId, goodsModel);
        }
    }
}
