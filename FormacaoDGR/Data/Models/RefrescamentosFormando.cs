using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormacaoDGR.Data.Models
{
    [Table("RefrescamentosFormandos")]
    public class RefrescamentosFormando
    {
        public Guid FormandoID { get; set; }
        public Guid RefrescamentoID { get; set; }

        [ForeignKey("FormandoID")]
        public Formando Formando { get; set; }
        [ForeignKey("RefrescamentoID")]
        public Refrescamento Refrescamento { get; set; }
    }
}
