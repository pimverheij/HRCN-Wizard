using System;
using System.Collections.Generic;
using System.Text;

namespace HRControlNet.Core.Data.Models
{
    public class Reintegratie
    {
        public int Id { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime? Einddatum { get; set; }
        public string Opmerking { get; set; }
    }
}
