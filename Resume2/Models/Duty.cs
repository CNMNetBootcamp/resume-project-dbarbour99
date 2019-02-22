namespace Resume2.Models
{
  public class Duty
  {

    public int DutyID { get; set; }
    public int ExperienceID { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; }

    public Experience Experience { get; set; }

  }
}