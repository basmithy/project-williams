using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.F1.Context;
using Project.F1.Models;

namespace Project.F1.Controllers
{
    public class RacesController : Controller
    {
        private readonly DbInitializer _context;

        public RacesController(DbInitializer context)
        {
            _context = context;
        }

        // GET: Races
        public async Task<IActionResult> Index()
        {
            var dbInitializer = _context.Races.Include(r => r.Track);
            return View(await dbInitializer.ToListAsync());
        }

        // GET: Races/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races
                .Include(r => r.Track)
                .FirstOrDefaultAsync(m => m.RaceId == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // GET: Races/Create
        public IActionResult Create()
        {
            ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackName");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverName");
            return View();
        }

        // POST: Races/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RaceId,FastestLapDriver,TrackId,Positions")] Race race)
        {
            if (ModelState.IsValid)
            {
                // Adding correct track model
                race.Track = _context.Tracks.Find(race.TrackId);
                // Getting driver name in string form via the ID selected from dropdown box
                race.FastestLapDriver = _context.Drivers.Find(int.Parse(race.FastestLapDriver)).DriverName;
                _context.Add(race);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackName", race.TrackId);
            return View(race);
        }

        // GET: Races/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackId", race.TrackId);
            return View(race);
        }

        // POST: Races/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RaceId,FastestLapDriver,TrackId")] Race race)
        {
            if (id != race.RaceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(race);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaceExists(race.RaceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrackId"] = new SelectList(_context.Tracks, "TrackId", "TrackId", race.TrackId);
            return View(race);
        }

        // GET: Races/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = await _context.Races
                .Include(r => r.Track)
                .FirstOrDefaultAsync(m => m.RaceId == id);
            if (race == null)
            {
                return NotFound();
            }

            return View(race);
        }

        // POST: Races/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var race = await _context.Races.FindAsync(id);
            _context.Races.Remove(race);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaceExists(int id)
        {
            return _context.Races.Any(e => e.RaceId == id);
        }
    }
}
