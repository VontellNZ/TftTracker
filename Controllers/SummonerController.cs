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

        //GET: Movies
        public async Task<IActionResult> Index()
        {
           return View(await _context.Summoners.ToListAsync());
        }

        // GET: Movies/Details
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var summoner = await _context.Summoners.FirstOrDefaultAsync(s => s.accountId == id);
            if (summoner == null)
            return NotFound();

            return View(summoner);
        }
    }
}