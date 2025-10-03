namespace MovieApi.Data;
using MovieApi.Models;

public class Seed
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Movies.Any())
        {
            context.Movies.AddRange(
                new Movie { Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010 },
                new Movie { Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008 },
                new Movie { Title = "Titanic", Genre = "Romance", ReleaseYear = 1997 }
            );
        }

        if (!context.Users.Any())
        {
            context.Users.AddRange(
                new User { Username = "admin", Email = "admin@example.com", PasswordHash = "hashedpassword", Role = "Admin" },
                new User { Username = "user", Email = "user@example.com", PasswordHash = "hashedpassword", Role = "User" }
            );
        }

        context.SaveChanges();
    }
}