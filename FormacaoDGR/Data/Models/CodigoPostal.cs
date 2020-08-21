using System.ComponentModel.DataAnnotations;

namespace FormacaoDGR.Data.Models
{
    public class CodigoPostal
    {
        [Key]
        public string cod_postal { get; set; }
        public string localidade { get; set; }
        public string desig_postal { get; set; }

    }
}
