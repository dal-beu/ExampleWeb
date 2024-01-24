using Microsoft.EntityFrameworkCore;

namespace ApiExample.Database;
public class ListContext : DbContext
{

    public DbSet<ListItem> ListItems { get; set; }
    
    public ListContext()
    {
    }

    // The following configures EF to create a SqlServer database 
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Data Source=.;Integrated Security=True;Initial Catalog=ListDb;TrustServerCertificate=True;");
}