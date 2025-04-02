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
    public class PremiacaosController : Controller
    {
        private readonly CinemaDBContext _context;

        public PremiacaosController(CinemaDBContext context)
        {
            _context = context;
        }

        // GET: Premiacaos
        public async Task<IActionResult> Index()
        {
            var cinemaDBContext = _context.Premiacoes.Include(p => p.Filme);
            return View(await cinemaDBContext.ToListAsync());
        }

        // GET: Premiacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premiacao = await _context.Premiacoes
                .Include(p => p.Filme)
                .FirstOrDefaultAsync(m => m.idPremiacao == id);
            if (premiacao == null)
            {
                return NotFound();
            }

            return View(premiacao);
        }

        // GET: Premiacaos/Create
        public IActionResult Create()
        {
            ViewData["idFilme"] = new SelectList(_context.Filmes, "idFilme", "idFilme");
            return View();
        }

        // POST: Premiacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPremiacao,idFilme,tituloFilme")] Premiacao premiacao)
        { 
            {
                _context.Add(premiacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idFilme"] = new SelectList(_context.Filmes, "idFilme", "idFilme", premiacao.idFilme);
            return View(premiacao);
        }

        // GET: Premiacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premiacao = await _context.Premiacoes.FindAsync(id);
            if (premiacao == null)
            {
                return NotFound();
            }
            ViewData["idFilme"] = new SelectList(_context.Filmes, "idFilme", "idFilme", premiacao.idFilme);
            return View(premiacao);
        }

        // POST: Premiacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPremiacao,idFilme,tituloFilme")] Premiacao premiacao)
        {
            if (id != premiacao.idPremiacao)
            {
                return NotFound();
            }


                try
                {
                    _context.Update(premiacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PremiacaoExists(premiacao.idPremiacao))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["idFilme"] = new SelectList(_context.Filmes, "idFilme", "idFilme", premiacao.idFilme);
            return View(premiacao);
        }

        // GET: Premiacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premiacao = await _context.Premiacoes
                .Include(p => p.Filme)
                .FirstOrDefaultAsync(m => m.idPremiacao == id);
            if (premiacao == null)
            {
                return NotFound();
            }

            return View(premiacao);
        }

        // POST: Premiacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var premiacao = await _context.Premiacoes.FindAsync(id);
            if (premiacao != null)
            {
                _context.Premiacoes.Remove(premiacao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PremiacaoExists(int id)
        {
            return _context.Premiacoes.Any(e => e.idPremiacao == id);
        }
    }
}
