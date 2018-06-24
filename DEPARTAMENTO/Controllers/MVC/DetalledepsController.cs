using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DEPARTAMENTO.Data;
using DEPARTAMENTO.Models.DEP;

namespace DEPARTAMENTO.Controllers.MVC
{
    public class DetalledepsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetalledepsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Detalledeps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Detalledep.ToListAsync());
        }

        // GET: Detalledeps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalledep = await _context.Detalledep
                .SingleOrDefaultAsync(m => m.IdDepartamento == id);
            if (detalledep == null)
            {
                return NotFound();
            }

            return View(detalledep);
        }

        // GET: Detalledeps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Detalledeps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDepartamento,Dormitorios,Banios,Ubicacion,Detalle")] Detalledep detalledep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalledep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detalledep);
        }

        // GET: Detalledeps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalledep = await _context.Detalledep.SingleOrDefaultAsync(m => m.IdDepartamento == id);
            if (detalledep == null)
            {
                return NotFound();
            }
            return View(detalledep);
        }

        // POST: Detalledeps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDepartamento,Dormitorios,Banios,Ubicacion,Detalle")] Detalledep detalledep)
        {
            if (id != detalledep.IdDepartamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalledep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalledepExists(detalledep.IdDepartamento))
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
            return View(detalledep);
        }

        // GET: Detalledeps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalledep = await _context.Detalledep
                .SingleOrDefaultAsync(m => m.IdDepartamento == id);
            if (detalledep == null)
            {
                return NotFound();
            }

            return View(detalledep);
        }

        // POST: Detalledeps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalledep = await _context.Detalledep.SingleOrDefaultAsync(m => m.IdDepartamento == id);
            _context.Detalledep.Remove(detalledep);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalledepExists(int id)
        {
            return _context.Detalledep.Any(e => e.IdDepartamento == id);
        }
    }
}
