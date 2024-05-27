using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeniorTeste.Domain.Entity;

namespace SeniorTeste.Infra.Data.Mappings
{
    public class CidadeMapping : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidade");
            builder.HasKey(e => e.Id).HasName("PK_IdCidade");
            builder.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(e => e.Lat).HasColumnName("Lat");
            builder.Property(e => e.Lon).HasColumnName("Lon");
            builder.Property(e => e.Nome).HasColumnName("Nome");
        }
    }
}

