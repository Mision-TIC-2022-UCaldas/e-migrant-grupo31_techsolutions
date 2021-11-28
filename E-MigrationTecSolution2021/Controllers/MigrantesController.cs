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
    public class MigrantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MigrantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Migrantes
        public async Task<IActionResult> Index(string Busqueda )
        {
            ViewData["CurrentFilter"] = Busqueda;

            var busqueda = from b in _context.Migrantes select b;

            if (!String.IsNullOrEmpty(Busqueda))
            {
                busqueda = busqueda.Where(b =>
                                            b.TId.Contains(Busqueda));
            }

            return View(await busqueda.AsNoTracking().ToListAsync());

        }

        // GET: Migrantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrante = await _context.Migrantes
                .FirstOrDefaultAsync(m => m.NId == id);
            if (migrante == null)
            {
                return NotFound();
            }

            return View(migrante);
        }

        // GET: Migrantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Migrantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NId,TId,Nombre,Apellidos,Pais,AñoNacimiento,MesNacimiento,DiaNacimiento,CorreoElectronico,NTel,DireccionActual,Ciudad,SituacionLaboral")] Migrante migrante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(migrante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(migrante);
        }

        // GET: Migrantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrante = await _context.Migrantes.FindAsync(id);
            if (migrante == null)
            {
                return NotFound();
            }
            return View(migrante);
        }

        // POST: Migrantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NId,TId,Nombre,Apellidos,Pais,AñoNacimiento,MesNacimiento,DiaNacimiento,CorreoElectronico,NTel,DireccionActual,Ciudad,SituacionLaboral")] Migrante migrante)
        {
            if (id != migrante.NId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(migrante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MigranteExists(migrante.NId))
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
            return View(migrante);
        }

        // GET: Migrantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var migrante = await _context.Migrantes
                .FirstOrDefaultAsync(m => m.NId == id);
            if (migrante == null)
            {
                return NotFound();
            }

            return View(migrante);
        }

        // POST: Migrantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var migrante = await _context.Migrantes.FindAsync(id);
            _context.Migrantes.Remove(migrante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MigranteExists(int id)
        {
            return _context.Migrantes.Any(e => e.NId == id);
        }
    }
}
