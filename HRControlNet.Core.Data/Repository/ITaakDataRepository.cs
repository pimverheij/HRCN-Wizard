using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRControlNet.Core.Data.Repository
{
    public interface ITaakDataRepository
    {
        Task SlaTaakDataOp(int taakId, string taakData);
        Task<string> ReadTaakData(int taakId);
    }
}
