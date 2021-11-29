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
    public class Conservicios : Controller
    {
        private readonly ApplicationDbContext _context;

        public Conservicios(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conservicios
        public async Task<IActionResult> Index(string Busqueda)
        {
            ViewData["CurrentFilter"] = Busqueda; 
            var busqueda = from b in _context.ConServicios select b;

            if (!String.IsNullOrEmpty(Busqueda))
            {
                busqueda = busqueda.Where(b =>
              
                                            b.Necesidad.Contains(Busqueda));
            }

            return View(await busqueda.AsNoTracking().ToListAsync());

        }

        // GET: Conservicios/Create
        public async Task<IActionResult> CreateAsync(string Busquedad)
        {
            ViewData["CurrentFilter"] = Busquedad; 
            var busquedad = from c in _context.ConServicios select c;

            if (!String.IsNullOrEmpty(Busquedad))
            {
                busquedad = busquedad.Where(c =>
              
                                            c.Necesidad.Contains(Busquedad));
            }

            return View(await busquedad.AsNoTracking().ToListAsync());
        }

        // POST: Conservicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDeEntidad,NombreDelServicio,Categoria,Necesidad,MaximoNumeroDeMigrantes,FechaDeInicio,FechaDeFinalizacion,EstadoServicio")] ConServicios conServicios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conServicios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conServicios);
        }

        // GET: Conservicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conServicios = await _context.ConServicios.FindAsync(id);
            if (conServicios == null)
            {
                return NotFound();
            }
            return View(conServicios);
        }

        // POST: Conservicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDeEntidad,NombreDelServicio,Categoria,Necesidad,MaximoNumeroDeMigrantes,FechaDeInicio,FechaDeFinalizacion,EstadoServicio")] ConServicios conServicios)
        {
            if (id != conServicios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conServicios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConServiciosExists(conServicios.Id))
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
            return View(conServicios);
        }

        // GET: Conservicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conServicios = await _context.ConServicios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conServicios == null)
            {
                return NotFound();
            }

            return View(conServicios);
        }

        // POST: Conservicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conServicios = await _context.ConServicios.FindAsync(id);
            _context.ConServicios.Remove(conServicios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConServiciosExists(int id)
        {
            return _context.ConServicios.Any(e => e.Id == id);
        }
    }
}
