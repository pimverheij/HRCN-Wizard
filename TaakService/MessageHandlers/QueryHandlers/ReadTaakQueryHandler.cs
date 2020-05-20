using AutoMapper;
using HRControlNet.Core.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaakService.Messages.Queries;
using TaakService.Models;

namespace TaakService.MessageHandlers.QueryHandlers
{
    public class ReadTaakQueryHandler : IQueryHandler<ReadTaakQuery, TaakModel>
    {
        private readonly ITaakRepository taakRepository;
        private readonly IMapper mapper;
        private readonly ITaakDataRepository taakDataRepository;

        public ReadTaakQueryHandler(ITaakRepository taakRepository, IMapper mapper, ITaakDataRepository taakDataRepository)
        {
            this.taakRepository = taakRepository;
            this.mapper = mapper;
            this.taakDataRepository = taakDataRepository;
        }

        public async Task<TaakModel> HandleAsync(ReadTaakQuery query)
        {
            var taak = await taakRepository.ReadTaakAsync(query.Id);
            if (taak == null)
                return null;

            var taakModel = mapper.Map<TaakModel>(taak);
            taakModel.TaakData = await taakDataRepository.ReadTaakData(query.Id);
            return taakModel;
        }
    }
}
