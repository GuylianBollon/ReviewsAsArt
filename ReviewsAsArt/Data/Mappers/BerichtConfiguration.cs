using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReviewsAsArt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAsArt.Data.Mappers
{
    public class BerichtConfiguration : IEntityTypeConfiguration<Bericht>
    {
        public void Configure(EntityTypeBuilder<Bericht> builder)
        {
            builder.ToTable("Bericht");
        }
    }
}
