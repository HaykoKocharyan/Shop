using Microsoft.EntityFrameworkCore;
using Shop.Repo.Entities;

namespace Shop.Repo.Repositories
{
    public class ShopDBContext : DbContext
    {
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SoldGoods> SoldGoods { get; set; }
        public DbSet<ReturnedGoods> ReturnedGoods { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public ShopDBContext()
        {

        }
        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Shop;Username=postgres;Password=Hhkk0407",
                b => b.MigrationsAssembly("ShopWebApi"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Created_Date)
                .HasColumnType("timestamp")
                .HasDefaultValueSql("now()")
                .IsRequired();
            });
            modelBuilder.Entity<ReturnedGoods>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Return_Date)
               .HasColumnType("timestamp")
               .HasDefaultValueSql("now()")
               .IsRequired();
            });
            modelBuilder.Entity<SoldGoods>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Sold_Date)
              .HasColumnType("timestamp")
              .HasDefaultValueSql("now()")
              .IsRequired();
            });
            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Created_Date)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("now()")
            .IsRequired();
            });
            modelBuilder.Entity<Workers>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Work_Start_Date)
           .HasColumnType("timestamp")
           .HasDefaultValueSql("now()")
           .IsRequired();
            });
        }
    }
}
