using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI_market.Model;

namespace WebAPI_market.Repositories
{
    public interface IMarketRepository 
    {
        Task<IEnumerable<Market>> Get();
        Task<Market> Get(int Id);
        Task<Market> Create(Market market);
        Task Update(Market market);
        Task Delete(int Id);
    }
}
