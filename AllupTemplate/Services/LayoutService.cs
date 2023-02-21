using AllupTemplate.DataAccessLayer;
using AllupTemplate.Interfaces;
using AllupTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace AllupTemplate.Services
{
    public class LayoutService:ILayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<string,string>> GetSettings() {

            IDictionary<string, string> settings = await _context.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);

            return settings;
        }
    }
}
