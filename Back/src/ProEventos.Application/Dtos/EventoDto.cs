using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
         public int Id { get; set; }

        public string Local { get; set; }

        public string DataEvento { get; set; }
       
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tema { get; set; }
       
        [Display(Name ="Quantidade de pessoas")]
        [Range(1, 120000, ErrorMessage="{0} Não pode ser menor que1 e maior que 120.000")]
        public int QtPessoas { get; set; }

        public string ImagemURL { get; set; }
        
        [Required(ErrorMessage="O Campo {0} é obrigat´rio.")]
        public string Telefone { get; set; }
        
        [Display(Name ="e-mail"),
        EmailAddress(ErrorMessage="o campo {0} deve ser válido")]
        public string Email { get; set; }

        public IEnumerable<LoteDto> Lotes { get; set; }

        public IEnumerable<RedeSocialDto> RedesSociais { get; set; }

        public IEnumerable<PalestranteDto> Palestrantes { get; set; } 
    }
}