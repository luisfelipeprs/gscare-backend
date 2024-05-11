namespace GscareApiAspNetCore.Exception.ExceptionBase;
public class ErrorOnValidationException: GscareException
{
    public List<string> Errors { get; set; }

    public ErrorOnValidationException(List<string> errorMessages)
    {
        Errors = errorMessages;
    }
}
    