using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using writing_goals.Data;
using writing_goals.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Dynamic;
using Newtonsoft.Json;

namespace writing_goals.Controllers
{
    public class GoalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Goals
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Goals.ToListAsync());
        }

        // GET: Goals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goal == null)
            {
                return NotFound();
            }

            return View(goal);
        }

        // GET: Goals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SprintId,GoalDate,TimeGoal,TimeActual,WordCountGoal,WordCountActual,OptionalGoal")] Goal goal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goal);
        }

        // GET: Goals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goals.FindAsync(id);
            if (goal == null)
            {
                return NotFound();
            }
            return View(goal);
        }

        public class whateverIWant
        {
            public int Id { get; set; }
            public string TimeActual { get; set; }
            public string WordCountActual { get; set; }
        }





        // POST: Goals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //public async Task<IActionResult> Edit(int id, [FromBody]object goal)
        public async Task<IActionResult> Edit(int id, [FromBody]object goal)
        {
            {
                try
                {
                    Goal deserializedGoal = JsonConvert.DeserializeObject<Goal>(goal.ToString());

                    var existingGoalProperties = await _context.Goals.Where(g => g.Id == id && g.SprintId == g.sprint.Id)
                        .FirstOrDefaultAsync();

                    
                    existingGoalProperties.DateOnly = deserializedGoal.DateOnly;
                    existingGoalProperties.TimeOnly = deserializedGoal.TimeOnly;

                    if (deserializedGoal.TimeActual != 0)
                    {
                        existingGoalProperties.TimeActual = deserializedGoal.TimeActual;
                    };

                    if (deserializedGoal.WordCountActual != 0)
                    {
                        existingGoalProperties.WordCountActual = deserializedGoal.WordCountActual;
                    };
                    if (deserializedGoal.OptionalGoal != null)
                    {
                        existingGoalProperties.OptionalGoal = deserializedGoal.OptionalGoal;
                    };

                    //existingGoalProperties.TimeActual = deserializedGoal.TimeActual;
                    //existingGoalProperties.WordCountActual = deserializedGoal.WordCountActual;
                    //existingGoalProperties.OptionalGoal = deserializedGoal.OptionalGoal;

                    //existingGoalProperties.SprintId = deserializedGoal.SprintId;
                    //existingGoalProperties.GoalDate = deserializedGoal.GoalDate;
                    //existingGoalProperties.TimeGoal = deserializedGoal.TimeGoal;
                    //existingGoalProperties.WordCountGoal = deserializedGoal.WordCountGoal;


                    _context.Update(existingGoalProperties);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    //    if (!GoalExists(goal.Id))
                    //    {
                    //        return NotFound();
                    //    }
                    //    else
                    //    {
                    //        throw;
                    //    }
                }
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Goals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (goal == null)
            {
                return NotFound();
            }

            return View(goal);
        }

        // POST: Goals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goal = await _context.Goals.FindAsync(id);
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalExists(int id)
        {
            return _context.Goals.Any(e => e.Id == id);
        }
    }
}
