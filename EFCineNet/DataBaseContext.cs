using System.Data.Entity;

namespace EFCineNet
{
    public class DataBaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
