using HRControlNet.Core.Data.Enums;
using System;

namespace HRControlNet.Core.Data
{
    public class Taak
    {
        public int Id { get; set; }
        public TaakType Type { get; set; }
        public int HoortBijEntiteitId { get; set; }
        public virtual EntiteitType HoortBijEntiteitType { get; set; }
        public string Taakomschrijving { get; set; }
        public virtual DateTime Startdatum{ get; set; }
        public virtual DateTime? Vervaldatum { get; set; }
    }
}
