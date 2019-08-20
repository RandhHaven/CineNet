using System.Data.Entity;

namespace EFCineNet
{
    public class DataBaseContext : DbContext
    {
        string name = System.Configuration.ConfigurationManager.AppSettings["name"].ToString();
        public DataBaseContext() : base("DBCINENET")
        {
        }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Address> AddressClient { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .Property(e => e.UserId);

            modelBuilder.Entity<Client>()
              .Property(e => e.ClientId);

            modelBuilder.Entity<Address>()
              .Property(e => e.AddressId);
        }
    }
}
