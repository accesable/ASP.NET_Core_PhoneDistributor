using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_Slicone_Supplier.Models;
using WebApplication_Slicone_Supplier.Services.GenerateID;

namespace WebApplication_Slicone_Supplier.Controllers
{
    public class IventoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IIdGeneratorService _idGeneratorService;
        private readonly ILogger<IventoriesController> _logger;

        public IventoriesController(ApplicationDbContext context,IIdGeneratorService idGeneratorService, ILogger<IventoriesController> logger)
        {
            _context = context;
            _idGeneratorService = idGeneratorService;
            _logger = logger;
        }

        // GET: Iventories
        public async Task<IActionResult> Index()
        {
              return _context.Inventories != null ? 
                          View(await _context.Inventories.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Inventories'  is null.");
        }

        // GET: Iventories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Inventories == null)
            {
                return NotFound();
            }

            var iventory = await _context.Inventories
                .FirstOrDefaultAsync(m => m.IventoryID == id);
            if (iventory == null)
            {
                return NotFound();
            }

            return View(iventory);
        }

        // GET: Iventories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IventoryAddress")] Iventory iventory)
        {
            if (iventory.IventoryAddress!=null)
            {
                iventory.IventoryID =_idGeneratorService.GenerateIdForIventories(iventory.IventoryAddress);
                _context.Add(iventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iventory);
        }

        // GET: Iventories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Inventories == null)
            {
                return NotFound();
            }

            var iventory = await _context.Inventories.FindAsync(id);
            if (iventory == null)
            {
                return NotFound();
            }
            return View(iventory);
        }

        // POST: Iventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IventoryID,IventoryAddress")] Iventory iventory)
        {
            if (id != iventory.IventoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IventoryExists(iventory.IventoryID))
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
            return View(iventory);
        }

        // GET: Iventories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Inventories == null)
            {
                return NotFound();
            }

            var iventory = await _context.Inventories
                .FirstOrDefaultAsync(m => m.IventoryID == id);
            if (iventory == null)
            {
                return NotFound();
            }

            return View(iventory);
        }

        // POST: Iventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Inventories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Inventories'  is null.");
            }
            var iventory = await _context.Inventories.FindAsync(id);
            if (iventory != null)
            {
                _context.Inventories.Remove(iventory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IventoryExists(string id)
        {
          return (_context.Inventories?.Any(e => e.IventoryID == id)).GetValueOrDefault();
        }
    }
}
