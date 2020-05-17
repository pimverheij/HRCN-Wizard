using HRControlNet.Core.Data.Enums;
using System;

namespace TaakService.Models
{
    public class TaakModel
    {
        public int Id { get; set; }
        public TaakType Type { get; set; }
        public int HoortBijEntiteitId { get; set; }
        public virtual EntiteitType HoortBijEntiteitType { get; set; }
        public string Taakomschrijving { get; set; }
        public virtual DateTime Startdatum { get; set; }
        public virtual DateTime? Vervaldatum { get; set; }

        public string TaakData { get; set; }
    }
}
