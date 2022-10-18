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
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Local { get; set; }
        [Required]
        public DateTime? DataEvento { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage="Intervalo permitido de 3 a 50 caracteres.")]
        public string Tema { get; set; }

        [Display (Name = "Qtd Pessoas")]
        [Range(1, 120000, ErrorMessage = "{0} não pode ser menor que 1 e maior que 120.000")]
        public int QtPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage ="Não é uma imagen válida. (gif, jpg, jpeg, bmp ou png")]
        public string ImagemURL { get; set; }
        [Phone(ErrorMessage =" O campo {0} está com número inválido")]
        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = " O campo {0} é obrigatório.")]
        [Display(Name = "e-mail")]
        [EmailAddress(ErrorMessage ="É necessário ser um {0} válido")]
        public string Email { get; set; }

        public IEnumerable<Lote> Lotes { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }

        public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }



    }

}