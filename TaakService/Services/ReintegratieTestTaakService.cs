using HRControlNet.Core.Data;
using HRControlNet.Core.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaakService.Models;

namespace TaakService.Services
{
    public abstract class ExecuteTaakService<TTaakModel>
    {
        private readonly ITaakRepository taakRepository;
        protected Taak Taak;

        public ExecuteTaakService(ITaakRepository taakRepository)
        {
            this.taakRepository = taakRepository;
        }

        public abstract Task<TTaakModel> ReadTaakModel(int id);

        protected async Task InitTaak(int id)
        {
            Taak = await taakRepository.ReadTaakAsync(id);
        }

    }

    public class ReintegratieTestTaakService : ExecuteTaakService<ReintegratieTestTaakModel>
    {
        private readonly IReintegratieRepository reintegratieRepository;

        public ReintegratieTestTaakService(IReintegratieRepository reintegratieRepository, ITaakRepository taakRepository) : base(taakRepository)
        {
            this.reintegratieRepository = reintegratieRepository;
        }

        public override async Task<ReintegratieTestTaakModel> ReadTaakModel(int id)
        {
            await InitTaak(id);
            var reintegratie = await reintegratieRepository.ReadReintegratieAsync(Taak.HoortBijEntiteitId);
            return new ReintegratieTestTaakModel
            {
                ReintegatieId = reintegratie.Id,
                Startdatum = reintegratie.Startdatum,
                Einddatum = reintegratie.Einddatum,
                Opmerking = reintegratie.Opmerking,
            };
        }
    }
}
