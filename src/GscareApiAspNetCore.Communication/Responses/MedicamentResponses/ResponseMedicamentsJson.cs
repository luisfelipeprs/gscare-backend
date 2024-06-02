using GscareApiAspNetCore.Communication.Responses.WarningResponses;

namespace GscareApiAspNetCore.Communication.Responses.MedicamentResponses;
public class ResponseMedicamentsJson
{
    public List<ResponseShortMedicamentJson> Medicament { get; set; } = [];
}
