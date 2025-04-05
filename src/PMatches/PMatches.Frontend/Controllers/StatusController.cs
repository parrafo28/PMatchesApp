using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMatches.Frontend.ViewModels;
using PMatches.Persistence;

namespace PMatches.Frontend.Controllers
{
    public class StatusController : Controller
    { 

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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vm = new StatusViewModel { Id = id.Value };
            return View(vm);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
             
            return View();
        }

       
    }
}
