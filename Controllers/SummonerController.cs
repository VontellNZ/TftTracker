using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
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

        public IActionResult Index()
        {
            var results = _context.Summoners.OrderBy(summoner => summoner.id).ToList();

            return View(results);
        }
    }
}