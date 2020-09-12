using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FormacaoDGR.Data.Models
{
    [Table("Departamentos")]
    public class Departamento : IBaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        [Required, Display(Name = "Número", ShortName = "Núm.")]
        public int Numero { get; set; }

        private string _nome;
        [Required, MaxLength(150), Display(Name = "Departamento", ShortName = "Dep.")]
        public string Nome
        {
            get => _nome;
            set => _nome = value?.ToUpper(CultureInfo.InvariantCulture);
        }

        #region Relações
        public virtual ICollection<Formando> Formandos { get; set; }
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
