using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Entities
{
    public class SoldGoods
    {
        public int Id { get; set; }
        public int Goods_Id { get; set; }
        [ForeignKey("Goods_Id")]
        public Goods Goods { get; set; }
        public decimal Sale_Price { get; set; }
        public int? Quantity_Sold { get; set; }
        public double? Weight_Sold { get; set; }
        public decimal Total_Price { get; set; }
        public DateTime Sold_Date { get; set; }
    }
}
