using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resume2.Models
{
  public class Education
  {
    public int EducationID { get; set; }
    public int ResumeID { get; set; }
    public string Institution { get; set; }
    public string Degree { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Start Date")]
    public string StartDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "End Date")]
    public string EndDate { get; set; }

    public Resume Resume { get; set; }

  }
}
