using Microsoft.EntityFrameworkCore;
using YienExpressAPI.Model;


namespace YienExpressAPI.Data

{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }
        public DbSet<Package> Packages { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<YienEmployee> yienEmployees { get; set; }

        public DbSet<User> users { get; set; }
        public DbSet<CoporateCustomer> coporateCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>().
                Property(p => p.Price).HasColumnType("decimal(18,2)");
        }

        

      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var connection = "Data Source = POOJITH; Initial Catalog = YienDB; TrustServerCertificate=True;Persist Security Info=True;Integrated Security = True";

            optionsBuilder.UseSqlServer(connection);
        }
    }
}
