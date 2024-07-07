using System.ComponentModel.DataAnnotations;

namespace GscareApiAspNetCore.Communication.Responses.MedicamentResponses;
public class ResponseMedicamentJson
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Amount { get; set; }

    [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])$", ErrorMessage = "Invalid time format. Use HH:MM:SS.")]
    public string Hours { get; set; } = "00:00:00";

    public string Frequency { get; set; } = string.Empty;
}
