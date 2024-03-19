using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly LibraryDbContext _context;

        public LibraryController(LibraryDbContext context)
        {
            _context = context;
        }

        // GET: Library
        public async Task<IActionResult> Index()
        {
            return View(await _context.Libraries.ToListAsync());
        }

        // GET: Library/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryModel = await _context.Libraries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryModel == null)
            {
                return NotFound();
            }

            return View(libraryModel);
        }

        // GET: Library/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Library/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName")] LibraryModel libraryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libraryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libraryModel);
        }

        // GET: Library/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryModel = await _context.Libraries.FindAsync(id);
            if (libraryModel == null)
            {
                return NotFound();
            }
            return View(libraryModel);
        }

        // POST: Library/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName")] LibraryModel libraryModel)
        {
            if (id != libraryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libraryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryModelExists(libraryModel.Id))
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
            return View(libraryModel);
        }

        // GET: Library/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libraryModel = await _context.Libraries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (libraryModel == null)
            {
                return NotFound();
            }

            return View(libraryModel);
        }

        // POST: Library/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libraryModel = await _context.Libraries.FindAsync(id);
            if (libraryModel != null)
            {
                _context.Libraries.Remove(libraryModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryModelExists(int id)
        {
            return _context.Libraries.Any(e => e.Id == id);
        }
    }
}
