// Author : Aditya Gupta
using AcmeFunEvents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeFunEvents.Controllers
{
    public class UserActivityController : Controller
    {
        private readonly AcmeFunEventsContext _context;

        public UserActivityController(AcmeFunEventsContext context)
        {
            _context = context;
        }

        // GET: Retreives list of signed up users for fun event activity.
        public async Task<IActionResult> Index()
        {
            var acmeFunEventsContext = _context.UserActivity.Include(u => u.Activity);
            ViewData["Message"] = "List of all signed up employee's is retreived successfully.";
            return View(await acmeFunEventsContext.ToListAsync());
        }

        // GET: UserActivity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivity
                .Include(u => u.Activity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userActivity == null)
            {
                return NotFound();
            }

            return View(userActivity);
        }

        // GET: UserActivity/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "Name");
            return View();
        }

        // POST: Sign up for fun event activity.
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,ActivityId")] UserActivity userActivity)
        {
            if (String.IsNullOrEmpty(userActivity.Email))
            {
                ModelState.AddModelError("Email", "Email Address cannot be an empty field");
            }
            if (ModelState.IsValid)
            {
                _context.Add(userActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityId", userActivity.ActivityId);
            return View(userActivity);
        }

        // GET: Edit page for a SigedUp activity.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivity.FindAsync(id);
            if (userActivity == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "Name", userActivity.ActivityId);
            return View(userActivity);
        }

        // POST: Edit a SigedUp activity.
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,ActivityId")] UserActivity userActivity)
        {
            if (id != userActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserActivityExists(userActivity.Id))
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
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "ActivityId", userActivity.ActivityId);
            return View(userActivity);
        }

        // GET: UserActivity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivity
                .Include(u => u.Activity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userActivity == null)
            {
                return NotFound();
            }

            return View(userActivity);
        }

        // POST: Delete a SigedUp activity.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userActivity = await _context.UserActivity.FindAsync(id);
            _context.UserActivity.Remove(userActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserActivityExists(int id)
        {
            return _context.UserActivity.Any(e => e.Id == id);
        }
    }
}
