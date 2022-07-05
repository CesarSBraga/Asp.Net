using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Lab.NetCore.Models
{
    public class Participante
    {
        public int Id { get; set; }

        [Display(Name ="Evento")]
        public int EventoInfoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Email { get; set; }


        public string Cpf { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }


        public Evento EventoInfo { get; set; }
    }
}
