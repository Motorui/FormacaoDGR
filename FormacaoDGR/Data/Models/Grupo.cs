﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace FormacaoDGR.Data.Models
{
    [Table("Grupos")]
    public class Grupo : IBaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        private string _nome;
        [Required(ErrorMessage = "O campo Nome é obrigatório"), Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "O campo {0} deve de conter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public string Nome
        {
            get => _nome;
            set => _nome = value?.ToUpper(CultureInfo.InvariantCulture);
        }

        #region Relações
        public virtual ICollection<Empresa> Empresas { get; set; }
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
