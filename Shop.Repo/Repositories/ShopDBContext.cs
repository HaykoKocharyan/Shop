using Microsoft.EntityFrameworkCore;
using Shop.Repo.Entities;

namespace Shop.Repo.Repositories
{
    public class ShopDBContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SoldGood> SoldGoods { get; set; }
        public DbSet<ReturnedGood> ReturnedGoods { get; set; }
        public DbSet<Worker> Workers { get; set; }
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
            modelBuilder.Entity<Good>(entity =>
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
            modelBuilder.Entity<ReturnedGood>(entity =>
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
            modelBuilder.Entity<SoldGood>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("Id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Date)
              .HasColumnType("timestamp")
              .HasDefaultValueSql("now()")
              .IsRequired();
            });
            modelBuilder.Entity<Supplier>(entity =>
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
            modelBuilder.Entity<Worker>(entity =>
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
