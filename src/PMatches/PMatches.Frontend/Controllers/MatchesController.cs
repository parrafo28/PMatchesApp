using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMatches.Domain.Entities;
using PMatches.Frontend.Utils;
using PMatches.Persistence;

namespace PMatches.Frontend.Controllers
{
    public class MatchesController : Controller
    { 

        [HttpGet]
        public async Task<IActionResult> Index(string searchParam = "")
        {
           
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
          
            return View();
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

            
            return View();
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
