using System;
using System.ComponentModel.DataAnnotations;

namespace FormacaoDGR.Data.Models
{
    public class Empresa : IBaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"), Display(Name = "Nome")]
        [StringLength(75, ErrorMessage = "O campo {0} deve de conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Nome { get; set; }

        [Display(Name = "Morada")]
        [StringLength(200, ErrorMessage = "O campo {0} deve de conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Morada { get; set; }

        [Display(Name = "Código Postal")]
        public string CodPostal { get; set; }

        [Display(Name = "Localidade")]
        public string Localidade { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Contato")]
        [StringLength(75, ErrorMessage = "O campo {0} deve de conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Contato { get; set; }

        [Display(Name = "Grupo")]
        public Guid? GrupoID { get; set; }
        public Grupo Grupo { get; set; }

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
