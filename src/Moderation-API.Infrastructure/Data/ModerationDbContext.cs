namespace Moderation_API.Infrastructure.Data;

using Moderation_API.Core.Exercises.Models;
using Moderation_API.Core.Food.Models;
using Moderation_API.Core.SportSupplements.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ModerationDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Food> Food { get; set; }
    public DbSet<SportSupplement> SportSupplements { get; set; }

    public ModerationDbContext(DbContextOptions<ModerationDbContext> options) : base(options) { }
}