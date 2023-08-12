using FragranceHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FragranceHub.Data.Configurations
{
    public class FragranceAccordsEntityConfig : IEntityTypeConfiguration<FragranceAccords>
    {
        public void Configure(EntityTypeBuilder<FragranceAccords> builder)
        {
            builder.HasKey(fa => new { fa.FragranceId, fa.AccordsId });

            builder
        .HasOne(fa => fa.Fragrance)
        .WithMany(f => f.FragrancesAccords)
        .HasForeignKey(fa => fa.FragranceId);

            builder
                .HasOne(fa => fa.Accords)
                .WithMany()
                .HasForeignKey(fa => fa.AccordsId);

        }
    }
}
