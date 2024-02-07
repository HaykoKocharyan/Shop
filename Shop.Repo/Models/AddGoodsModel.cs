namespace Shop.Repo.Models
{
    public class AddGoodsModel
    {
        public string Product_Name { get; set; } = null!;
        public decimal Import_Price { get; set; } 
        public int? Quantity { get; set; }
        public string? Category { get; set; }
        public double? Weight_KG { get; set; }
        public int Supplier_Id { get; set; }
    }
}
