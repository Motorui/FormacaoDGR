using FormacaoDGR.Areas.Identity.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormacaoDGR.Data.Models
{
    [Table("MarcacoesIniciais")]
    public class MarcacaoInicial : IBaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        [Required, Display(Name = "Data de início", ShortName = "Início")]
        public DateTime DataInicio { get; set; }

        [Required, Display(Name = "Data de fim", ShortName = "Fim")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O campo Capaciade é obrigatório"), Display(Name = "Capaciade")]
        public int Capaciade { get; set; }

        #region Relações
        [Required, Display(Name = "Sala")]
        public Guid SalaID { get; set; }
        public Sala Sala { get; set; }

        [Required, Display(Name = "Curso")]
        public Guid CursoID { get; set; }
        public Curso Curso { get; set; }

        [Required, Display(Name = "Unidade de hanling", ShortName = "UH")]
        public Guid UhID { get; set; }
        public Uh Uh { get; set; }
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
