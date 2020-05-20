using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRControlNet.Core.Data.Repository
{
    public class InMemoryTaakRepository : ITaakRepository
    {
        private static List<Taak> taken = new List<Taak>()
        {
            new Taak
            {
                Id = 1,
                HoortBijEntiteitId = 1,
                HoortBijEntiteitType = Enums.EntiteitType.Reintegratie,
                Startdatum = new DateTime(2020, 05, 01),
                Vervaldatum = new DateTime(2020,05, 01),
                Taakomschrijving = "Dit is een re-integratie testtaak. Deze taak is gemaakt om een POC te kunnen maken van een wizard.",
                Type = Enums.TaakType.ReintegratieTestTaak
            }
        };

        public Task MaakTaakAanAsync(Taak taak)
        {
            taak.Id = taken.Max(t => t.Id) + 1;
            taken.Add(taak);
            return Task.CompletedTask;
        }

        public Task<Taak> ReadTaakAsync(int id)
        {
            return Task.FromResult(taken.SingleOrDefault(taak => taak.Id == id));
        }
    }
}
