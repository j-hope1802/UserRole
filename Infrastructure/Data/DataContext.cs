using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Context;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<UserRoles>()
            .HasKey(bc => new { bc.UserId, bc.RoleId });

              modelBuilder.Entity<RolePremission>()
            .HasKey(bc => new { bc.RoleId, bc.PremissionId });
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePremission> RolePremissions { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
     public DbSet<Permission>Permissions{get;set;}
    
}
