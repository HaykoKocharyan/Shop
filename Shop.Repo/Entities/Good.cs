using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Entities
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Import_Price { get; set; }
        public int? Quantity { get; set; }
        public double? Weight_KG { get; set; }
        public string? Category { get; set; }
        public DateTime Created_Date { get; set; }

        public int Supplier_Id { get; set; }
        [ForeignKey("Supplier_Id")]
        public Supplier Supplier { get; set; } = null!;
    }
}
