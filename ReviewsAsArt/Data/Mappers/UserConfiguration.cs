using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data.Mappers
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasMany(s => s.Berichten).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.Reviews).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
