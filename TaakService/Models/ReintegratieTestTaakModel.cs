using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaakService.Models
{
    public class ReintegratieTestTaakModel
    {
        public int ReintegatieId { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime? Einddatum { get; set; }
        public string Opmerking { get; set; }
    }
}
