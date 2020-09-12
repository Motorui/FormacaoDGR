using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormacaoDGR.Data.Models
{
    [Table("FormandosDetalhes")]
    public class FormandoDetalhe : IBaseEntity
    {
        [Key, ForeignKey("Formando")]
        public Guid FormandoID { get; set; }

        [Display(Name = "Morada")]
        [StringLength(200, ErrorMessage = "O campo {0} deve de conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Morada { get; set; }

        [Display(Name = "Código Postal")]
        public string CodPostal { get; set; }

        [Display(Name = "Localidade")]
        public string Localidade { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail"), EmailAddress]
        public string Email { get; set; }

        #region Relações
        public Formando Formando { get; set; }
        #endregion

        #region BaseEntity
        [Display(Name = "Registo criado em:", ShortName = "Criado em:")]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Registo criado por:", ShortName = "Criado por:")]
        public string CreatedBy { get; set; }
        [Display(Name = "Registo atualizado em:", ShortName = "Atualizado em:")]
        public DateTime? LastUpdatedAt { get; set; }
        [Display(Name = "Registo atualizado por:", ShortName = "Atualizado por:")]
        public string LastUpdatedBy { get; set; }
        #endregion
    }
}
