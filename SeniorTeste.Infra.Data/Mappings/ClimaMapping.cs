using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SeniorTeste.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorTeste.Infra.Data.Mappings
{
    public class ClimaMapping : IEntityTypeConfiguration<Clima>
    {
        public void Configure(EntityTypeBuilder<Clima> builder)
        {
            builder.ToTable("Clima");
            builder.HasKey(e => e.Id).HasName("PK_IdClima");
            builder.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(e => e.Temperatura).HasColumnName("Temperatura");
            builder.Property(e => e.DataColeta).HasColumnName("DataColeta");

            builder.Property(e => e.CidadeId).HasColumnName("CidadeId");
            builder.HasOne(e => e.Cidade).WithMany(c => c.Climas).HasForeignKey(e => e.CidadeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
