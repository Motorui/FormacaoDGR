using MyWaySO.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyWaySO.Areas.Identity.Models
{
    public class Uh : IBaseEntity
    {
        [Key]
        public Guid UhID { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório"), Display(Name = "Nome:")]
        [StringLength(10, ErrorMessage = "O campo {0} deve de conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string UhNome { get; set; }

        [Required(ErrorMessage = "O campo IATA é obrigatório"), Display(Name = "IATA:")]
        [StringLength(3, ErrorMessage = "O campo {0} deve de conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string UhIATA { get; set; }

        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }
    }
}
