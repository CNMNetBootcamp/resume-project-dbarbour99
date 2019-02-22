using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resume2.Data;
using Resume2.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Resume2.Controllers
{
  public class ReferencesController : Controller
  {
    private readonly Resume2Context _context;

    public ReferencesController(Resume2Context context)
    {
      _context = context;
    }

    // GET: References
    public async Task<IActionResult> Index(int? id)
    {
      ViewData["resumeID"] = id.Value;
      var reference = await _context.References
        .Where(i => i.ResumeID == id.Value)
        .OrderBy(y => y.FirstLast)
        .AsNoTracking()
        .ToListAsync();

      return View(reference);
    }

    // GET: References/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var reference = await _context.References
          .Include(r => r.Resume)
          .SingleOrDefaultAsync(m => m.ReferenceID == id);
      if (reference == null)
      {
        return NotFound();
      }

      return View(reference);
    }

    // GET: References/Create
    public IActionResult Create(int? id)
    {
      ViewData["resumeID"] = id;
      return View();
    }

    // POST: References/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ResumeID,Position,Company,FirstLast")] Reference reference)
    {
      if (ModelState.IsValid)
      {
        _context.Add(reference);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index), "References", new { id = reference.ResumeID });
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", reference.ResumeID);
      return View(reference);
    }

    // GET: References/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var reference = await _context.References.SingleOrDefaultAsync(m => m.ReferenceID == id);
      if (reference == null)
      {
        return NotFound();
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", reference.ResumeID);
      return View(reference);
    }

    // POST: References/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ReferenceID,ResumeID,Position,Company,FirstLast")] Reference reference)
    {
      if (id != reference.ReferenceID)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(reference);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ReferenceExists(reference.ReferenceID))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index), "References", new { id = reference.ResumeID });
      }
      ViewData["ResumeID"] = new SelectList(_context.Resumes, "ResumeID", "FirstLast", reference.ResumeID);
      return View(reference);
    }

    // GET: References/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var reference = await _context.References
          .Include(r => r.Resume)
          .SingleOrDefaultAsync(m => m.ReferenceID == id);
      if (reference == null)
      {
        return NotFound();
      }

      return View(reference);
    }

    // POST: References/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var reference = await _context.References.SingleOrDefaultAsync(m => m.ReferenceID == id);
      _context.References.Remove(reference);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index), "References", new { id = reference.ResumeID });
    }

    private bool ReferenceExists(int id)
    {
      return _context.References.Any(e => e.ReferenceID == id);
    }
  }
}
