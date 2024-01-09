using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFServiceHost.Domain;

namespace WCFServiceHost.MyConecction.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(p => p.IdCliente);
            builder.Property(p => p.CPF).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.RG).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Data_Expedicao).HasColumnType("datetime").IsRequired(false);
            builder.Property(p => p.Orgao_Expedicao).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.UF_Expedicao).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Data_Nascimento).HasColumnType("datetime").IsRequired();
            builder.Property(p => p.Sexo).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Estado_Civil).HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}