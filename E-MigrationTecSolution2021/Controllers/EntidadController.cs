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
    public class EntidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Entidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entidades.ToListAsync());
        }

        // GET: Entidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // GET: Entidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RazonSocial,Nit,Direccion,Ciudad,Telefono,Correo,Paginaweb,Sector,TipoServicio")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entidad);
        }

        // GET: Entidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidades.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return View(entidad);
        }

        // POST: Entidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RazonSocial,Nit,Direccion,Ciudad,Telefono,Correo,Paginaweb,Sector,TipoServicio")] Entidad entidad)
        {
            if (id != entidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadExists(entidad.Id))
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
            return View(entidad);
        }

        // GET: Entidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // POST: Entidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entidad = await _context.Entidades.FindAsync(id);
            _context.Entidades.Remove(entidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadExists(int id)
        {
            return _context.Entidades.Any(e => e.Id == id);
        }
    }
}
