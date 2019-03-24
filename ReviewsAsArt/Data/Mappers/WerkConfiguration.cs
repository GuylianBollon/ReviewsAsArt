using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data.Mappers
{
    public class WerkConfiguration : IEntityTypeConfiguration<Werk>
    {
        public void Configure(EntityTypeBuilder<Werk> builder)
        {
            builder.ToTable("Werk");
            builder.HasKey(r => new { r.Titel, r.Creatiejaar, r.Media});
            builder.Property(r => r.Titel).IsRequired();
            builder.Property(r => r.Media).IsRequired();
            builder.Property(r => r.Creatiejaar).IsRequired();
        }
    }
}
