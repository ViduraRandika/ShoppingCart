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
                Settings = new AppConfiguration();
                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                dbOptions = OptionsBuilder.Options;
            }

            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }

            public DbContextOptions<DatabaseContext> dbOptions { get; set; }

            private AppConfiguration Settings { get; set; }
        }

        public static OptionsBuild ops = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
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