using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//DataAnnotation: Devemos importar para utilizar
using System.ComponentModel.DataAnnotations;


namespace Impacta.WebPageRazor.Models
{
    public class Curso
    {
        [Display(Name = "Código")]
        public int ID { get; set; }

        [Required(ErrorMessage = "O Título do curso é obrigatório")]
        [StringLength(15, ErrorMessage = "O número máximo de caracter são 15 p/ o Título")]
        public string Titulo { get; set; }


        [Display(Name = "Valor do Curso")]
        [Range(minimum: 1.0, maximum: 5000.00, ErrorMessage = "Valor do Curso deve ser entre R$ 1,00 e R$ 5.000,00")]
        // exebe numero com padrao decimal de 2 casas
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        [NumeroBrasil(ErrorMessage = "Valor Inválido.", PontoMilharPermitido = true, DecimalRequerido = true)]
        public decimal Valor { get; set; }


        [Required(ErrorMessage = "A Descrição do curso é obrigatório")]
        [Display(Name = "Descrição do curso:", Description = "Fornece uma breve descrição para o curso")]
        [StringLength(50)]
        public string Descricao { get; set; }


    }
}