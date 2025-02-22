using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PMatches.Frontend.Data;
using PMatches.Frontend.Data.Entities;
using PMatches.Frontend.Models;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Matches.ToListAsync());
        }

        // GET: Matches/Details/5
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

            return View(entityM);
        }


        public IActionResult Create()
        {
            var modelE = new MatchModel();

            var status = _context.Status.ToList();

            var selectList = new SelectList(status, nameof(Status.Id), nameof(Status.Name));

            modelE.StatusList = selectList;
            return View(modelE);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MatchModel modelE)
        {
            if (ModelState.IsValid)
            {

                var entityM = new Match();
                entityM.WinHome = modelE.WinHome;
                entityM.PointsFromVisitor = modelE.PointsFromVisitor;
                entityM.EquipNameVisitor = modelE.EquipNameVisitor;
                entityM.PointsFromHome = modelE.PointsFromHome;
                entityM.EquipNameHome = modelE.EquipNameHome;
                entityM.Prize = modelE.Prize;
                entityM.StatusId = modelE.StatusId;
                _context.Matches.Add(entityM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelE);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entityM = await _context.Matches.FindAsync(id);
            if (entityM == null)
            {
                return NotFound();
            }
            return View(entityM);
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
