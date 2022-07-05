using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace WebApiCadFuncionario.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioId { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public decimal Salario { get; set; }

        public string Cargo { get; set; }

        [Required]
        public string Email { get; set; }


    }
}
