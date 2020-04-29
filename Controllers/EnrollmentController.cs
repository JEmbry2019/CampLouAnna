using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampLouAnna.Data;
using CampLouAnna.Models;

namespace CampLouAnna.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly CampLouAnnaContext _context;

        public EnrollmentController(CampLouAnnaContext context)
        {
            _context = context;
        }

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            var projPracContext = _context.Enrollments.Include(e => e.Camper).Include(e => e.Game).Include(e => e.Meal);
            return View(await projPracContext.ToListAsync());
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Camper)
                .Include(e => e.Game)
                .Include(e => e.Meal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollment/Create
        public IActionResult Create()
        {
        // Lines 54 -56 adds all 3 selections to Enum view on Create page.
            ViewData["CamperID"] = new SelectList(_context.Campers, "ID", "FullName");
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Display");
            ViewData["MealID"] = new SelectList(_context.Meals, "ID", "FoodDisplay");

            // ViewData["GameID"] = new SelectList(_context.Games, "ID", "RecRoom");
            // ViewData["GameID"] = new SelectList(_context.Games, "ID", "Computer");
            return View();
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CamperID,MealID,GameID,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollment.ID = Guid.NewGuid();
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CamperID"] = new SelectList(_context.Campers, "ID", "FirstMidName", enrollment.CamperID);
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "Gym", enrollment.GameID);
            ViewData["MealID"] = new SelectList(_context.Meals, "ID", "Breakfast", enrollment.MealID);

                ViewData["GameID"] = new SelectList(_context.Games, "ID", "RecRoom", enrollment.GameID);
                ViewData["GameID"] = new SelectList(_context.Games, "ID", "Computer", enrollment.GameID);

                ViewData["MealID"] = new SelectList(_context.Meals, "ID", "Lunch", enrollment.MealID);
                ViewData["MealID"] = new SelectList(_context.Meals, "ID", "Snack", enrollment.MealID);
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
           // ViewData["CamperID"] = new SelectList(_context.Campers, "ID", "FirstMidName", enrollment.CamperID);
           // ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", enrollment.GameID);
           // ViewData["MealID"] = new SelectList(_context.Meals, "ID", "ID", enrollment.MealID);


                     ViewData["CamperID"] = new SelectList(_context.Campers, "ID", "FirstMidName", enrollment.CamperID);
                     ViewData["GameID"] = new SelectList(_context.Games, "ID", "Display", enrollment.GameID);
                     ViewData["MealID"] = new SelectList(_context.Meals, "ID", "FoodDisplay", enrollment.MealID);

                   // ViewData["GameID"] = new SelectList(_context.Games, "ID", "RecRoom", enrollment.GameID);
                   // ViewData["GameID"] = new SelectList(_context.Games, "ID", "Computer", enrollment.GameID);

                   // ViewData["MealID"] = new SelectList(_context.Meals, "ID", "Lunch", enrollment.MealID);
                   // ViewData["MealID"] = new SelectList(_context.Meals, "ID", "Snack", enrollment.MealID);






            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,CamperID,MealID,GameID,Grade")] Enrollment enrollment)
        {
            if (id != enrollment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.ID))
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
            // ViewData["CamperID"] = new SelectList(_context.Campers, "ID", "FirstMidName", enrollment.CamperID);
            // ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", enrollment.GameID);
            // ViewData["MealID"] = new SelectList(_context.Meals, "ID", "ID", enrollment.MealID);

                ViewData["CamperID"] = new SelectList(_context.Campers, "ID", "FirstMidName", enrollment.CamperID);
                ViewData["GameID"] = new SelectList(_context.Games, "ID", "Gym", enrollment.GameID);
                ViewData["MealID"] = new SelectList(_context.Meals, "ID", "Breakfast", enrollment.MealID);

                ViewData["GameID"] = new SelectList(_context.Games, "ID", "RecRoom", enrollment.GameID);
                ViewData["GameID"] = new SelectList(_context.Games, "ID", "Computer", enrollment.GameID);

                ViewData["MealID"] = new SelectList(_context.Meals, "ID", "Lunch", enrollment.MealID);
                ViewData["MealID"] = new SelectList(_context.Meals, "ID", "Snack", enrollment.MealID);


            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Camper)
                .Include(e => e.Game)
                .Include(e => e.Meal)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(Guid id)
        {
            return _context.Enrollments.Any(e => e.ID == id);
        }
    }
}
