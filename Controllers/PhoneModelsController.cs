using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraryNhutAnhTran;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApplication_Slicone_Supplier.Models;
using WebApplication_Slicone_Supplier.Services;

namespace WebApplication_Slicone_Supplier.Controllers
{
    public class PhoneModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploadServices _uploadServices;
        private readonly ILogger<PhoneModelsController> _logger;

        public PhoneModelsController(ApplicationDbContext context,IFileUploadServices fileUploadServices, ILogger<PhoneModelsController> logger)
        {
            _context = context;
            _uploadServices = fileUploadServices;
            _logger = logger;
        }

        // GET: PhoneModels
        public async Task<IActionResult> Index()
        {

            return _context.PhoneModels != null ? 
                          View(await _context.PhoneModels.Include(o=>o.ModelBrand).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PhoneModels'  is null.");
        }

        // GET: PhoneModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.PhoneModels == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModels
                .FirstOrDefaultAsync(m => m.ModelId == id);


            await _context.Entry(phoneModel).Reference(o => o.ModelBrand).LoadAsync();

            _logger.LogInformation(phoneModel.ModelBrand.BrandName);
            
            if (phoneModel == null)
            {
                return NotFound();
            }

            return View(phoneModel);
        }

        // GET: PhoneModels/Create
        public IActionResult Create()
        {
            List<Brand> brands =  _context.Brands.ToList();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
            return View();
        }

        // POST: PhoneModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelName,ModelBrandId,AgentPrice,CustomerPrice")] PhoneModel phoneModel,IFormFile file)
        {
            if(file != null)
            {
                phoneModel.Image = await _uploadServices.UploadFileAsync(file);
            }
            if (ModelState.IsValid)
            {
                _context.Add(phoneModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            string errorMessage = "";
            foreach (var entry in ModelState.Values)
            {
                foreach (var error in entry.Errors)
                {
                    // Retrieve and handle each error
                    errorMessage +=" "+ error.ErrorMessage;
                    // ...
                }
            }
            List<Brand> brands = _context.Brands.ToList();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
            return View(phoneModel);
        }

        // GET: PhoneModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PhoneModels == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModels.FindAsync(id);
            if (phoneModel == null)
            {
                return NotFound();
            }
            List<Brand> brands = _context.Brands.ToList();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
            return View(phoneModel);
        }

        // POST: PhoneModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelName,ModelBrandId,AgentPrice,CustomerPrice")] PhoneModel phoneModel, IFormFile file)
        {
            // The Update method could result in create a new Object if didn't pass the id
            phoneModel.ModelId = id;

            if (file != null)
            {
                phoneModel.Image = await _uploadServices.UploadFileAsync(file);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneModelExists(phoneModel.ModelId))
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

            List<Brand> brands = _context.Brands.ToList();
            ViewBag.Brands = new SelectList(brands, "Id", "BrandName");
            return View(phoneModel);
        }

        // GET: PhoneModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhoneModels == null)
            {
                return NotFound();
            }

            var phoneModel = await _context.PhoneModels
                .FirstOrDefaultAsync(m => m.ModelId == id);
            await _context.Entry(phoneModel).Reference(o => o.ModelBrand).LoadAsync();
            if (phoneModel == null)
            {
                return NotFound();
            }

            return View(phoneModel);
        }

        // POST: PhoneModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhoneModels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PhoneModels'  is null.");
            }
            var phoneModel = await _context.PhoneModels.FindAsync(id);
            if (phoneModel != null)
            {
                _context.PhoneModels.Remove(phoneModel);
                _uploadServices.DeleteFile(phoneModel.Image);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneModelExists(int id)
        {
          return (_context.PhoneModels?.Any(e => e.ModelId == id)).GetValueOrDefault();
        }
    }
}
