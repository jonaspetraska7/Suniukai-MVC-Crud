#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Suniukai_MVC_Paskaita.Data;
using Suniukai_MVC_Paskaita.Models;

namespace Suniukai_MVC_Paskaita.Controllers
{
    public class SuniukasController : Controller
    {
        private readonly SuniukaiDbContext _context;

        public SuniukasController(SuniukaiDbContext context)
        {
            _context = context;
        }

        // GET: Suniukas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Suniukai.ToListAsync());
        }

        // GET: Suniukas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suniukas = await _context.Suniukai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suniukas == null)
            {
                return NotFound();
            }

            return View(suniukas);
        }

        // GET: Suniukas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suniukas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vardas,Nuotrauka,Aprasymas")] Suniukas suniukas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suniukas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suniukas);
        }

        // GET: Suniukas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suniukas = await _context.Suniukai.FindAsync(id);
            if (suniukas == null)
            {
                return NotFound();
            }
            return View(suniukas);
        }

        // POST: Suniukas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vardas,Nuotrauka,Aprasymas")] Suniukas suniukas)
        {
            if (id != suniukas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suniukas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuniukasExists(suniukas.Id))
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
            return View(suniukas);
        }

        // GET: Suniukas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suniukas = await _context.Suniukai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suniukas == null)
            {
                return NotFound();
            }

            return View(suniukas);
        }

        // POST: Suniukas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suniukas = await _context.Suniukai.FindAsync(id);
            _context.Suniukai.Remove(suniukas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuniukasExists(int id)
        {
            return _context.Suniukai.Any(e => e.Id == id);
        }
    }
}
