using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormacaoDGR.Areas.Identity.Models
{
    public class AssignedUhData
    {
        public Guid UhID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
