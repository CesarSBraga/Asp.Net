using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using Impacta.WebApi.Clientes.Models;

namespace Impacta.WebApi.Clientes.Repository
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Contexto>
    {
        /*vamos criar um metodo semente, para que o nosso BD inicie com registros
         ja inseridos pelo metodo semente*/
        protected override void Seed(Contexto context)
        {
            base.Seed(context);

            var clienteLista = new List<Cliente>
            {
                new Cliente 
                { 
                    Nome="Chaves da Villa", 
                    Endereco="Rua da Vila s/n",
                    Celular="+521198765454",
                    DataAniversario= new DateTime(1950, 12, 25),
                    Email="chavesvillaa@chaves.com.mx"
                },

                 new Cliente
                {
                    Nome="Madruga da Villa",
                    Endereco="Rua da Vila s/n",
                    Celular="+521198767854",
                    DataAniversario= new DateTime(1938, 11, 12),
                    Email="madrugadavila@madruga.com.mx"
                 }

            };
            foreach (var cliente in clienteLista)
            {
                // criar os registros na base de dados
                context.Clientes.Add(cliente);
               
            }

           var result = context.SaveChanges();


        }

    }
}