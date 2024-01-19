using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Entities
{
    public class ReturnedGood
    {
        public int Id { get; set; }
        public string? Reason { get; set; }
        public int? Quantity { get; set; }
        public double? Weight_Kg { get; set; }
        public decimal? Refund_Amount { get; set; }
        public DateTime Return_Date { get; set; }

        public int Goods_Id { get; set; }
        [ForeignKey("Goods_Id")]
        public Good Goods { get; set; } = null!;
    }
}
