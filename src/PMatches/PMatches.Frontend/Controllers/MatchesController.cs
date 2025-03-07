using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMatches.Domain.Entities;
using PMatches.Frontend.Data;
using PMatches.Frontend.Data.Entities;
using PMatches.Frontend.Models;
using PMatches.Frontend.Utils;
using PMatches.Persistence;

namespace PMatches.Frontend.Controllers
{
    public class MatchesController : Controller
    {
        private readonly DataContext _context;

        public MatchesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchParam = "")
        {
            var matches = _context.Matches.Where(p => p.StatusId > 0);

            searchParam = searchParam.ToLower();
            var matchesList = matches.Where(m => m.EquipNameHome.ToLower().Contains(searchParam) || m.EquipNameVisitor.ToLower().Contains(searchParam)).ToList();

            return View(matchesList);
        }
         
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var entityM = await _context.Matches
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (entityM == null)
            {
                return NotFound();
            }
            var modelE = EntityViewModelConverter.MatchEntityToViewModel(entityM);
            return View(modelE);
        }

        public IActionResult Create()
        {  
            return View();
        }
         
        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? identifier)
        {
            if (identifier == null)
            {
                return NotFound();
            }

            var entityM = await _context.Matches.FindAsync(identifier);
            if (entityM == null)
            {
                return NotFound();
            }
            var modelE = EntityViewModelConverter.MatchEntityToViewModel(entityM);

            return View(modelE);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Match entityM)
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

            var entityM = await _context.Matches
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
            var entityM = await _context.Matches.FindAsync(id);
            if (entityM != null)
            {
                _context.Matches.Remove(entityM);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool EntityExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }



    }
}
