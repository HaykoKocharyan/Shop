namespace Shop.Repo.Models
{
    public class ReturnGoodModel
    {
        public int SoldGood_Id { get; set; }
        public string? Reason { get; set; }
        public int? Quantity { get; set; }
        public double? Weight_Kg { get; set; }
        public decimal Refound_Amount { get; set; }
    }
}
