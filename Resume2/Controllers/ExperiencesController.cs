using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resume2.Data;
using Resume2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Resume2.Controllers
{
  public class ExperiencesController : Controller
  {
    private readonly Resume2Context _context;

    public ExperiencesController(Resume2Context context)
    {
      _context = context;
    }

    // GET: Experiences
    public async Task<IActionResult> Index(int? id)
    {
      ViewData["ResumeID"] = id;
      var experience = await _context.Experiences
        .Where(i => i.ResumeID == id.Value)
        .OrderBy(y => y.StartDate)
        .AsNoTracking()
        .ToListAsync();

      return View(experience);
    }

    // GET: Experiences/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var experience = await _context.Experiences
          .Include(e => e.Resume)
          .SingleOrDefaultAsync(m => m.ExperienceID == id);
      if (experience == null)
      {
        return NotFound();
      }

      return View(experience);
    }

    // GET: Experiences/Create
    public IActionResult Create(int? id)
    {
      ViewData["resumeID"] = id;
      return View();
    }

    // POST: Experiences/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ResumeID,Company,CompanyDesc,JobTitle,StartDate,EndDate")] Experience experience)
    {
      if (ModelState.IsValid)
      {
        _context.Add(experience);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index),"Experiences",new{ id = experience.ResumeID });
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", experience.ResumeID);
      return View(experience);
    }

    // GET: Experiences/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var experience = await _context.Experiences.SingleOrDefaultAsync(m => m.ExperienceID == id);
      if (experience == null)
      {
        return NotFound();
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", experience.ResumeID);
      return View(experience);
    }

    // POST: Experiences/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ExperienceID,ResumeID,Position,Company,CompanyDesc,JobTitle,StartDate,EndDate")] Experience experience)
    {
      if (id != experience.ExperienceID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(experience);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ExperienceExists(experience.ExperienceID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index), "Experiences", new { id = experience.ResumeID });
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", experience.ResumeID);
      return View(experience);
    }

    // GET: Experiences/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var experience = await _context.Experiences
          .Include(e => e.Resume)
          .SingleOrDefaultAsync(m => m.ExperienceID == id);
      if (experience == null)
      {
        return NotFound();
      }

      return View(experience);
    }

    // POST: Experiences/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var experience = await _context.Experiences.SingleOrDefaultAsync(m => m.ExperienceID == id);
      _context.Experiences.Remove(experience);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index),"Experiences",new { id=experience.ResumeID});
    }

    private bool ExperienceExists(int id)
    {
      return _context.Experiences.Any(e => e.ExperienceID == id);
    }
  }
}
