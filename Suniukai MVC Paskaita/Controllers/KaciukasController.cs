#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Suniukai_MVC_Paskaita.Data;
using Suniukai_MVC_Paskaita.Models;

namespace Suniukai_MVC_Paskaita.Controllers
{
    public class KaciukasController : Controller
    {
        private readonly SuniukaiDbContext _context;

        public KaciukasController(SuniukaiDbContext context)
        {
            _context = context;
        }

        // GET: Kaciukas
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kaciukai.ToListAsync());
        }

        // GET: Kaciukas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaciukas = await _context.Kaciukai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kaciukas == null)
            {
                return NotFound();
            }

            return View(kaciukas);
        }

        // GET: Kaciukas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kaciukas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vardas,Nuotrauka,Aprasymas")] Kaciukas kaciukas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kaciukas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kaciukas);
        }

        // GET: Kaciukas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaciukas = await _context.Kaciukai.FindAsync(id);
            if (kaciukas == null)
            {
                return NotFound();
            }
            return View(kaciukas);
        }

        // POST: Kaciukas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vardas,Nuotrauka,Aprasymas")] Kaciukas kaciukas)
        {
            if (id != kaciukas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kaciukas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KaciukasExists(kaciukas.Id))
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
            return View(kaciukas);
        }

        // GET: Kaciukas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kaciukas = await _context.Kaciukai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kaciukas == null)
            {
                return NotFound();
            }

            return View(kaciukas);
        }

        // POST: Kaciukas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kaciukas = await _context.Kaciukai.FindAsync(id);
            _context.Kaciukai.Remove(kaciukas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KaciukasExists(int id)
        {
            return _context.Kaciukai.Any(e => e.Id == id);
        }
    }
}
