using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoCinema.Data;
using ProjetoCinema.Models;

namespace ProjetoCinema.Controllers
{
    public class DiretorsController : Controller
    {
        private readonly CinemaDBContext _context;

        public DiretorsController(CinemaDBContext context)
        {
            _context = context;
        }

        // GET: Diretors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Diretores.ToListAsync());
        }

        // GET: Diretors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretores
                .FirstOrDefaultAsync(m => m.idDiretor == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // GET: Diretors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diretors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idDiretor,nomeDiretor,paisDiretor")] Diretor diretor)
        {
            {
                _context.Add(diretor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Diretors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor == null)
            {
                return NotFound();
            }
            return View(diretor);
        }

        // POST: Diretors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idDiretor,nomeDiretor,paisDiretor")] Diretor diretor)
        {
            if (id != diretor.idDiretor)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(diretor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiretorExists(diretor.idDiretor))
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

        // GET: Diretors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diretor = await _context.Diretores
                .FirstOrDefaultAsync(m => m.idDiretor == id);
            if (diretor == null)
            {
                return NotFound();
            }

            return View(diretor);
        }

        // POST: Diretors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diretor = await _context.Diretores.FindAsync(id);
            if (diretor != null)
            {
                _context.Diretores.Remove(diretor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiretorExists(int id)
        {
            return _context.Diretores.Any(e => e.idDiretor == id);
        }
    }
}
