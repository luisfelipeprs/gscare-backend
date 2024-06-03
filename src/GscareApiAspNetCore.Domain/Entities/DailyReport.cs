namespace GscareApiAspNetCore.Domain.Entities;
public class DailyReport
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Patient { get; set; } = string.Empty;
    public string Employee { get; set; } = string.Empty;

    //Questions
    public bool Question1 { get; set; }
    public bool Question2 { get; set; }
    public bool Question3 { get; set; }
    public bool Question4 { get; set; }
    public bool Question5 { get; set; }

}
