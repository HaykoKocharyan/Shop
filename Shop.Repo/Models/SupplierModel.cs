using System.ComponentModel.DataAnnotations;

namespace Shop.Repo.Models
{
    public class SupplierModel
    {
        public string Name { get; set; } = null!;
        public string? Contact_Person { get; set; }

        [EmailAddress(ErrorMessage ="Invalid Email Format")]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}
