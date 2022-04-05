using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Toolivahendus2.Data;
using Toolivahendus2.Models;

namespace Toolivahendus2.Controllers
{
    [Authorize]
    public class TooliVahendusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TooliVahendusController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: TooliVahendus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToolidValmistusel.ToListAsync());
        }

        public async Task<IActionResult> AdminPaneel()
        {
            return View(await _context.ToolidValmistusel.ToListAsync());
        }
        public async Task<IActionResult> IncreaseValue(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooliVahendus = await _context.ToolidValmistusel.FirstOrDefaultAsync(m => m.Id == id);
            if (tooliVahendus == null)
            {
                return NotFound();
            }

            


            return View(tooliVahendus);
        }


        [AllowAnonymous]
        public async Task<IActionResult> Andmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooliVahendus = await _context.ToolidValmistusel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tooliVahendus == null)
            {
                return NotFound();
            }

            return View(tooliVahendus);
        }


        // GET: TooliVahendus/Create
        [AllowAnonymous]
        public IActionResult Loomine()
        {
            return View();
        }

        // POST: TooliVahendus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Loomine([Bind("Id,Eesnimi,Perekonnanimi,Toon,Tellimuskogus,Firmanimi,Firmaemail")] TooliVahendus tooliVahendus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tooliVahendus);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(TellimuseLeht), new { tellimuseNumber = tooliVahendus.Id });
            }
            return View(tooliVahendus);
        }

        [AllowAnonymous]
        public async Task<IActionResult> TellimuseLeht(int? tellimuseNumber)
        {
            if (tellimuseNumber == null)
            {
                return NotFound();
            }

            var tooliVahendus = await _context.ToolidValmistusel.FindAsync(tellimuseNumber);
            if (tooliVahendus == null)
            {
                return NotFound();
            }
            return View(tooliVahendus);
        }



        // GET: TooliVahendus/Edit/5
        public async Task<IActionResult> Muutmine(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooliVahendus = await _context.ToolidValmistusel.FindAsync(id);
            if (tooliVahendus == null)
            {
                return NotFound();
            }
            return View(tooliVahendus);
        }

        // POST: TooliVahendus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Muutmine(int id, [Bind("Id,Eesnimi,Perekonnanimi,Toon,Tellimuskogus,Firmanimi,Firmaemail,Valminudkogus")] TooliVahendus tooliVahendus)
        {
            if (id != tooliVahendus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tooliVahendus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolEksisteerib(tooliVahendus.Id))
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
            return View(tooliVahendus);
        }





        // GET: TooliVahendus/Delete/5
        public async Task<IActionResult> Kustutamine(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooliVahendus = await _context.ToolidValmistusel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tooliVahendus == null)
            {
                return NotFound();
            }

            return View(tooliVahendus);
        }

        // POST: TooliVahendus/Delete/5
        [HttpPost, ActionName("Kustutamine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> KustutamineKinnitus(int id)
        {
            var tooliVahendus = await _context.ToolidValmistusel.FindAsync(id);
            _context.ToolidValmistusel.Remove(tooliVahendus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AdminPaneel));
        }

        private bool ToolEksisteerib(int id)
        {
            return _context.ToolidValmistusel.Any(e => e.Id == id);
        }

        //




        // GET: TooliVahendus/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooliVahendus = await _context.ToolidValmistusel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tooliVahendus == null)
            {
                return NotFound();
            }

            return View(tooliVahendus);
        }

        // GET: TooliVahendus/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TooliVahendus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Eesnimi,Perekonnanimi,Toon,Tellimuskogus,Firmanimi,Firmaemail")] TooliVahendus tooliVahendus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tooliVahendus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tooliVahendus);
        }

        // GET: TooliVahendus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooliVahendus = await _context.ToolidValmistusel.FindAsync(id);
            if (tooliVahendus == null)
            {
                return NotFound();
            }
            return View(tooliVahendus);
        }

        // POST: TooliVahendus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Eesnimi,Perekonnanimi,Toon,Tellimuskogus,Firmanimi,Firmaemail,Valminudkogus")] TooliVahendus tooliVahendus)
        {
            if (id != tooliVahendus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tooliVahendus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TooliVahendusExists(tooliVahendus.Id))
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
            return View(tooliVahendus);
        }

        // GET: TooliVahendus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tooliVahendus = await _context.ToolidValmistusel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tooliVahendus == null)
            {
                return NotFound();
            }

            return View(tooliVahendus);
        }

        // POST: TooliVahendus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tooliVahendus = await _context.ToolidValmistusel.FindAsync(id);
            _context.ToolidValmistusel.Remove(tooliVahendus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TooliVahendusExists(int id)
        {
            return _context.ToolidValmistusel.Any(e => e.Id == id);
        }
    }
}
