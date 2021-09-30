using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineApiRest.Model;

namespace WineApiRest.Services
{
    public class WineService : IWineService
    {
        private readonly WineDbContext _context;

        public WineService(WineDbContext context)
        {
            _context = context;
        }

        public async Task<Wine> GetWine(uint id)
        {
            return  await _context.Wines.FindAsync(id);
        }
    }
}
