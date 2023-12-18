using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Entities
{
    public class Goods
    {
        public int Id { get; set; }
        [Required]
        public string Product_Name { get; set; }
        [Required]
        public decimal Import_Price { get; set; }
        [Required]
        public int? Quantity { get; set; }
        public double? Weight_KG { get; set; }
        public string? Category { get; set; }
        public DateTime Created_Date { get; set; }

        public int Supplier_Id { get; set; }
        [ForeignKey("Supplier_Id")]
        public Suppliers Supplier { get; set; }
    }
}
