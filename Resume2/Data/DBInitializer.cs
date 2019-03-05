using Resume2.Data;
using Resume2.Models;
using System;
using System.Linq;

namespace reusme2.Data
{
  public static class DbInitializer
  {
    public static void Initialize(Resume2Context context)
    {
      context.Database.EnsureCreated();

      //comment this out so this class won't run
      //when you have data already
      if (context.Resumes.Any())
      {
        return;
      }
      int aResume = AddResume(context);
      AddEducation(aResume, context);
      AddReferences(aResume, context);
      AddExperience(aResume, context);

    }

    private static void AddExperience(int aResume, Resume2Context context)
    {
      int experienceid;
      var experience = new Experience
      {
        Company = "Century Automotive Service Corporation ",
        CompanyDesc = "Century Automotive Service Corporation ",
        EndDate = new DateTime(2019, 3, 1),
        StartDate = new DateTime(2017, 7, 1),
        JobTitle = "Director of IT",
        ResumeID = aResume
      };
      context.Experiences.Add(experience);
      context.SaveChanges();
      experienceid = experience.ExperienceID;

      var dutys = new Duty[]
        {
      new Duty
      {
        Description = "Manage all IT functions including applications, hardware, software, telephony and infrastructure",
        Priority = 1,
        ExperienceID = experienceid
      },

      new Duty
      {
        Description = "Recruit and hire highly skilled IT personnel",
        Priority = 2,
        ExperienceID = experienceid
      },
      new Duty
      {
        Description = "Manage and redesign complex data reporting process using SQL server/SSRS that communicates complex information to customers monthly.",
        Priority = 3,
        ExperienceID = experienceid
      },

      new Duty
      {
        Description = "Manage company IT priorities and budget.",
        Priority = 4,
        ExperienceID = experienceid
      }
        };
      foreach (Duty e in dutys)
      {
        context.Dutys.Add(e);
      }
      context.SaveChanges();

      //----------------------------------------------------------

      var experience2 = new Experience
      {
        Company = "Alternate Consulting Services",
        CompanyDesc = "Located in Albuquerque, NM, ACS is a consulting firm that specializes in designing and implementing financial integration between SAP and other applications",
        EndDate = new DateTime(2016, 6, 30),
        StartDate = new DateTime(2015, 8, 1),
        JobTitle = "President and Senior Consultant",
        ResumeID = aResume
      };
      context.Experiences.Add(experience2);
      context.SaveChanges();
      experienceid = experience2.ExperienceID;

      var dutys2 = new Duty[] {
      new Duty
      {
        Description = "Implemented financial and structural reorganization in SAP.  This included configuration, testing, training and developing several complex interfaces.  ",
        Priority = 1,
        ExperienceID = experienceid
      },
      new Duty
      {
        Description = "Developed and maintained financial consolidation software for client.  This allows multi-currency, multi-level financial consolidations for the client’s 10 subsidiary companies.",
        Priority = 2,
        ExperienceID = experienceid
      },
      new Duty
      {
        Description = "On call technical resource for SAP environment and other complex applications.",
        Priority = 3,
        ExperienceID = experienceid
      }
      };

      foreach (Duty e in dutys2)
      {
        context.Dutys.Add(e);
      }

      //----------------------------------------------------------------

      context.SaveChanges();
      var experience3 = new Experience
      {
        Company = "Eclipse Aerospace",
        CompanyDesc = "Located in Albuquerque, NM, Eclipse designs, manufactures and sells private jet aircraft",
        EndDate = new DateTime(2015, 7, 31),
        StartDate = new DateTime(2010, 4, 1),
        JobTitle = "Director of IT",
        ResumeID = aResume
      };
      context.Experiences.Add(experience3);
      context.SaveChanges();
      experienceid = experience3.ExperienceID;

      var dutys3 = new Duty[] {
      new Duty
      {
        Description = "Set priorities and budget for IT group in a complex manufacturing cost restricted environment.",
        Priority = 1,
        ExperienceID = experienceid
      },
      new Duty
      {
        Description = "Hired, mentored and developed a team of IT managers, analysts, network administrators and help desk technicians.",
        Priority = 2,
        ExperienceID = experienceid
      },
      new Duty
      {
        Description = "Responsible for the re-implementation of Eclipse’s SAP environment to begin manufacturing of the Eclipse 500 aircraft.",
        Priority = 3,
        ExperienceID = experienceid
      },
      new Duty
      {
        Description = "Managed all enterprise applications including their selection, design, purchase and implementation.",
        Priority = 4,
        ExperienceID = experienceid
      },
      new Duty
      {
        Description = "Responsible for understanding, maintaining and improving the full suite of SAP ERP modules to support a complex engineering, manufacturing and sales environment.",
        Priority = 4,
        ExperienceID = experienceid
      }
      };

      foreach (Duty e in dutys3)
      {
        context.Dutys.Add(e);
      }
      context.SaveChanges();


      var experience4 = new Experience[]
        {
      new Experience
      {
        Company = "Alternate Consulting Services",
        CompanyDesc = "Located in Albuquerque, NM, ACS is a consulting firm that specializes in designing and implementing financial integration between SAP and other applications",
        EndDate = new DateTime(2010, 3, 1),
        StartDate = new DateTime(2007, 8, 1),
        JobTitle = "President and Senior Consultant",
        ResumeID = aResume
      },
      new Experience
      {
        Company = "Johnson & Johnson",
        CompanyDesc = "Located in Bridgewater, New Jersey J&J is a large pharmaceutical manufacturer",
        EndDate = new DateTime(2007, 7, 1),
        StartDate = new DateTime(2003, 3, 1),
        JobTitle = "Finance System's Manager",
        ResumeID = aResume
      },
      new Experience
      {
        Company = "Overland Storage",
        CompanyDesc = "Located in San Diego, California Overland designs and builds tape backup libraries",
        EndDate = new DateTime(2003, 2, 1),
        StartDate = new DateTime(1996, 6, 1),
        JobTitle = "IT Business Analyst",
        ResumeID = aResume
      },
      new Experience
      {
        Company = "US Peace Corps",
        CompanyDesc = "Stationed in Paldiski, Estonia this is a two year volunteer opportunity",
        EndDate = new DateTime(1996, 5, 1),
        StartDate = new DateTime(1994, 6, 1),
        JobTitle = "Business Advisor",
        ResumeID = aResume
      }
        };

      foreach (Experience e in experience4)
      {
        context.Experiences.Add(e);
      }
      context.SaveChanges();
    }

    private static void AddReferences(int aResume, Resume2Context context)
    {
      var references = new Reference[]
        {
      new Reference
      {
        Company = "Century Automotive",
        FirstLast = "Anna Lovato",
        Position = "Financial Controller",
        ResumeID = aResume

      },
      new Reference
      {
        Company = "Array Technologies",
        FirstLast = "Todd Brodeur",
        Position = "SAP Business Analyst",
        ResumeID = aResume
      }
      };

      foreach (Reference e in references)
      {
        context.References.Add(e);
      }
      context.SaveChanges();

    }

    private static void AddEducation(int aResume, Resume2Context context)
    {

      var educations = new Education[]
      {
        new Education
        {
          City = "San Diego",
          Degree = "MBA Finance",
          EndDate = "Jun-1992",
          Institution = "San Diego State University",
          ResumeID = aResume,
          StartDate = "Aug-1990",
          State = "CA"
        },
        new Education
        {
          City = "San Diego",
          Degree = "BS Finance",
          EndDate = "Jun-1990",
          Institution = "San Diego State University",
          ResumeID = aResume,
          StartDate = "Aug-1985",
          State = "CA"
        }
      };

      foreach (Education e in educations)
      {
        context.Educations.Add(e);
      }
      context.SaveChanges();
    }

    private static int AddResume(Resume2Context context)
    {

      var resume = new Resume
      {
        City = "Albuquerque",
        Email = "dbarbour99@yahoo.com",
        FirstLast = "David Barbour",
        Phone = "858-243-3946",
        State = "NM",
        Summary = "Over twenty-five years of experience in finance and information technology in healthcare, manufacturing, electronics, insurance and aerospace.  Self-motivated solid leader who is able to prioritize and manage multiple simultaneous complex initiatives."
      };

      context.Resumes.Add(resume);
      context.SaveChanges();
      return resume.ResumeID;

    }
  }

}

