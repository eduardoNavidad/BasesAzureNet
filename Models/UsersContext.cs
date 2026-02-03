using Microsoft.EntityFrameworkCore;

namespace ApiSqlAzure.Models;

public class UsersContext : DbContext
{
   public UsersContext(DbContextOptions options) : base(options)
   {
    
   }
    
    public DbSet<Users> Users { get; set; }
}
