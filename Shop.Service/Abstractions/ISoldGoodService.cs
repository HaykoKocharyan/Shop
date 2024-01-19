using Shop.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Service.Abstractions
{
    public interface ISoldGoodService
    {
        Task SellProduct(SoldGoodsModel soldGoodsModel);

    }
}
