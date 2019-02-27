using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resume2.Models
{
  public class Experience
  {
    public int ExperienceID { get; set; }
    public int ResumeID { get; set; }
    public string Company { get; set; }
    public string CompanyDesc { get; set; }
    public string JobTitle { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }

    public Resume Resume { get; set; }
    public ICollection<Duty> Dutys { get; set; }
  }
}