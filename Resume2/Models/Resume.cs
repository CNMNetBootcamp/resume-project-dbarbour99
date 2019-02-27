using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resume2.Models
{
  public class Resume
  {

    public int ResumeID { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "First and last name must be less than 30 characters")]
    [Display(Name = "First & Last Name")]
    public string FirstLast { get; set; }

    [StringLength(20, ErrorMessage = "City must be less than 30 characters")]
    public string City { get; set; }

    [StringLength(2, ErrorMessage = "State must be 2 characters")]
    public string State { get; set; }


    public string Email { get; set; }
    public string Phone { get; set; }
    public string Summary { get; set; }

    public ICollection<Experience> Experiences { get; set; }
    public ICollection<Reference> References { get; set; }
    public ICollection<Education> Educations { get; set; }


  }
}
