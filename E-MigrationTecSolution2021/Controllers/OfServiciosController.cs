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
    public class OfServiciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OfServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OfServicios
        public async Task<IActionResult> Index(string Busqueda)
        {
            ViewData["CurrentFilter"] = Busqueda;

            var busqueda = from b in _context.OfServicios select b;
            if (!String.IsNullOrEmpty(Busqueda))
            {
                busqueda = busqueda.Where(b =>
                                            b.EstadoServicio.Contains(Busqueda));
            }

            return View(await busqueda.AsNoTracking().ToListAsync());

        }

        // GET: OfServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofServicio = await _context.OfServicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ofServicio == null)
            {
                return NotFound();
            }

            return View(ofServicio);
        }

        // GET: OfServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDelServicio,MaximoNumeroDeMigrantes,FechaDeInicio,FechaDeFinalizacion,EstadoServicio")] OfServicio ofServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ofServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ofServicio);
        }

        // GET: OfServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofServicio = await _context.OfServicios.FindAsync(id);
            if (ofServicio == null)
            {
                return NotFound();
            }
            return View(ofServicio);
        }

        // POST: OfServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDelServicio,MaximoNumeroDeMigrantes,FechaDeInicio,FechaDeFinalizacion,EstadoServicio")] OfServicio ofServicio)
        {
            if (id != ofServicio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ofServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfServicioExists(ofServicio.Id))
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
            return View(ofServicio);
        }

        // GET: OfServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofServicio = await _context.OfServicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ofServicio == null)
            {
                return NotFound();
            }

            return View(ofServicio);
        }

        // POST: OfServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ofServicio = await _context.OfServicios.FindAsync(id);
            _context.OfServicios.Remove(ofServicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfServicioExists(int id)
        {
            return _context.OfServicios.Any(e => e.Id == id);
        }
    }
}
