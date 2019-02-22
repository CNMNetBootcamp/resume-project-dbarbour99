using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resume2.Data;
using Resume2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Resume2.Controllers
{
  public class EducationsController : Controller
  {
    private readonly Resume2Context _context;

    public EducationsController(Resume2Context context)
    {
      _context = context;
    }

    // GET: Educations
    public async Task<IActionResult> Index(int? id)
    {
      ViewData["resumeID"] = id.Value;

      var education = await _context.Educations
        .Where(i => i.ResumeID == id.Value)
        .OrderBy(y => y.StartDate)
        .AsNoTracking()
        .ToListAsync();

      return View(education);
    }

    // GET: Educations/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var education = await _context.Educations
          .Include(e => e.Resume)
          .SingleOrDefaultAsync(m => m.EducationID == id);
      if (education == null)
      {
        return NotFound();
      }

      return View(education);
    }

    // GET: Educations/Create
    public IActionResult Create(int? id)
    {
      ViewData["resumeID"] = id;
      return View();
    }

    // POST: Educations/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ResumeID,Institution,Degree,City,State,StartDate,EndDate")] Education education)
    {
      //education.ResumeID = ViewData["resumeID"];
      if (ModelState.IsValid)
      {
        
        _context.Add(education);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), "Educations", new { id = education.ResumeID });
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", education.ResumeID);
      return View(education);
    }

    // GET: Educations/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var education = await _context.Educations.SingleOrDefaultAsync(m => m.EducationID == id);
      if (education == null)
      {
        return NotFound();
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", education.ResumeID);
      return View(education);
    }

    // POST: Educations/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("EducationID,ResumeID,Institution,Degree,City,State,StartDate,EndDate")] Education education)
    {
      if (id != education.EducationID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(education);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!EducationExists(education.EducationID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index), "Educations", new { id = education.ResumeID });
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", education.ResumeID);
      return View(education);
    }

    // GET: Educations/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var education = await _context.Educations
          .Include(e => e.Resume)
          .SingleOrDefaultAsync(m => m.EducationID == id);
      if (education == null)
      {
        return NotFound();
      }

      return View(education);
    }

    // POST: Educations/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var education = await _context.Educations.SingleOrDefaultAsync(m => m.EducationID == id);
      _context.Educations.Remove(education);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index), "Educations", new { id = education.ResumeID });
    }

    private bool EducationExists(int id)
    {
      return _context.Educations.Any(e => e.EducationID == id);
    }
  }
}
