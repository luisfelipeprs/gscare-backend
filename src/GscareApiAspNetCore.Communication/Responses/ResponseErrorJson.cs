namespace GscareApiAspNetCore.Communication.Responses;
public class ResponseErrorJson
{
    public List<string> ErrorMessages { get; set; }

    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = new List<string> { errorMessage };
    }

    public bool TokenIsExpired { get; set; }

    public ResponseErrorJson(List<string> errorMessage)
    {
        ErrorMessages = errorMessage;
    }
}
