using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CalorieTrackerCookBookApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { 
        }

        // DbSets for each entity
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<RecipeImage> RecipeImages { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Recipe global query filter
            builder.Entity<Recipe>().HasQueryFilter(r => !r.IsDeleted);

            // Matching query filters for related entities
            builder.Entity<Favorite>().HasQueryFilter(f => !f.Recipe.IsDeleted);
            builder.Entity<Ingredient>().HasQueryFilter(i => !i.Recipe.IsDeleted);
            builder.Entity<RecipeImage>().HasQueryFilter(ri => !ri.Recipe.IsDeleted);

            // Composite Key for Favorite: UserId + RecipeId
            builder.Entity<Favorite>()
                .HasKey(f => new { f.UserId, f.RecipeId });
            
            //builder.Entity<Favorite>()
                //.HasOne(f => f.User)
                //.WithMany(u => u.Favorites)  // One User can have many Favorites
                //.HasForeignKey(f => f.UserId)  // Foreign Key
                //.IsRequired();  // Make it required (optional, based on your needs)

           builder.Entity<Favorite>()
                .HasOne(f => f.Recipe)
                .WithMany(r => r.Favorites)  // One Recipe can be favorited by many users
                .HasForeignKey(f => f.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);  // Foreign Key

            // Define relationships (optional, if not handled by Data Annotations)
            builder.Entity<Recipe>()
                .HasOne(r => r.Owner)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.OwnerId)
                 .OnDelete(DeleteBehavior.Restrict);
            //.IsRequired();
            builder.Entity<Recipe>()
                .HasQueryFilter(c => !c.IsDeleted);

            builder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany()
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            //.IsRequired(); 

            builder.Entity<Comment>()
                .HasQueryFilter(c => !c.IsDeleted);

            builder.Entity<Comment>()
                .HasOne(c => c.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(c => c.RecipeId);

            builder.Entity<RecipeImage>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.Images)
                .HasForeignKey(ri => ri.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Ingredient>()
                .HasOne(i => i.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(i => i.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public override int SaveChanges()
        {
            HandleSoftDeletes();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleSoftDeletes();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void HandleSoftDeletes()
        {
            var deletedRecipes = ChangeTracker.Entries<Recipe>()
                .Where(e => e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in deletedRecipes)
            {
                // Intercept delete and mark as IsDeleted
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;

                // Mark related entities as deleted
                foreach (var favorite in entry.Entity.Favorites)
                    favorite.IsDeleted = true;

                foreach (var ingredient in entry.Entity.Ingredients)
                    ingredient.IsDeleted = true;

                foreach (var image in entry.Entity.Images)
                    image.IsDeleted = true;
            }
        }
    }


}
