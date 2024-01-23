using Microsoft.EntityFrameworkCore;

namespace ApiExample.Database;
public class ListContext : DbContext
{
    private string DbPath { get; }
    public DbSet<ListItem> ListItems { get; set; }
    
    public ListContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "list.db");
    }

    // The following configures EF to create a SqlServer database 
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Data Source={DbPath}");
}