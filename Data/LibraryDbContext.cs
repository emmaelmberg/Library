using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Data;

public class LibraryDbContext : DbContext {
public LibraryDbContext(DbContextOptions<LibraryDbContext>
options) : base(options) { }

public DbSet<LibraryModel> Libraries { get; set; }
}