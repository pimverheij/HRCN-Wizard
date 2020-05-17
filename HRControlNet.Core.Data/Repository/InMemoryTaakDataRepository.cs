using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRControlNet.Core.Data.Repository
{
    public class InMemoryTaakDataRepository : ITaakDataRepository
    {
        private static readonly Dictionary<int, string> taakDataLijst = new Dictionary<int, string>();

        public Task<string> ReadTaakData(int taakId)
        {
            if (!taakDataLijst.ContainsKey(taakId))
                return Task.FromResult<string>(null);

            return Task.FromResult(taakDataLijst[taakId]);
        }

        public Task SlaTaakDataOp(int taakId, string taakData)
        {
            if (taakDataLijst.ContainsKey(taakId))
                taakDataLijst[taakId] = taakData;
            else
                taakDataLijst.Add(taakId, taakData);
            return Task.CompletedTask;
        }
    }
}
