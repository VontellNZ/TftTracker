using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TftTracker.Controllers
{
    public class SummonerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}