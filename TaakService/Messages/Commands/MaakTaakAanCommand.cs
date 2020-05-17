using HRControlNet.Core.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaakService.Messages.Commands
{
    public class MaakTaakAanCommand : ICommand
    {
        public int HoortBijEntiteitId { get; set; }
        public TaakType Type { get; set; }
        public EntiteitType HoortBijEntiteitType { get; set; }
        public string Taakomschrijving { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime? Vervaldatum { get; set; }
    }
}
