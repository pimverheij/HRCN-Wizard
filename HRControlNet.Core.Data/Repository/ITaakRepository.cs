using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRControlNet.Core.Data.Repository
{
    public interface ITaakRepository
    {
        Task MaakTaakAanAsync(Taak taak);
        Task<Taak> ReadTaakAsync(int id);
    }
}
