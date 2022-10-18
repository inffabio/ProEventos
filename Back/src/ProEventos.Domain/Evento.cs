using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ProEventos.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} � obrigat�rio.")]
        public string Local { get; set; }
        [Required]
        public DateTime? DataEvento { get; set; }

        [Required(ErrorMessage ="O campo {0} � obrigat�rio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage="Intervalo permitido de 3 a 50 caracteres.")]
        public string Tema { get; set; }

        [Display (Name = "Qtd Pessoas")]
        [Range(1, 120000, ErrorMessage = "{0} n�o pode ser menor que 1 e maior que 120.000")]
        public int QtPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage ="N�o � uma imagen v�lida. (gif, jpg, jpeg, bmp ou png")]
        public string ImagemURL { get; set; }
        [Phone(ErrorMessage =" O campo {0} est� com n�mero inv�lido")]
        [Required(ErrorMessage ="O campo {0} � obrigat�rio")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = " O campo {0} � obrigat�rio.")]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage ="� necess�rio ser um {0} v�lido")]
        public string Email { get; set; }

        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }

        public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }



    }

}