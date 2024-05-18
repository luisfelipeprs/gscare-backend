namespace GscareApiAspNetCore.Exception.ExceptionBase;
public abstract class GscareException: SystemException
{
    protected GscareException(string message) : base(message)
    {
        
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
