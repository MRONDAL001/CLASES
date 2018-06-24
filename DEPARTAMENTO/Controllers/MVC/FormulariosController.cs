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
    public class FormulariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormulariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Formularios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Formulario.Include(f => f.IdClienteNavigation).Include(f => f.IdDepartamentoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Formularios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdDepartamentoNavigation)
                .SingleOrDefaultAsync(m => m.IdFormulario == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // GET: Formularios/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente");
            ViewData["IdDepartamento"] = new SelectList(_context.Detalledep, "IdDepartamento", "IdDepartamento");
            return View();
        }

        // POST: Formularios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormulario,IdDepartamento,IdCliente,Precio,FechaContrato,FechaInicio,FechaFinal")] Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formulario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente", formulario.IdCliente);
            ViewData["IdDepartamento"] = new SelectList(_context.Detalledep, "IdDepartamento", "IdDepartamento", formulario.IdDepartamento);
            return View(formulario);
        }

        // GET: Formularios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario.SingleOrDefaultAsync(m => m.IdFormulario == id);
            if (formulario == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente", formulario.IdCliente);
            ViewData["IdDepartamento"] = new SelectList(_context.Detalledep, "IdDepartamento", "IdDepartamento", formulario.IdDepartamento);
            return View(formulario);
        }

        // POST: Formularios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFormulario,IdDepartamento,IdCliente,Precio,FechaContrato,FechaInicio,FechaFinal")] Formulario formulario)
        {
            if (id != formulario.IdFormulario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formulario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormularioExists(formulario.IdFormulario))
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
            ViewData["IdCliente"] = new SelectList(_context.Cliente, "IdCliente", "IdCliente", formulario.IdCliente);
            ViewData["IdDepartamento"] = new SelectList(_context.Detalledep, "IdDepartamento", "IdDepartamento", formulario.IdDepartamento);
            return View(formulario);
        }

        // GET: Formularios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formulario
                .Include(f => f.IdClienteNavigation)
                .Include(f => f.IdDepartamentoNavigation)
                .SingleOrDefaultAsync(m => m.IdFormulario == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // POST: Formularios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formulario = await _context.Formulario.SingleOrDefaultAsync(m => m.IdFormulario == id);
            _context.Formulario.Remove(formulario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormularioExists(int id)
        {
            return _context.Formulario.Any(e => e.IdFormulario == id);
        }
    }
}
