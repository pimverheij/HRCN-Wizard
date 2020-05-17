using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaakService.Models;
using TaakService.Services;

namespace TaakService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReintegratieTestTaakController : ControllerBase
    {
        private readonly ExecuteTaakService<ReintegratieTestTaakModel> reintegratieTestTaakService;

        public ReintegratieTestTaakController(ExecuteTaakService<ReintegratieTestTaakModel> reintegratieTestTaakService)
        {
            this.reintegratieTestTaakService = reintegratieTestTaakService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await reintegratieTestTaakService.ReadTaakModel(id));
        }

        //[HttpGet(nameof(Stap1))]
        //public Task<IActionResult> Stap1()
        //{
        //    return Ok();
        //}

        // POST: api/ReintegratieTestTaak
        [HttpPost(nameof(Stap1))]
        public void Stap1([FromBody] string value)
        {
        }
    }
}
