using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Impacta.WebApi.Clientes.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Display(Name ="Nome do Cliente")]
        [Required(ErrorMessage ="O nome é um campo obrigatório")]
        public string Nome { get; set; }

        public string Endereco { get; set; }

        [Required(ErrorMessage ="O telefone é um campo obrigatório")]
        public string Celular { get; set; }

        [Display(Name ="Data de Aniversário")]
        public DateTime DataAniversario { get; set; }

        [Display(Name ="E-mail Pessoal")]
        [MaxLength(50, ErrorMessage ="O tamanho máximo é 50 caracteres")]
        public string Email { get; set; }





    }
}