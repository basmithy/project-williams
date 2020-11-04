using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.F1.Context;
using Project.F1.Models;

namespace Project.F1.Controllers
{
    public class ConstructorsController : Controller
    {
        private readonly DbInitializer _context;

        public ConstructorsController(DbInitializer context)
        {
            _context = context;
        }

        // GET: Constructors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Constructors.Include(x => x.Drivers).ToListAsync());
        }

        // GET: Constructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructor = await _context.Constructors
                .FirstOrDefaultAsync(m => m.ConstructorId == id);
            if (constructor == null)
            {
                return NotFound();
            }

            return View(constructor);
        }

        // GET: Constructors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Constructors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConstructorId,ConstructorName,ConstructorColour,ConstructorTotalPoints")] Constructor constructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(constructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(constructor);
        }

        // GET: Constructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructor = await _context.Constructors.FindAsync(id);
            if (constructor == null)
            {
                return NotFound();
            }
            return View(constructor);
        }

        // POST: Constructors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConstructorId,ConstructorName,ConstructorColour,ConstructorTotalPoints")] Constructor constructor)
        {
            if (id != constructor.ConstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(constructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConstructorExists(constructor.ConstructorId))
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
            return View(constructor);
        }

        // GET: Constructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var constructor = await _context.Constructors
                .FirstOrDefaultAsync(m => m.ConstructorId == id);
            if (constructor == null)
            {
                return NotFound();
            }

            return View(constructor);
        }

        // POST: Constructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var constructor = await _context.Constructors.FindAsync(id);
            _context.Constructors.Remove(constructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConstructorExists(int id)
        {
            return _context.Constructors.Any(e => e.ConstructorId == id);
        }
    }
}
