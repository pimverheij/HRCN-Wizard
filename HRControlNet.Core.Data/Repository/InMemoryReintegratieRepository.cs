using HRControlNet.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRControlNet.Core.Data.Repository
{
    public class InMemoryReintegratieRepository : IReintegratieRepository
    {
        private static List<Reintegratie> reintegraties = new List<Reintegratie>
        {
            new Reintegratie
            {
                Id = 1,
                Startdatum = new DateTime(2020, 04, 01),
                Opmerking = "Dit is een test reintegratie"
            }
        };

        public Task<Reintegratie> ReadReintegratieAsync(int id)
        {
            return Task.FromResult(reintegraties.Single(reintegratie => reintegratie.Id == id));
        }
    }
}
