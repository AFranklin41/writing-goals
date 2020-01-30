using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using writing_goals.Data;
using writing_goals.Models;
using writing_goals.Models.ViewModels;

namespace writing_goals.Controllers
{
    public class SprintsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public SprintsController(ApplicationDbContext context,
                          UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);


        // GET: Sprints
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            return View(await _context.Sprints
                .Where(s => s.ApplicationUser.Id == user.Id && s.Archived == false).ToListAsync()
                );
        }
        //public async Task<IActionResult> Index(SprintGoalsViewModel sprintGoalsViewModel)
        //{
        //    return View(sprintGoalsViewModel);
        //}

        // GET: Sprints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.Sprints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sprint == null)
            {
                return NotFound();
            }

            return View(sprint);
        }

        // GET: Sprints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sprints/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SprintGoalsViewModel sprintGoalsViewModel)
        {
            //ModelState.Remove("sprint.ApplicationUser");
            //ModelState.Remove("sprint.ApplicationUserId");
            if (ModelState.IsValid)
            {
                //get logged in user
                var user = await GetCurrentUserAsync();

                //match user Id to logged in user
                sprintGoalsViewModel.sprint.ApplicationUserId = user.Id;

                _context.Add(sprintGoalsViewModel.sprint);
                await _context.SaveChangesAsync();

                sprintGoalsViewModel.goalOne.SprintId = sprintGoalsViewModel.sprint.Id;
                sprintGoalsViewModel.goalTwo.SprintId = sprintGoalsViewModel.sprint.Id;
                sprintGoalsViewModel.goalThree.SprintId = sprintGoalsViewModel.sprint.Id;
                sprintGoalsViewModel.goalFour.SprintId = sprintGoalsViewModel.sprint.Id;
                sprintGoalsViewModel.goalFive.SprintId = sprintGoalsViewModel.sprint.Id;

                _context.AddRange(
                    sprintGoalsViewModel.goalOne,
                    sprintGoalsViewModel.goalTwo,
                    sprintGoalsViewModel.goalThree,
                    sprintGoalsViewModel.goalFour,
                    sprintGoalsViewModel.goalFive
                    );



                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(sprintGoalsViewModel);
        }

        // GET: Sprints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.Sprints.FindAsync(id);
            if (sprint == null)
            {
                return NotFound();
            }
            return View(sprint);
        }

        // POST: Sprints/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Archived")] Sprint sprint)
        {
            if (id != sprint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprintExists(sprint.Id))
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
            return View(sprint);
        }

        // GET: Sprints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sprint = await _context.Sprints
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sprint == null)
            {
                return NotFound();
            }

            return View(sprint);
        }

        // POST: Sprints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sprint = await _context.Sprints.FindAsync(id);
            _context.Sprints.Remove(sprint);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprintExists(int id)
        {
            return _context.Sprints.Any(e => e.Id == id);
        }
    }
}
