public class TimeMiddleware
{
    //esta propiedad nos permitira invocar el middleware que sigue 
    //y continuar con el ciclo, y construir la logica continuado la
    //secuencia de estos
    readonly RequestDelegate next;

    //constructor del middleware, y recibe el siguiente middleware
    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;        
    }

    //el metodo invoke es el metodo que debe tener el middleware
    //y sera ejecutado cuando se llame al middleware
    //el parametro HttpContext, representa el request como tal
    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        await next(context); //se invoca el siguiente middleware, y posteriormente se ejecuta el
                            //siguiente codigo
        if(context.Request.Query.Any(p=>p.Key == "time"))
        {
            //encima de la respuesta del siguiente request le escribimos la fecha
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
    }

}

//esta clase nos permitira agregar el middle al builder para poder
//usarlo en la ejecucion de los middleware en program.cs
public static class TimeMiddleWareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder)    
    {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}