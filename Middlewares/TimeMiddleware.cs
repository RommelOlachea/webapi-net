using System.Collections.ObjectModel;
public class TimeMiddleware
{
    readOnly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;        
    }

    public async Invoke(HttpContext context)
    {
        
    }

}