namespace Shop.Repo.Models
{
    public class EditGoodsModel
    {
        public string Product_Name { get; set; } = null!;
        public decimal Import_Price { get; set; }
        public int? Quantity { get; set; }
        public string? Category { get; set; }
        public double? Weight_KG { get; set; }
        public string Supplier_Name { get; set; } = null!;
    }
}
