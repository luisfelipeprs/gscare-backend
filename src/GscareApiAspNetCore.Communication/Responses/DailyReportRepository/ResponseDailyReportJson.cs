namespace GscareApiAspNetCore.Communication.Responses.DailyReportRepository;
public class ResponseDailyReportJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Patient { get; set; } = string.Empty;
    public string Employee { get; set; } = string.Empty;

    //Questions
    public bool question1 { get; set; }
    public bool question2 { get; set; }
    public bool question3 { get; set; }
    public bool question4 { get; set; }
    public bool question5 { get; set; }
}
