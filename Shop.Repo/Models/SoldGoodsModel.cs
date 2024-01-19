using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Models
{
    public class SoldGoodsModel
    {
        public string Product_Name { get; set; } = null!;
        public string Supplier_Name { get; set; } = null!;
        public decimal Sale_Price { get; set; }
        public int? Quantity { get; set; }
        public double? Weight_KG { get; set; }
        public decimal Total_Price { get; set; }
    }
}
