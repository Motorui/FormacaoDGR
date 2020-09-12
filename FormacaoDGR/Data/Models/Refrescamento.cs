using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FormacaoDGR.Data.Models
{
    [Table("Refrescamentos")]
    public class Refrescamento : IBaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        private string _nome;
        [Required, Display(Name = "Curso")]
        public string Nome
        {
            get => _nome;
            set => _nome = value?.ToUpper(CultureInfo.InvariantCulture);
        }

        private string _codigo;
        [Required, Display(Name = "Código", ShortName = "Cod.")]
        public string Codigo
        {
            get => _codigo;
            set => _codigo = value?.ToUpper(CultureInfo.InvariantCulture);
        }

        [Required, Display(Name = "Duração", ShortName = "Dur.")]
        public int Duracao { get; set; }

        [Required, Display(Name = "Validade", ShortName = "Val.")]
        public int Validade { get; set; }

        [Display(Name = "Côr")]
        public string Cor { get; set; }

        [Display(Name = "E-learning?")]
        public bool Elearning { get; set; }

        #region Relações
        public Guid CursoID { get; set; }
        public Curso Curso { get; set; }
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
