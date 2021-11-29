using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_MigrationTecSolution2021.Data;
using E_MigrationTecSolution2021.Models;

namespace E_MigrationTecSolution2021.Controllers
{
    public class RegistroNecsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroNecsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegistroNecs
        public async Task<IActionResult> Index()
        {
            return View(await _context.registroNecs.ToListAsync());
        }

        // GET: RegistroNecs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroNec = await _context.registroNecs
                .FirstOrDefaultAsync(m => m.Nit == id);
            if (registroNec == null)
            {
                return NotFound();
            }

            return View(registroNec);
        }

        // GET: RegistroNecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistroNecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nit,Descripcion,prioridad,categoria,Estado")] RegistroNec registroNec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroNec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registroNec);
        }

        // GET: RegistroNecs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroNec = await _context.registroNecs.FindAsync(id);
            if (registroNec == null)
            {
                return NotFound();
            }
            return View(registroNec);
        }

        // POST: RegistroNecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nit,Descripcion,prioridad,categoria,Estado")] RegistroNec registroNec)
        {
            if (id != registroNec.Nit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroNec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroNecExists(registroNec.Nit))
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
            return View(registroNec);
        }

        // GET: RegistroNecs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroNec = await _context.registroNecs
                .FirstOrDefaultAsync(m => m.Nit == id);
            if (registroNec == null)
            {
                return NotFound();
            }

            return View(registroNec);
        }

        // POST: RegistroNecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var registroNec = await _context.registroNecs.FindAsync(id);
            _context.registroNecs.Remove(registroNec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroNecExists(string id)
        {
            return _context.registroNecs.Any(e => e.Nit == id);
        }
    }
}
