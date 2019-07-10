using System.Data.Entity;

namespace EFCineNet
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DBCINENET")
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> AddressClient { get; set; }
    }
}
