using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Entity Framework
using System.Data.Entity;

namespace Impacta.WebPageRazor.Models.Repositorio
{
    // Para o Entity funcionar, devemos importar o Entity e 
    // aplicar a herança da classe DbContext para nossa classe
    // que será referência do nosso banco de dados dentro do projeto
    public class CursoDBContext : DbContext
    {
        public CursoDBContext() : base("name=ConexaoDB")
        {

        }

        // usamos a propriedade do tipo DBSET<T> para indicar ao Entity FrameWork
        // quais tabelas estarao relacionadas com nossas classes

        public DbSet<Curso> Cursos { get; set; }
    }
}