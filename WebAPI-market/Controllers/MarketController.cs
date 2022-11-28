using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using WebAPI_market.Model;
using WebAPI_market.Repositories;

namespace WebAPI_market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketRepository _marketRepository;
        public MarketController(IMarketRepository marketRepository)
        {
            _marketRepository = marketRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Market>> GetMarkets()
        {
            return await _marketRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Market>> GetMarkets(int id)
        {
            return await _marketRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Market>> PostMarket([FromBody] Market market)
        {
            var newMarket = await _marketRepository.Create(market);
            return CreatedAtAction(nameof(GetMarkets), new { id = newMarket.Id}, newMarket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var marketToDelete = await _marketRepository.Get(id);
            if (marketToDelete == null)
                return NotFound();
            await _marketRepository.Delete(marketToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        public async Task<ActionResult> PutMarkets(int id, [FromBody] Market market)
        {
            if(id != market.Id)
                return BadRequest();
                await _marketRepository.Update(market);

            return NoContent();
        }
        
    }
}
