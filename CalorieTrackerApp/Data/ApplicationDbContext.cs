using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrackerCookBookApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Recipe>()
                .HasOne<User>()
                .WithMany(x => x.Recipes)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Ingredient>()
                .HasOne<Recipe>()
                .WithMany(i => i.IngredientsList)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
