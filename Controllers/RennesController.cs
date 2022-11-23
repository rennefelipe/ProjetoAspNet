using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Data;
using ProjetoAspNet.EF;

namespace ProjetoAspNet.Controllers
{
    public class RennesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RennesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rennes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Renne.ToListAsync());
        }

        // GET: Rennes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renne = await _context.Renne
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renne == null)
            {
                return NotFound();
            }

            return View(renne);
        }

        // GET: Rennes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rennes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Ativo,Sexo")] Renne renne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(renne);
        }

        // GET: Rennes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renne = await _context.Renne.FindAsync(id);
            if (renne == null)
            {
                return NotFound();
            }
            return View(renne);
        }

        // POST: Rennes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Ativo,Sexo")] Renne renne)
        {
            if (id != renne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenneExists(renne.Id))
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
            return View(renne);
        }

        // GET: Rennes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renne = await _context.Renne
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renne == null)
            {
                return NotFound();
            }

            return View(renne);
        }

        // POST: Rennes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renne = await _context.Renne.FindAsync(id);
            _context.Renne.Remove(renne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RenneExists(int id)
        {
            return _context.Renne.Any(e => e.Id == id);
        }
    }
}
