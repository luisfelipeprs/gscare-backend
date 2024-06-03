namespace GscareApiAspNetCore.Communication.Responses.DailyReportRepository;
public class ResponseShortDailyReportJson
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    //Questions
    public bool question1 { get; set; }
    public bool question2 { get; set; }
    public bool question3 { get; set; }
    public bool question4 { get; set; }
    public bool question5 { get; set; }
}
