using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReviewsAsArt.Data.Mappers;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Bericht> Berichten { get; set; }
        public DbSet<Commentaar> Commentaars { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewgenre> Reviewgenres { get; set; }
        public DbSet<Werk> Werken { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BerichtConfiguration());
            builder.ApplyConfiguration(new CommentaarConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new ReviewGenreConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new WerkConfiguration());
        }
    }
}
