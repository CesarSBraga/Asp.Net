using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Impacta.WebApi.Clientes.Models;


namespace Impacta.WebApi.Clientes.Repository
{

    /* para configurar o EF dentro da sua classe de contexto
     *  vc precisa da conection String para o banco de dados
     *  para passar para o contrutor da classe PAI (base) */

    public class Contexto : DbContext // é a principal classe do Entity 
    {
        /*Uma vez esteja trabalhando com EF CodeFirst, voce precisa passar
         para EF o endereco do seu banco de dados 
        atraves do construtor do DbContex*/
        public Contexto() : base("name=ConexaoDb")
        {
        }

        /*O EF precisa saber quais são as classes que ele precisa mapear para 
         o banco de dados (DE/Para das tabelas para as classes)
        Sao atraves das propriedade DBSET <T> que isso acontece*/
        public DbSet<Cliente> Clientes { get; set; }

    }
}