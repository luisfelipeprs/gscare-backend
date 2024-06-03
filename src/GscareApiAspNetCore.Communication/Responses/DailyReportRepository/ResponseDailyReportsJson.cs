using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;

namespace GscareApiAspNetCore.Communication.Responses.DailyReportRepository;
public class ResponseDailyReportsJson
{
    public List<ResponseShortDailyReportJson> DailyReport { get; set; } = [];
}
