using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Repo.Entities
{
    public class SoldGood
    {
        public int Id { get; set; }
        public int Goods_Id { get; set; }
        [ForeignKey("Goods_Id")]
        public Good Goods { get; set; } = null!;
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public double? Weight_KG { get; set; }
        public decimal Total_Price { get; set; } 
        public DateTime Date { get; set; }
    }
}
