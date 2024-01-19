using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Models
{
    public class GoodsModel
    {
        public string Product_Name { get; set; } = null!;
        public decimal Import_Price { get; set; } 
        public int? Quantity { get; set; }
        public string? Category { get; set; }
        public double? Weight_KG { get; set; }
        public string Supplier_Name { get; set; } = null!;
    }
}
