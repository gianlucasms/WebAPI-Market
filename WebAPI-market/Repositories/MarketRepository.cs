﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_market.Model;

namespace WebAPI_market.Repositories
{
    public class MarketRepository : IMarketRepository
    {
        public readonly MarketContext _context;
        public MarketRepository(MarketContext context)
        {
            _context = context;
        }
        public async Task<Market> CreateAsync(Market market)
        {
            _context.Markets.Add(market);
            await _context.SaveChangesAsync();
            
            return market;
        }

        public async Task DeleteAsync(int id)
        {
            var marketToDelete = await _context.Markets.FindAsync(id);
            _context.Markets.Remove(marketToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Market>> GetAsync()
        {
           return await _context.Markets.ToListAsync();
        }

        public async Task<Market> GetAsync(int id)
        {
           return await _context.Markets.FindAsync(id);
        }

        public async Task UpdateAsync(Market market)
        {
            _context.Entry(market).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
