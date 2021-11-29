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
    public class RegServiciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegServiciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RegServicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.RegServicios.ToListAsync());
        }

        // GET: RegServicios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regServicio = await _context.RegServicios
                .FirstOrDefaultAsync(m => m.NDocumento == id);
            if (regServicio == null)
            {
                return NotFound();
            }

            return View(regServicio);
        }

        // GET: RegServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NDocumento,NombreDelServicio")] RegServicio regServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regServicio);
        }

        // GET: RegServicios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regServicio = await _context.RegServicios.FindAsync(id);
            if (regServicio == null)
            {
                return NotFound();
            }
            return View(regServicio);
        }

        // POST: RegServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NDocumento,NombreDelServicio")] RegServicio regServicio)
        {
            if (id != regServicio.NDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegServicioExists(regServicio.NDocumento))
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
            return View(regServicio);
        }

        // GET: RegServicios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regServicio = await _context.RegServicios
                .FirstOrDefaultAsync(m => m.NDocumento == id);
            if (regServicio == null)
            {
                return NotFound();
            }

            return View(regServicio);
        }

        // POST: RegServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var regServicio = await _context.RegServicios.FindAsync(id);
            _context.RegServicios.Remove(regServicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegServicioExists(string id)
        {
            return _context.RegServicios.Any(e => e.NDocumento == id);
        }
    }
}
