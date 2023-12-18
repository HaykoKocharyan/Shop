using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Repo.Models
{
    public class SupplierModel
    {
        public string Supplier_Name { get; set; }
        public string? Contact_Person { get; set; }
        public string? Supplier_Email { get; set; }
        public string? Supplier_Phone { get; set; }
        public string? Supplier_Address { get; set; }
    }
}
