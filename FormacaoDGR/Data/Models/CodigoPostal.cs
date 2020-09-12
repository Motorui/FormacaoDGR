using System.ComponentModel.DataAnnotations;

namespace FormacaoDGR.Data.Models
{
    public class CodigoPostal
    {
        [Key]
        public string Cod_postal { get; set; }
        public string Localidade { get; set; }
        public string Desig_postal { get; set; }
        public virtual string CpLocalidade
        {
            get { return Cod_postal + " - " + Localidade; }
        }

    }
}
