using ApiModeloDDD.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ApiModeloDDD.Infra.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dataImportacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("dataImportacao").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("dataImportacao").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}