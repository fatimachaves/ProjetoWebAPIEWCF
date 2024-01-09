﻿using Microsoft.EntityFrameworkCore;
using WCFServiceHost.Domain;
using WCFServiceHost.MyConecction.Configurations;

namespace WebAPI.MyConecction
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() : base()
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Address> Addresss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=CHRISTOFAN;Initial Catalog=ConectionGTIWCF;Integrated Security=True;");
        }
   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());

            modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Address)
            .WithOne(e => e.Cliente)
            .HasForeignKey<Address>(e => e.ClienteRef);

          
            modelBuilder.Entity<Cliente>()
                .HasOne(c => c.Address)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Address>(e => e.ClienteRef)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }

}
