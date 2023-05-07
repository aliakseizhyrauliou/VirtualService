using Microsoft.EntityFrameworkCore;
using VirtualServiceWeb.Data.Models;

namespace VirtualServiceWeb.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<InstanceModel> Instance { get; set; }

}