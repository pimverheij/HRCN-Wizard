using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HRControlNet.Core.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TaakService.MessageHandlers;
using TaakService.Messages.Queries;

namespace TaakService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaakController : ControllerBase
    {
        private readonly IMessageExecutor messageExecutor;
        private readonly ITaakDataRepository taakDataRepository;

        public TaakController(IMessageExecutor messageExecutor, ITaakDataRepository taakDataRepository)
        {
            this.messageExecutor = messageExecutor;
            this.taakDataRepository = taakDataRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new ReadTaakQuery
            {
                Id = id
            };

            var taak = await messageExecutor.ExecuteAsync(query);
            return Ok(taak);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] JsonElement body)
        {
            string json = JsonSerializer.Serialize(body);
            await taakDataRepository.SlaTaakDataOp(id, json);
        }
    }
}
