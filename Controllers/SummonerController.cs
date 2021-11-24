using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace TftTracker.Controllers
{
    public class SummonerController : Controller
    {
        // 
        // GET: /Summoner/
        public string Index()
        {
            return "Only you can hear me summoner...";
        }
    }
}