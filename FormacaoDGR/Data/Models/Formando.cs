using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FormacaoDGR.Data.Models
{
    [Table("Formandos")]
    public class Formando : IBaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        private string _nome;
        [Required, Display(Name = "Nome")]
        public string Nome
        {
            get => _nome;
            set => _nome = value?.ToUpper(CultureInfo.InvariantCulture);
        }

        [Display(Name = "Interno?")]
        public bool Interno { get; set; }

        #region Relações
        [Display(Name = "Empresa")]
        public Guid? EmpresaID { get; set; }
        public Empresa Empresa { get; set; }

        [Display(Name = "Departamento")]
        public Guid? DepartamentoID { get; set; }
        public Departamento Departamento { get; set; }

        public virtual ICollection<FormandoDetalhe> FormandosDetalhes { get; set; }
        public virtual ICollection<CursosFormando> CursosFormandos { get; set; }
        public virtual ICollection<RefrescamentosFormando> RefrescamentosFormandos { get; set; }

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
