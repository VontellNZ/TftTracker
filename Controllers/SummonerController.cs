using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TftTracker.Api;
using TftTracker.Data;

namespace TftTracker.Controllers
{
    public class SummonerController : Controller
    {
        private readonly TftContext _context;
        private readonly ISummonerProcessor _summonerProcessor;

        public SummonerController(TftContext context, ISummonerProcessor summonerProcessor)
        {
            _context = context;
            _summonerProcessor = summonerProcessor;
        }

        //GET: Summoner
        public async Task<IActionResult> Index()
        {
           return View(await _context.Summoners.ToListAsync());
        }

        //GET: Summoner/Details
        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
                return NotFound();
            
            var summoner = await _context.Summoners.FirstOrDefaultAsync(s => s.Name.ToLower().Equals(name.ToLower()));
            if (summoner == null)
            {
                summoner = await _summonerProcessor.LoadSummoner(name);
                if (summoner == null)
                    return NotFound();
            }

            return View(summoner);
        }
    }
}