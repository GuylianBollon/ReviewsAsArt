using Microsoft.EntityFrameworkCore;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data.Mappers
{
    public class CommentaarConfiguration : IEntityTypeConfiguration<Commentaar>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Commentaar> builder)
        {
            builder.ToTable("Commentaar");
        }
    }
}
