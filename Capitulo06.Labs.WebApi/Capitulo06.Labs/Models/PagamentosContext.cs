using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//precisamos importar o EntityFramework
using System.Data.Entity;


namespace Capitulo06.Labs.Models
{
    public class PagamentosContext : DbContext
    {
        /*via construtor configuramos a conexão do banco de dados para o Entity
         */
        public PagamentosContext() : base("name=PagamentosConnection")
        {

        }

        //Criaremos as propriedades do tipo DBSET<T> que são
        //responsaveis por associar as classes as tabelas no BD
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Fatura> Faturas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cartao>().ToTable("TBCartoes");
            modelBuilder.Entity<Cartao>().Property(p => p.NumeroCartao).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<Cartao>().Property(p => p.Limite).IsRequired();
            modelBuilder.Entity<Fatura>().ToTable("TBFaturas");
            modelBuilder.Entity<Fatura>().Property(p => p.NumeroCartao).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<Fatura>().Property(p => p.NumeroPedido).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Fatura>().Property(p => p.Valor).IsRequired();

        }

    }
}