using System.Net;

namespace GscareApiAspNetCore.Exception.ExceptionBase;
public class NotFoundException : GscareException
{
    public NotFoundException(string message) : base(message)
    {
        
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
