using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resume2.Data;
using Resume2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Resume2.Controllers
{
  public class DutiesController : Controller
  {
    private readonly Resume2Context _context;

    public DutiesController(Resume2Context context)
    {
      _context = context;
    }

    // GET: Duties
    public async Task<IActionResult> Index(int? id)
    {
      ViewData["experienceID"] = id.Value;

      var duty = await _context.Dutys
        .Where(i => i.ExperienceID == id.Value)
        .OrderBy(y => y.Priority)
        .AsNoTracking()
        .ToListAsync();

      return View(duty);
    }

    // GET: Duties/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var duty = await _context.Dutys
          .Include(d => d.Experience)
          .SingleOrDefaultAsync(m => m.DutyID == id);
      if (duty == null)
      {
        return NotFound();
      }

      return View(duty);
    }

    // GET: Duties/Create
    public IActionResult Create(int? id)
    {
      ViewData["experienceID"] = id;
      return View();
    }

    // POST: Duties/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ExperienceID,Priority,Description")] Duty duty)
    {
      if (ModelState.IsValid)
      {
        _context.Add(duty);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), "Duties", new { id = duty.ExperienceID });
      }
      ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ExperienceID", "ExperienceID", duty.ExperienceID);
      return View(duty);
    }

    // GET: Duties/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var duty = await _context.Dutys.SingleOrDefaultAsync(m => m.DutyID == id);
      if (duty == null)
      {
        return NotFound();
      }
      ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ExperienceID", "ExperienceID", duty.ExperienceID);
      return View(duty);
    }

    // POST: Duties/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("DutyID,ExperienceID,Priority,Description")] Duty duty)
    {
      if (id != duty.DutyID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(duty);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!DutyExists(duty.DutyID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index), "Duties", new { id = duty.ExperienceID });
      }
      ViewData["ExperienceID"] = new SelectList(_context.Experiences, "ExperienceID", "ExperienceID", duty.ExperienceID);
      return View(duty);
    }

    // GET: Duties/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var duty = await _context.Dutys
          .Include(d => d.Experience)
          .SingleOrDefaultAsync(m => m.DutyID == id);
      if (duty == null)
      {
        return NotFound();
      }

      return View(duty);
    }

    // POST: Duties/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var duty = await _context.Dutys.SingleOrDefaultAsync(m => m.DutyID == id);
      _context.Dutys.Remove(duty);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index), "Duties", new { id = duty.ExperienceID });
    }

    private bool DutyExists(int id)
    {
      return _context.Dutys.Any(e => e.DutyID == id);
    }
  }
}
