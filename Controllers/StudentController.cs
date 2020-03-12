using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentInformationThur.Data;
using StudentInformationThur.Models;

namespace StudentIformationThur.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentInformationContext _context;

        public StudentController(StudentInformationContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campers.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camper == null)
            {
                return NotFound();
            }

            return View(camper);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,EnrollmentDate")] Camper camper)
        {
            if (ModelState.IsValid)
            {
                camper.ID = Guid.NewGuid();
                _context.Add(camper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camper);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers.FindAsync(id);
            if (camper == null)
            {
                return NotFound();
            }
            return View(camper);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,LastName,FirstMidName,EnrollmentDate")] Camper camper)
        {
            if (id != camper.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamperExists(camper.ID))
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
            return View(camper);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (camper == null)
            {
                return NotFound();
            }

            return View(camper);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var camper = await _context.Campers.FindAsync(id);
            _context.Campers.Remove(camper);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamperExists(Guid id)
        {
            return _context.Campers.Any(e => e.ID == id);
        }
    }
}
