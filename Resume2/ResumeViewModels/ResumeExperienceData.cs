using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume2.Models;

namespace Resume2.ResumeViewModels
{
  public class ResumeExperienceData
  {
    public Resume Resume { get; set; }
    public IEnumerable<Experience> Experiences { get; set; }
  }
}
