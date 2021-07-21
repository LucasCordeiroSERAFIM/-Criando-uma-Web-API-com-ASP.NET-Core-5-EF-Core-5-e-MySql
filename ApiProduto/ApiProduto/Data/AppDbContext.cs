using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProduto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        /*tabelas do banco*/
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*configurações e dados iniciais tabela */
            modelBuilder.Entity<Produto>()
                .Property(p => p.Nome).HasMaxLength(80);/*tamacho maximo do campo*/

            modelBuilder.Entity<Produto>()
               .Property(p => p.Preco).HasPrecision(10,2);/*casas decimais preco,casas depois da ,*/

            modelBuilder.Entity<Produto>()
                .HasData(
                new Produto { Id = 1,Nome="Caderno",Preco=7.50M,Estoque=10},
                new Produto { Id = 2,Nome = "Revista Play Boy",Preco = 2.50M,Estoque = 30},
                new Produto { Id = 3, Nome = "Compaço", Preco = 1.50M, Estoque = 100 }
                );
        }
    }
}
