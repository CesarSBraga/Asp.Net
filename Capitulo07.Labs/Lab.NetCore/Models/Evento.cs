using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab.NetCore.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Data do evento")]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        public string Local { get; set; }

        public double Preco { get; set; }


        public ICollection<Participante> Participantes { get; set; }

    }
}
