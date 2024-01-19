using System.ComponentModel.DataAnnotations;

namespace Shop.Repo.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Contact_Person { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime Created_Date { get; set; }
        public ICollection<Good> Goods { get; set; } = null!;

    }
}
