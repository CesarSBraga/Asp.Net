using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab.NetCore.Models;

// temos que incluir o entity framework core comusing abaixo
using Microsoft.EntityFrameworkCore;

namespace Lab.NetCore.Dao
{
    public class EventosContext : DbContext
    {
        //ataves dos metodo construtor recebemos a injeção doe dependencia
        // para criar contrutor é CTOR
        public EventosContext(DbContextOptions<EventosContext>
  opcoes) : base(opcoes)
        { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Evento>().ToTable("TBEventos");
            modelBuilder.Entity<Evento>()
                .Property(p => p.Data)
                .IsRequired();
            modelBuilder.Entity<Evento>()
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Evento>()
                .Property(p => p.Local)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Evento>()
                .Property(p => p.Preco)
                .IsRequired();
            modelBuilder.Entity<Participante>().ToTable("TBParticipantes");
            modelBuilder.Entity<Participante>()
                .Property(p => p.Cpf)
                .IsRequired()
                .HasMaxLength(11);
            modelBuilder.Entity<Participante>()
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Participante>()
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(60);
            modelBuilder.Entity<Participante>()
                .Property(p => p.DataNascimento)
                .IsRequired();
        }


    }
}
