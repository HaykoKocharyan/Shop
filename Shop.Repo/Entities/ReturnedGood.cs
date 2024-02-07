using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Repo.Entities
{
    public class ReturnedGood
    {
        public int Id { get; set; }
        public string? Reason { get; set; }
        public int? Quantity { get; set; }
        public double? Weight_Kg { get; set; }
        public decimal Refund_Amount { get; set; } 
        public DateTime Return_Date { get; set; }

        public int SoldGood_Id { get; set; }
        [ForeignKey("SoldGood_Id")]
        public SoldGood SoldGood { get; set; } = null!;
    }
}
