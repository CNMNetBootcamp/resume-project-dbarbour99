using Resume2.Data;
using Resume2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Resume2.Controllers
{
  public class HomeController : Controller
  {
    private readonly Resume2Context _context;
    public HomeController(Resume2Context context)
    {
      _context = context;
    }

    public async Task<IActionResult> Index(int? id)
    {
      var resume = await _context.Resumes
        .Include(y => y.Experiences)
          .ThenInclude(y => y.Dutys)
        .Include(y => y.References)
        .Include(y => y.Educations)
        .AsNoTracking()
        .SingleOrDefaultAsync(m => m.ResumeID == 1);

      return View(resume);
    }

    public IActionResult About()
    {
      ViewData["Message"] = "Your application description page.";

      return View();
    }

    public IActionResult Contact()
    {
      ViewData["Message"] = "Your contact page.";

      return View();
    }

    //public IActionResult Error()
    //{
    //  //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
  }
}
