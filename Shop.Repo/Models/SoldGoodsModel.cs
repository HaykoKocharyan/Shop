using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Models
{
    public class SoldGoodsModel
    {
        public  string Product_Name { get; set; }
        public string Supplier_Name { get; set; }
        public decimal Sale_Price { get; set; }
        public int? Quantity_Sold { get; set; }
        public double? Weight_Sold_KG { get; set; }
        public decimal Total_Price { get; set; }
    }
}
