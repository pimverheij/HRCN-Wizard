using HRControlNet.Core.Data.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRControlNet.Core.Data.Repository
{
    public interface IReintegratieRepository
    {
        Task<Reintegratie> ReadReintegratieAsync(int id);
    }
}
