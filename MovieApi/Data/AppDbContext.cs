using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    // Add roles if needed
}
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // or use RoleId for navigation
}

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
}