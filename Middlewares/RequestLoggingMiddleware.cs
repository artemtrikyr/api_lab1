namespace AttendanceJournalApi.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = DateTime.UtcNow;
        Console.WriteLine($"Запит до {context.Request.Method} {context.Request.Path} почався о {startTime}");

        await _next(context);

        var endTime = DateTime.UtcNow;
        Console.WriteLine($"Запит завершено о {endTime} (Тривалість: {endTime - startTime})");
    }
}
