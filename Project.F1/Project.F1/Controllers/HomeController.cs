using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.F1.Context;
using Project.F1.Models;

namespace Project.F1.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbInitializer _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DbInitializer context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Driver()
        {
            List<int> positions = new List<int>();
            var drivers = _context.Drivers;

            var recentRace = _context.Races.Include(t => t.Track).Include(p => p.Positions).Include(p => p.Positions).ThenInclude(d => d.Driver).ThenInclude(c => c.Constructor).OrderByDescending(a => a.RaceId).FirstOrDefault();
            var viewModel = new PreviousRaceInfoModel()
            {
                WinnerName = recentRace.Positions.Where(x => x.PositionNumber == 1).FirstOrDefault().Driver.DriverName,
                WinnerPhoto = recentRace.Positions.Where(x => x.PositionNumber == 1).FirstOrDefault().Driver.DriverPhoto,
                WinnerTeamColour = recentRace.Positions.Where(x => x.PositionNumber == 1).FirstOrDefault().Driver.Constructor.ConstructorColour,
                FastestLapName = recentRace.FastestLapDriver,
                FastestLapPhoto = drivers.Where(x => x.DriverName == recentRace.FastestLapDriver).FirstOrDefault().DriverPhoto,
                FastestLapTeamColour = drivers.Where(x => x.DriverName == recentRace.FastestLapDriver).FirstOrDefault().Constructor.ConstructorColour,
                TrackName = recentRace.Track.TrackName
            };
            return View(viewModel);
        }

        public IActionResult Constructor()
        {
            List<int> positions = new List<int>();
            var drivers = _context.Drivers;

            var recentRace = _context.Races.Include(t => t.Track).Include(p => p.Positions).Include(p => p.Positions).ThenInclude(d => d.Driver).ThenInclude(c => c.Constructor).OrderByDescending(a => a.RaceId).FirstOrDefault();
            var viewModel = new PreviousRaceInfoModel()
            {
                WinnerName = recentRace.Positions.Where(x => x.PositionNumber == 1).FirstOrDefault().Driver.DriverName,
                WinnerPhoto = recentRace.Positions.Where(x => x.PositionNumber == 1).FirstOrDefault().Driver.DriverPhoto,
                WinnerTeamColour = recentRace.Positions.Where(x => x.PositionNumber == 1).FirstOrDefault().Driver.Constructor.ConstructorColour,
                FastestLapName = recentRace.FastestLapDriver,
                FastestLapPhoto = drivers.Where(x => x.DriverName == recentRace.FastestLapDriver).FirstOrDefault().DriverPhoto,
                FastestLapTeamColour = drivers.Where(x => x.DriverName == recentRace.FastestLapDriver).FirstOrDefault().Constructor.ConstructorColour,
                TrackName = recentRace.Track.TrackName
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public int GetPointAmountFromPosition(int position)
        {
            int amount = 0;
            switch (position)
            {
                case 1:
                    amount = 25;
                    break;
                case 2:
                    amount = 18;
                    break;
                case 3:
                    amount = 15;
                    break;
                case 4:
                    amount = 12;
                    break;
                case 5:
                    amount = 10;
                    break;
                case 6:
                    amount = 8;
                    break;
                case 7:
                    amount = 6;
                    break;
                case 8:
                    amount = 4;
                    break;
                case 9:
                    amount = 2;
                    break;
                case 10:
                    amount = 1;
                    break;
            }
            return amount;
        }
    }
}
