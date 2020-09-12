using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormacaoDGR.Data.Models
{
    [Table("CursosFormandos")]
    public class CursosFormando
    {
        public Guid FormandoID { get; set; }
        public Guid CursoID { get; set; }

        [ForeignKey("FormandoID")]
        public Formando Formando { get; set; }
        [ForeignKey("CursoID")]
        public Curso Curso { get; set; }
    }
}
