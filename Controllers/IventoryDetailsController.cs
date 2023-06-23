using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_Slicone_Supplier.Models;

namespace WebApplication_Slicone_Supplier.Controllers
{
    public class IventoryDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IventoryDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IventoryDetails
        public async Task<IActionResult> Index()
        {
              return _context.IventoryDetails != null ? 
                          View(await _context.IventoryDetails.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.IventoryDetails'  is null.");
        }

        // GET: IventoryDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.IventoryDetails == null)
            {
                return NotFound();
            }

            var iventoryDetail = await _context.IventoryDetails
                .FirstOrDefaultAsync(m => m.IventoryDetailId == id);
            if (iventoryDetail == null)
            {
                return NotFound();
            }

            return View(iventoryDetail);
        }

        // GET: IventoryDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IventoryDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IventoryDetailId,Quantity")] IventoryDetail iventoryDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iventoryDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iventoryDetail);
        }

        // GET: IventoryDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.IventoryDetails == null)
            {
                return NotFound();
            }

            var iventoryDetail = await _context.IventoryDetails.FindAsync(id);
            if (iventoryDetail == null)
            {
                return NotFound();
            }
            return View(iventoryDetail);
        }

        // POST: IventoryDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IventoryDetailId,Quantity")] IventoryDetail iventoryDetail)
        {
            if (id != iventoryDetail.IventoryDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iventoryDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IventoryDetailExists(iventoryDetail.IventoryDetailId))
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
            return View(iventoryDetail);
        }

        // GET: IventoryDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.IventoryDetails == null)
            {
                return NotFound();
            }

            var iventoryDetail = await _context.IventoryDetails
                .FirstOrDefaultAsync(m => m.IventoryDetailId == id);
            if (iventoryDetail == null)
            {
                return NotFound();
            }

            return View(iventoryDetail);
        }

        // POST: IventoryDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.IventoryDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.IventoryDetails'  is null.");
            }
            var iventoryDetail = await _context.IventoryDetails.FindAsync(id);
            if (iventoryDetail != null)
            {
                _context.IventoryDetails.Remove(iventoryDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IventoryDetailExists(string id)
        {
          return (_context.IventoryDetails?.Any(e => e.IventoryDetailId == id)).GetValueOrDefault();
        }
    }
}
