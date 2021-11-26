using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TftTracker.Data;

namespace TftTracker.Controllers
{
    public class SummonerController : Controller
    {
        private readonly TftContext _context;

        public SummonerController(TftContext context)
        {
            _context = context;
        }

        //GET: Summoner
        public async Task<IActionResult> Index()
        {
           return View(await _context.Summoners.ToListAsync());
        }

        //GET: Summoner/Details/{name}
        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
                return NotFound();
            
            var summoner = await _context.Summoners.FirstOrDefaultAsync(s => s.name.ToLower().Equals(name.ToLower()));
             if (summoner == null) //This is where we will hit Riot's API if we don't find summoner locally
                return NotFound();

            return View(summoner);
        }
    }
}