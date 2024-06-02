using GscareApiAspNetCore.Communication.Responses.MedicamentResponses;

namespace GscareApiAspNetCore.Communication.Responses.SupplyResponses;
public class ResponseSuppliesJson
{
    public List<ResponseShortSupplyJson> Supply { get; set; } = [];
}
