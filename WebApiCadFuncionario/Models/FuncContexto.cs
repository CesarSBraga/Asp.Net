using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApiCadFuncionario.Models
{
    public class FuncContexto : DbContext
    {
        // após aplicar a herança de DbContext, você deve
        // criar o construtor e passar o options que detem
        // as informações da string de conexão para a classe PAI (base)

        public FuncContexto(DbContextOptions options) : base(options)
        {

        }

        /* propriedade DBSet<T> é o responsável por associar a sua classe
         * com as suas tabelas , ela faz o mapeamento logico
         * entre tabelas e Classes */

        public DbSet<Funcionario> Funcionarios { get; set; }



    }
}
