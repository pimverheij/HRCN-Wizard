using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaakService.Models;

namespace TaakService.Messages.Queries
{
    public class ReadTaakQuery : IQuery<TaakModel>
    {
        public int Id { get; set; }
    }
}
