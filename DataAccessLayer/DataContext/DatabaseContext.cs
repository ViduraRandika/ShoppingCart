using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = optionsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> optionsBuilder { get; set; }

            public DbContextOptions<DatabaseContext> dbOptions { get; set; }

            private AppConfiguration settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<AuthLevel> AuthLevels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new {u.Email})
                .IsUnique(true);
        }
    }
}