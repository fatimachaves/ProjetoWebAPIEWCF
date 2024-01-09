using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCFServiceHost.Domain;

namespace WCFServiceHost.MyConecction.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasKey(p => p.IdAddress);
            builder.Property(p => p.CEP).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Logradouro).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Numero).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Complemento).HasColumnType("VARCHAR(100)");
            builder.Property(p => p.Bairro).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.Cidade).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(p => p.UF).HasColumnType("VARCHAR(100)").IsRequired();
        }
    }
}