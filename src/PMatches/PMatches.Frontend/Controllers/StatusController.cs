using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMatches.Domain.Entities;
using PMatches.Frontend.Data;
using PMatches.Frontend.Data.Entities;
using PMatches.Persistence;

namespace PMatches.Frontend.Controllers
{
    public class StatusController : Controller
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }
         
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var vm = new StatusViewModel { Id = id.Value };

            return View(vm);
        }
         
        public IActionResult Create()
        {
            return View();
        }
         
        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityM = await _context.Status.FindAsync(id);
            if (entityM == null)
            {
                return NotFound();
            }
            return View(entityM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Status entityM)
        {
            if (id != entityM.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entityM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntityExists(entityM.Id))
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
            return View(entityM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityM = await _context.Status
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entityM == null)
            {
                return NotFound();
            }

            return View(entityM);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entityM = await _context.Status.FindAsync(id);
            if (entityM != null)
            {
                _context.Status.Remove(entityM);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EntityExists(int id)
        {
            return _context.Status.Any(e => e.Id == id);
        }
    }
}
