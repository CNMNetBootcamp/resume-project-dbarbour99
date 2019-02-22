namespace Resume2.Models
{
  public class Reference
  {
    public int ReferenceID { get; set; }
    public int ResumeID { get; set; }
    public string Position { get; set; }
    public string Company { get; set; }
    public string FirstLast { get; set; }

    public Resume Resume { get; set; }
  }
}